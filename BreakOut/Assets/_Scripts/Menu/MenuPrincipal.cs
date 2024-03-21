using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    public GameObject MenuOpciones;
    public GameObject MenuInicial;
    public Opciones opciones;
    public SO_GameCurrentData DataPartida;
    public SO_DifficultAtributes SO_Dificultad;
    public void IniciarJuego()
    {
        DataPartida.DificultadActual = SO_Dificultad.Obtener(opciones.NivelDificultad.ToString());
        DataPartida.VidasActual = DataPartida.DificultadActual.NumeroVidas;
        SceneManager.LoadScene(1);
    }
    public void FinalizarJuego()
    {
        Application.Quit();
    }
    public void MostrarOpciones()
    {
        MenuInicial.SetActive(false);
        MenuOpciones.SetActive(true);  
    }
    public void MostrarMenuInicial()
    {
        MenuInicial.SetActive(true);
        MenuOpciones.SetActive(false);
    }
}