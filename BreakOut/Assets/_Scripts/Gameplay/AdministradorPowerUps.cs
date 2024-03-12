using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AdministradorPowerUps : MonoBehaviour
{
    public GameManager gameManager;
    public SO_PowerUps PowerUps;
    public Jugador Jugador;
    public Bola bolaPrefab;
    public AdministradorBloques bloques;

    private AdministradorVidas adminVidas;
    private void Start()
    {
        adminVidas = gameManager.gameObject.GetComponent<AdministradorVidas>();
    }
    public void CallPowerUp(string Clave)
    {
        var lst = (from x in PowerUps.powerUp_List where x.Clave == Clave select x).ToList();
        if (lst.Count > 0)
        {
            var obj = lst.First();
            switch (Clave)
            {
                case "LIFE": IncrementarVida(); break;
                case "MULTI": Multibola(); break;
                case "LARGE": PaddleLargo(); break;
                case "POWER": AumentarBola(); break;
                case "RAYO": DamageBlocks(); break;
            }
        }
    }
    public void IncrementarVida()
    {
        adminVidas = gameManager.gameObject.GetComponent<AdministradorVidas>();
        adminVidas.Vidas++;
        adminVidas.ActualizarLetreroVidas();
    }
    public void Multibola()
    {
        adminVidas.bolas++;
        var bola = Instantiate(bolaPrefab.gameObject) as GameObject;
        var bolaScript = bola.GetComponent<Bola>();
        bolaScript.BolaDestruida.AddListener(adminVidas.EliminarVida);
    }
    public void AumentarBola()
    {
        var objBola = GameObject.Find("Bola");
        var transformBola = objBola.transform;
        transformBola.localScale += new Vector3(1, 1, 1);
        var BolaClass = objBola.GetComponent<Bola>();
        if (BolaClass != null)
        {
            BolaClass.damage++;
        }
    }
    public void PaddleLargo()
    {

    }
    public void DamageBlocks()
    {
        foreach (Transform child in bloques.transform)
        {
            var obj = child.gameObject.GetComponent<Bloque>();
            if (obj != null)
            {
                obj.resistencia--;
                obj.CambiarTextura();
            }
        }
    }
}