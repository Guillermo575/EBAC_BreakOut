using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Bola : MonoBehaviour
{
    #region Variables
    private AudioControl objAudio;
    private bool isGameStarted = false;
    private Vector3 ultimaPosicion = Vector3.zero;
    private Vector3 direccion = Vector3.zero;
    private Rigidbody rigidbody;
    MathRNG objMathRNG = new MathRNG(45289574);
    Renderer m_Renderer;
    public float velocidadBola = 10.0f;
    public ParticleSystemRenderer particleDeath;
    public bool NotGameOver = false;
    public float radio = 1f;
    public UnityEvent BolaDestruida;
    [Header("Configurar en el editor")]
    [HideInInspector] public SpriteRenderer LimiteBordes;
    [HideInInspector] public AudioControl audioControl;
    [Header("Configuraciones dinamicas")]
    [HideInInspector] bool estaEnPantalla = true;
    [HideInInspector] float anchoCamara;
    [HideInInspector] float altoCamara;
    [HideInInspector] public bool salioDerecha, salioIzquierda, salioArriba, salioAbajo;
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
        StartPosition();
    }
    public void StartPosition()
    {
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3f;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        CheckCollisions();
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
    #endregion

    #region Collisions
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bloque")
        {
            audioControl.PlaySoundEffect("Golpe_Bloque");
        }
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
                SpawnParticle();
                BolaDestruida.Invoke();
                Destroy(this.gameObject);
                audioControl.PlaySoundEffect("Golpe_Suelo");
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
        if (isGameStarted)
        {
            Vector3 v = rigidbody.velocity;
            v.x = v.x == 0 ? objMathRNG.NextValueFloat(-velocidadBola, velocidadBola) : v.x;
            v.y = v.y == 0 ? objMathRNG.NextValueFloat(-velocidadBola, velocidadBola) : v.y;
            rigidbody.velocity = v;
        }
    }
    #endregion

    #region Controls
    private void CheckInputs()
    {
        if (Input.GetKey(KeyCode.Space) || GetValidJoystickButton())
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = velocidadBola * Vector3.up;
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
    #endregion
}