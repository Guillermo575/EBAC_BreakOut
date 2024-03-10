using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AdministradorBloques : MonoBehaviour
{
    public GameManager gameManager;
    [HideInInspector] public AudioControl audioControl;
    private void Start()
    {
        var objAudioManager = GameObject.Find("AudioManager");
        if (objAudioManager != null)
        {
            audioControl = objAudioManager.GetComponent<AudioControl>();
        }
        gameManager.OnGameLevelCleared += delegate { audioControl.BGM.Stop(); audioControl.SFX.Stop(); audioControl.PlaySoundEffect("WinLevel"); };
    }
    void Update()
    {
        if (transform.childCount == 0 && !gameManager.LevelCleared)
        {
            gameManager.LevelClearedGame();
        }
    }
}