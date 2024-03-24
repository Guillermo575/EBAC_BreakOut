using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    Transform transformPuntajeAlto;
    Transform transformPuntajeActual;
    TMP_Text textoPuntajeAlto;
    TMP_Text textoPuntajeActual;
    public PuntajeAlto puntajeAltoSO;
    public SO_GameCurrentData DataPartida;
    public PuntuacionNivel puntuacionNivel;
    void Start()
    {
        puntajeAltoSO.Cargar();
        puntuacionNivel = puntajeAltoSO.GetPuntuacionNivel(SceneManager.GetActiveScene().name);
        puntuacionNivel.puntaje = 0;
        transformPuntajeAlto = GameObject.Find("PuntajeAlto").transform;
        transformPuntajeActual = GameObject.Find("PuntajeActual").transform;
        textoPuntajeAlto = transformPuntajeAlto.GetComponent<TMP_Text>();
        textoPuntajeActual = transformPuntajeActual.GetComponent<TMP_Text>();
        textoPuntajeAlto.text = $"Puntaje Alto: {puntuacionNivel.puntajeAlto}";
        puntuacionNivel.puntaje = 0;
    }
    void Update()
    {
        textoPuntajeActual.text = $"Puntaje: {puntuacionNivel.puntaje}";
        if (puntuacionNivel.puntaje > puntuacionNivel.puntajeAlto)
        {
            puntuacionNivel.puntajeAlto = puntuacionNivel.puntaje;
            textoPuntajeAlto.text = $"Puntaje Alto: {puntuacionNivel.puntajeAlto}";
            puntajeAltoSO.Guardar();
        }
    }
    public void AumentarPuntaje(int puntos)
    {
        if (DataPartida != null)
        {
            puntos = (int)(puntos * DataPartida.DificultadActual.MultiploPuntos);
        }
        puntuacionNivel.puntaje += puntos;
    }
}