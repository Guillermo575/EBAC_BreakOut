using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bola : MonoBehaviour
{
    bool isGameStarted = false;
    [SerializeField] public float velocidadBola = 10.0f;
    void Start()
    {
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3f;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
    }
    void Update()
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
}