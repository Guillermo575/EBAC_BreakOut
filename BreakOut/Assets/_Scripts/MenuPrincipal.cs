using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    public GameObject MenuOpciones;
    public GameObject MenuInicial;
    public void IniciarJuego()
    {
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