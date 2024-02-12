using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    bool isGameStarted = false;
    Vector3 ultimaPosicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    Rigidbody rigidbody;
    private ControlBordes control;
    public float velocidadBola = 10.0f;
    public UnityEvent BolaDestruida;

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
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
        }
        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde superior");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioArriba = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.1f);
        }
        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde derecho");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioDerecha = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.1f);
        }
        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde izquierda");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioIzquierda = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.1f);
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