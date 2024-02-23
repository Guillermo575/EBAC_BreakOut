using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Bola : MonoBehaviour
{
    #region Variables
    private bool isGameStarted = false;
    private Vector3 ultimaPosicion = Vector3.zero;
    private Vector3 direccion = Vector3.zero;
    private Rigidbody rigidbody;
    private ControlBordes control;
    public float velocidadBola = 10.0f;
    public UnityEvent BolaDestruida;
    public bool NotGameOver = false;
    MathRNG objMathRNG = new MathRNG(45289574);
    #endregion

    #region Unity General
    private void Awake()
    {
        control = GetComponent<ControlBordes>();
    }
    void Start()
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
    private void HabilitarControl()
    {
        control.enabled = true;
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
    private void CheckCollisions()
    {
        if (control.salioAbajo)
        {
            if (!NotGameOver)
            {
                BolaDestruida.Invoke();
                Destroy(this.gameObject);
            }
            else
            {
                direccion = transform.position - ultimaPosicion;
                Debug.Log("La bola toco el borde inferior");
                direccion.y *= -1;
                ReadJustVelocity();
                control.salioAbajo = false;
                //control.enabled = false;
                //Invoke("HabilitarControl", 0.2f);
            }
        }
        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde superior");
            direccion.y *= -1;
            ReadJustVelocity();
            control.salioArriba = false;
            //control.enabled = false;
            //Invoke("HabilitarControl", 0.2f);
        }
        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde derecho");
            direccion.x *= -1;
            ReadJustVelocity();
            control.salioDerecha = false;
            //control.enabled = false;
            //Invoke("HabilitarControl", 0.2f);
        }
        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde izquierda");
            direccion.x *= -1;
            ReadJustVelocity();
            control.salioIzquierda = false;
            //control.enabled = false;
            //Invoke("HabilitarControl", 0.2f);
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