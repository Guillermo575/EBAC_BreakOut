using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuFinNivel : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject menuFinNivel;
    public GameObject menuFinJuego;
    private void Awake()
    {
        gameManager.OnGameLevelCleared += delegate { menuFinNivel.SetActive(true); };
        gameManager.OnGameOver += delegate { menuFinJuego.SetActive(true); };
    }
    public void SiguienteNivel()
    {
        var siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > siguienteNivel)
        {
            SceneManager.LoadScene(siguienteNivel);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void ReintentarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}