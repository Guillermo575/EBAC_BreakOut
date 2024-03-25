using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class Bola : MonoBehaviour
{
    #region Variables
    private AudioControl objAudio;
    private bool isBallLaunched = false;
    private Vector3 ultimaPosicion = Vector3.zero;
    private Vector3 direccion = Vector3.zero;
    private Rigidbody rigidbody;
    private GameObject objJugador;
    MathRNG objMathRNG = new MathRNG(45289574);
    Renderer m_Renderer;
    public float velocidadBola = 10.0f;
    public float intervaloTiempoLaunch = 0.6f;
    public ParticleSystemRenderer particleDeath;
    public bool NotGameOver = false;
    public float radio = 1f;
    public int damage = 1;
    public UnityEvent BolaDestruida;
    [Header("Configurar en el editor")]
    [HideInInspector] public SpriteRenderer LimiteBordes;
    [HideInInspector] public AudioControl audioControl;
    [Header("Configuraciones dinamicas")]
    [HideInInspector] bool estaEnPantalla = true;
    [HideInInspector] bool EstaDestruida = false;
    [HideInInspector] float anchoCamara;
    [HideInInspector] float altoCamara;
    [HideInInspector] public bool salioDerecha, salioIzquierda, salioArriba, salioAbajo;
    [HideInInspector] public Vector3 ultimaVelocidad = Vector3.zero;
    TMP_Text Text_Launch;
    #endregion

    #region Unity General
    private void Awake()
    {
        altoCamara = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;
        var objLimiteBordes = GameObject.Find("Scene_Border_Image");
        if (objLimiteBordes != null)
        {
            LimiteBordes = objLimiteBordes.GetComponent<SpriteRenderer>();
            if (LimiteBordes != null)
            {
                altoCamara = LimiteBordes.bounds.extents.y;
                anchoCamara = LimiteBordes.bounds.extents.x;
            }
        }
        var objAudioManager = GameObject.Find("AudioManager");
        if (objAudioManager != null)
        {
            audioControl = objAudioManager.GetComponent<AudioControl>();
        }
    }
    void Start()
    {
        m_Renderer = this.gameObject.GetComponent<Renderer>();
        ConfigurarDificultad();
        StartPosition();
        var objTextLaunch = GameObject.Find("Text_Launch");
        if (objTextLaunch != null)
        {
            Text_Launch = objTextLaunch.gameObject.GetComponent<TMP_Text>();
        }
        if (Text_Launch != null)
        {
            StartCoroutine(CoroutinePrepareLaunch());
        }
    }
    public void StartPosition()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        objJugador = GameObject.FindGameObjectWithTag("Jugador");
        if (objJugador == null)
        {
            LaunchBall();
            return;
        }
        Vector3 posicionInicial = objJugador.transform.position;
        posicionInicial.y += 3f;
        this.transform.position = posicionInicial;
        //this.transform.SetParent(objJugador.transform);
    }
    void Update()
    {
        if (isBallLaunched)
        {
            CheckCollisions();
        }
        else
        {
            Vector3 posicionInicial = objJugador.transform.position;
            posicionInicial.y += 3f;
            this.transform.position = posicionInicial;
        }
        CheckInputs();
    }
    private void SpawnParticle()
    {
        var obj = this.gameObject;
        var particula = Instantiate(particleDeath.gameObject) as GameObject;
        particula.transform.position = obj.transform.position;
        particula.GetComponent<ParticleSystemRenderer>().material = m_Renderer.material;
        Destroy(particula, particula.GetComponent<ParticleSystem>().main.duration);
    }
    private void FixedUpdate()
    {
        ultimaPosicion = transform.position;
    }
    public void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }
    public void ConfigurarDificultad()
    {
        var objgameManager = GameObject.Find("GamePlayManager");
        if (objgameManager != null)
        {
            var gameManager = objgameManager.GetComponent<GameManager>();
            if (gameManager != null)
            {
                if (gameManager.DataPartida != null)
                {
                    velocidadBola = gameManager.DataPartida.DificultadActual.VelocidadBola;
                    intervaloTiempoLaunch = gameManager.DataPartida.DificultadActual.TimerLanzamiento;
                }
            }
        }
    }
    #endregion

    #region Collisions
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bloque")
        {
            audioControl.PlaySoundEffect("Golpe_Bloque");
        }
        if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }
    public virtual void RebotarBola(Collision collision)
    {
        var ClassBola = collision.gameObject.GetComponent<Bola>();
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = ClassBola.velocidadBola * direccion;
        Vector3 v = collision.rigidbody.velocity;
        v.x = v.x < 1 && v.x > -1 ? objMathRNG.NextValueFloat(-v.y, v.y) : v.x;
        v.y = v.y < 1 && v.y > -1 ? objMathRNG.NextValueFloat(-v.x, v.x) : v.y;
        collision.rigidbody.velocity = v;
    }
    private void CheckCollisions()
    {
        Vector3 pos = transform.position;
        estaEnPantalla = true;
        salioAbajo = salioArriba = salioDerecha = salioIzquierda = false;
        if (pos.x > anchoCamara - radio)
        {
            pos.x = anchoCamara - radio;
            salioDerecha = true;
            direccion = transform.position - ultimaPosicion;
            direccion.x *= -1;
            ReadJustVelocity();
            audioControl.PlaySoundEffect("Golpe_Pared");
        }
        if (pos.x < -anchoCamara + radio)
        {
            pos.x = -anchoCamara + radio;
            salioIzquierda = true;
            direccion = transform.position - ultimaPosicion;
            direccion.x *= -1;
            ReadJustVelocity();
            audioControl.PlaySoundEffect("Golpe_Pared");
        }
        if (pos.y > altoCamara - radio)
        {
            pos.y = altoCamara - radio;
            salioArriba = true;
            direccion = transform.position - ultimaPosicion;
            direccion.y *= -1;
            ReadJustVelocity();
            audioControl.PlaySoundEffect("Golpe_Pared");
        }
        if (pos.y < -altoCamara + radio)
        {
            pos.y = -altoCamara + radio;
            salioAbajo = true;
            if (!NotGameOver)
            {
                if (!EstaDestruida)
                {
                    EstaDestruida = true;
                    SpawnParticle();
                    audioControl.PlaySoundEffect("Golpe_Suelo");
                    StartCoroutine(CoroutineBallDeath());
                }
            }
            else
            {
                direccion = transform.position - ultimaPosicion;
                direccion.y *= -1;
                ReadJustVelocity();
                audioControl.PlaySoundEffect("Golpe_Pared");
            }
        }
        estaEnPantalla = !(salioAbajo || salioArriba || salioDerecha || salioIzquierda);
        if (!estaEnPantalla)
        {
            transform.position = pos;
            estaEnPantalla = true;
        }
    }
    private void ReadJustVelocity()
    {
        direccion = direccion.normalized;
        rigidbody.velocity = velocidadBola * direccion;
        if (isBallLaunched)
        {
            Vector3 v = rigidbody.velocity;
            v.x = v.x < 1 && v.x > -1 ? objMathRNG.NextValueFloat(-velocidadBola, velocidadBola) : v.x;
            v.y = v.y < 1 && v.y > -1 ? objMathRNG.NextValueFloat(-velocidadBola, velocidadBola) : v.y;
            rigidbody.velocity = v;
        }
        ultimaVelocidad = rigidbody.velocity;
    }
    IEnumerator CoroutineBallDeath()
    {
        var lstBolas = GameObject.FindGameObjectsWithTag("Bola");
        if (lstBolas.Length <= 1)
        {
            Time.timeScale = .0f;
            yield return new WaitForSecondsRealtime(0.3f);
            Time.timeScale = .4f;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
        BolaDestruida.Invoke();
        Destroy(this.gameObject);
    }
    #endregion

    #region Controls
    private void CheckInputs()
    {
        if (Input.GetKey(KeyCode.Space) || GetValidJoystickButton())
        {
            if (!isBallLaunched)
            {
                LaunchBall();
            }
        }
    }
    public bool GetValidJoystickButton()
    {
        return Input.GetButton("Submit") || 
               Input.GetButton("Fire1") || 
               Input.GetButton("Fire2") || 
               Input.GetButton("Fire3") || 
               Input.GetButton("Jump") ||
               Input.GetButton("Cancel");
    }
    public void LaunchBall()
    {
        isBallLaunched = true;
        //this.transform.SetParent(null);
        rigidbody.velocity = velocidadBola * Vector3.up;
        if (Text_Launch != null)
        {
            Text_Launch.text = string.Empty;
        }
        ultimaVelocidad = rigidbody.velocity;
    }
    IEnumerator CoroutinePrepareLaunch()
    {
        for(int l = 3; l > 0 && !isBallLaunched; l--)
        {
            Text_Launch.text = l.ToString();
            yield return new WaitForSeconds(intervaloTiempoLaunch);
        }
        if (!isBallLaunched)
        {
            Text_Launch.text = string.Empty;
            yield return new WaitForSeconds(0.25f);
            LaunchBall();
        }
    }
    #endregion
}