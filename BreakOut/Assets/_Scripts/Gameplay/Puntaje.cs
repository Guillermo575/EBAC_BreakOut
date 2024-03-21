using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Puntaje : MonoBehaviour
{
    Transform transformPuntajeAlto;
    Transform transformPuntajeActual;
    TMP_Text textoPuntajeAlto;
    TMP_Text textoPuntajeActual;
    public PuntajeAlto puntajeAltoSO;
    public SO_GameCurrentData DataPartida;
    void Start()
    {
        puntajeAltoSO.Cargar();
        transformPuntajeAlto = GameObject.Find("PuntajeAlto").transform;
        transformPuntajeActual = GameObject.Find("PuntajeActual").transform;
        textoPuntajeAlto = transformPuntajeAlto.GetComponent<TMP_Text>();
        textoPuntajeActual = transformPuntajeActual.GetComponent<TMP_Text>();
        textoPuntajeAlto.text = $"Puntaje Alto: {puntajeAltoSO.puntajeAlto}";
        puntajeAltoSO.puntaje = 0;
    }
    void Update()
    {
        textoPuntajeActual.text = $"Puntaje: {puntajeAltoSO.puntaje}";
        if (puntajeAltoSO.puntaje > puntajeAltoSO.puntajeAlto)
        {
            puntajeAltoSO.puntajeAlto = puntajeAltoSO.puntaje;
            textoPuntajeAlto.text = $"Puntaje Alto: {puntajeAltoSO.puntajeAlto}";
            puntajeAltoSO.Guardar();
        }
    }
    public void AumentarPuntaje(int puntos)
    {
        if (DataPartida != null)
        {
            puntos = (int)(puntos * DataPartida.DificultadActual.MultiploPuntos);
        }
        puntajeAltoSO.puntaje += puntos;
    }
}