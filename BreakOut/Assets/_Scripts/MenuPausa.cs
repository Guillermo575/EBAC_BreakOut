using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject menuPausa;
    public GameObject menuOpciones;
    private void Awake()
    {
        gameManager.OnGamePause += MostrarMenuPausa;
        gameManager.OnGameResume += delegate {
            menuPausa.SetActive(false);
            menuOpciones.SetActive(false);
        };
    }
    private void MostrarMenuPausa(object sender, EventArgs e)
    {
        menuPausa.SetActive(true);
        if (menuOpciones.activeInHierarchy)
        {
            menuOpciones.SetActive(false);
        }
    }
    public void OcultarMenuPausa()
    {
        menuPausa.SetActive(false);
        gameManager.ResumeGame();
    }
    public void RegresarAPantallaPrincipal(GameObject objMenu)
    {
        var lstPanelConfirmar = FindObjectsOfType<MenuConfirmar>(true);
        if (lstPanelConfirmar.Length > 0)
        {
            UnityEvent objEvent = new UnityEvent();
            objEvent.AddListener(EventoRegresarAPantallaPrincipal);
            lstPanelConfirmar[0].OpenWindow(objMenu, objEvent, "¿Desea regresar al menu principal?");
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
    public void OcultarMenuOpciones()
    {
        menuPausa.SetActive(true);
        menuOpciones.SetActive(false);
    }
    private void EventoRegresarAPantallaPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}