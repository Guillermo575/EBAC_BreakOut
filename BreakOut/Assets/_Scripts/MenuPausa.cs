using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuOpciones;
    public void MostrarMenuPausa()
    {
        Time.timeScale = 0;
        menuPausa.SetActive(true);
        if (menuOpciones.activeInHierarchy)
        {
            menuOpciones.SetActive(false);
        }
    }
    public void OcultarMenuPausa()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
    }
    public void RegresarAPantallaPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void MostrarMenuOpciones()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }
}