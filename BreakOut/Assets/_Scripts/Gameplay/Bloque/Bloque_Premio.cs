using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bloque_Premio : Bloque
{
    public string Clave = "LIFE";
    private GameObject gameManager;
    public override void MetodoDestroy()
    {
        base.MetodoDestroy();
        gameManager = GameObject.Find("GamePlayManager");
        gameManager.GetComponent<AdministradorPowerUps>().CallPowerUp(Clave);
    }
}