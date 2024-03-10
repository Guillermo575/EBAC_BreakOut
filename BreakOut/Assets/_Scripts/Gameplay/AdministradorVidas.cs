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
    Transform transformText_Vidas;
    TMP_Text Text_Vidas;
    [HideInInspector] public AudioControl audioControl;
    void Start()
    {
        transformText_Vidas = GameObject.Find("Text_Vidas").transform;
        Text_Vidas = transformText_Vidas.GetComponent<TMP_Text>();
        Text_Vidas.text = $"x {Vidas}";
        var objAudioManager = GameObject.Find("AudioManager");
        if (objAudioManager != null)
        {
            audioControl = objAudioManager.GetComponent<AudioControl>();
        }
        gameManager.OnGameOver += delegate { audioControl.BGM.Stop(); audioControl.SFX.Stop(); audioControl.PlaySoundEffect("LoseLevel"); };
    }
    public void EliminarVida()
    {
        if (!VidasInfinitas)
        {
            Vidas--;
        }
        if (Vidas < 0)
        {
            gameManager.GameOver();
            return;
        }
        var bola = Instantiate(bolaPrefab) as GameObject;
        bolaScript = bola.GetComponent<Bola>();
        bolaScript.BolaDestruida.AddListener(this.EliminarVida);
        Debug.Log($"Vidas restantes {Vidas} ");
        Text_Vidas.text = $"x {Vidas}";
    }
}