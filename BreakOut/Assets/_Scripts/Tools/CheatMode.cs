using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheatMode : MonoBehaviour
{
    public AdministradorPowerUps administradorPowerUps;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            administradorPowerUps.CallPowerUp("LIFE");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            administradorPowerUps.CallPowerUp("MULTI");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            administradorPowerUps.CallPowerUp("LARGE");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            administradorPowerUps.CallPowerUp("POWER");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            administradorPowerUps.CallPowerUp("RAYO");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            var adminVidas = administradorPowerUps.gameManager.gameObject.GetComponent<AdministradorVidas>();
            adminVidas.VidasInfinitas = !adminVidas.VidasInfinitas;
            adminVidas.ActualizarLetreroVidas();
        }
    }
}