using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
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
        var lstPanelConfirmar = FindObjectsOfType<MenuConfirmar>(true);
        if (lstPanelConfirmar.Length > 0)
        {
            UnityEvent objEvent = new UnityEvent();
            objEvent.AddListener(EventoRegresarAPantallaPrincipal);
            lstPanelConfirmar[0].OpenWindow(menuPausa, objEvent, "¿Desea regresar al menu principal?");
        }
        else
        {
            EventoRegresarAPantallaPrincipal();
        }
    }
    public void MostrarMenuOpciones()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }
    private void EventoRegresarAPantallaPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}