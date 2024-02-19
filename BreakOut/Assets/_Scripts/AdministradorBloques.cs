using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AdministradorBloques : MonoBehaviour
{
    public GameManager gameManager;
    void Update()
    {
        if (transform.childCount == 0 && !gameManager.LevelCleared)
        {
            gameManager.LevelClearedGame();
        }
    }
}