using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuFinNivel : MonoBehaviour
{
    public void SiguienteNivel()
    {
        Time.timeScale = 1;
        var siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > siguienteNivel)
        {
            SceneManager.LoadScene(siguienteNivel);
        }
        else
        {
            CargarMenuPrincipal();
        }
    }
    public void CargarMenuPrincipal()
    {
        var lstPanelConfirmar = FindObjectsOfType<MenuConfirmar>(true);
        if (lstPanelConfirmar.Length > 0)
        {
            UnityEvent objEvent = new UnityEvent();
            objEvent.AddListener(EventoRegresarAPantallaPrincipal);
            lstPanelConfirmar[0].OpenWindow(this.gameObject, objEvent, "¿Desea regresar al menu principal?");
        }
        else
        {
            EventoRegresarAPantallaPrincipal();
        }
    }
    public void ReintentarNivel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void EventoRegresarAPantallaPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}