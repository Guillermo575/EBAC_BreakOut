using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class AdministradorPowerUps : MonoBehaviour
{
    public GameManager gameManager;
    public SO_PowerUps PowerUps;
    public Jugador Jugador;
    public Bola bolaPrefab;
    public AdministradorBloques bloques;
    public TMP_Text textoPowerUp;
    public Image ImgPowerUp;

    private AdministradorVidas adminVidas;
    private void Awake()
    {
        ImgPowerUp.gameObject.SetActive(false);
    }
    private void Start()
    {
        adminVidas = gameManager.gameObject.GetComponent<AdministradorVidas>();
    }
    IEnumerator CourutinePOMessage(typePowerUp_R obj)
    {
        ImgPowerUp.gameObject.SetActive(true);
        textoPowerUp.text = obj.mensaje;
        ImgPowerUp.sprite = obj.SpriteIcon;
        yield return new WaitForSeconds(3f);
        ImgPowerUp.gameObject.SetActive(false);
        textoPowerUp.text = string.Empty;
        ImgPowerUp.sprite = null;
    }
    public void CallPowerUp(string Clave)
    {
        var lst = (from x in PowerUps.powerUp_List where x.Clave == Clave select x).ToList();
        if (lst.Count > 0)
        {
            var obj = lst.First();
            StartCoroutine(CourutinePOMessage(obj));
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
        var listBolas = GameObject.FindGameObjectsWithTag("Bola");
        var objBola = (GameObject)listBolas[0];
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