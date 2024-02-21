using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControlBordes : MonoBehaviour
{
    [Header("Configurar en el editor")]
    public float radio = 1f;

    [Header("Configuraciones dinamicas")]
    public bool estaEnPantalla = true;
    public float anchoCamara;
    public float altoCamara;
    public bool salioDerecha, salioIzquierda, salioArriba, salioAbajo;

    public void Awake()
    {
        altoCamara = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;
    }
    void LateUpdate()
    {
        CheckCollisions();
    }
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 tamanoBorde = new Vector3(anchoCamara * 2, altoCamara * 2, 0.1f);
        Gizmos.DrawCube(Vector3.zero, tamanoBorde);
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
        }
        if (pos.x < -anchoCamara + radio)
        {
            pos.x = -anchoCamara + radio;
            salioIzquierda = true;
        }
        if (pos.y > altoCamara - radio)
        {
            pos.y = altoCamara - radio;
            salioArriba = true;
        }
        if (pos.y < -altoCamara + radio)
        {
            pos.y = -altoCamara + radio;
            salioAbajo = true;
        }
        estaEnPantalla = !(salioAbajo || salioArriba || salioDerecha || salioIzquierda);
        if (!estaEnPantalla)
        {
            transform.position = pos;
            estaEnPantalla = true;
        }
    }
}