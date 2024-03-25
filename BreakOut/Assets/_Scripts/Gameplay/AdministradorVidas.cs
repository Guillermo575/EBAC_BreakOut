using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class AdministradorVidas : MonoBehaviour
{
    public GameObject bolaPrefab;
    private Bola bolaScript;
    public GameManager gameManager;
    public int Vidas = 3;
    public bool VidasInfinitas = false;
    [HideInInspector] public int bolas = 1;
    [HideInInspector] public AudioControl audioControl;
    Transform transformText_Vidas;
    TMP_Text Text_Vidas;
    void Start()
    {
        ConfigurarDificultad();
        transformText_Vidas = GameObject.Find("Text_Vidas").transform;
        Text_Vidas = transformText_Vidas.GetComponent<TMP_Text>();
        Text_Vidas.text = $"x {Vidas}";
        var objAudioManager = GameObject.Find("AudioManager");
        if (objAudioManager != null)
        {
            audioControl = objAudioManager.GetComponent<AudioControl>();
        }
        gameManager.OnGameOver += delegate { audioControl.BGM.Stop(); audioControl.SFX.Stop(); audioControl.PlaySoundEffect("LoseLevel"); };
        gameManager.OnGameEnd += delegate { gameManager.DataPartida.VidasActual = Vidas; };
    }
    public void EliminarVida()
    {
        bolas--;
        if (bolas <= 0)
        {
            bolas = 1;
            if (!VidasInfinitas)
            {
                Vidas--;
                gameManager.LifeLose();
            }
            if (Vidas < 0)
            {
                gameManager.GameOver();
                return;
            }
            var bola = Instantiate(bolaPrefab) as GameObject;
            bolaScript = bola.GetComponent<Bola>();
            bolaScript.BolaDestruida.AddListener(this.EliminarVida);
            ActualizarLetreroVidas();
        }
    }
    public void ActualizarLetreroVidas()
    {
        Debug.Log($"Vidas restantes {Vidas} ");
        Text_Vidas.text = VidasInfinitas ? $"x inf" : $"x {Vidas}";
    }
    public void ConfigurarDificultad()
    {
        if (gameManager.DataPartida != null)
        {
            Vidas = gameManager.DataPartida.VidasActual;
        }
    }
}