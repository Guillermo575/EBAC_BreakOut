using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CajaPowerUp : MonoBehaviour
{
    public string Clave = "LIFE";
    public float VelocidadCaida = 10f;
    [HideInInspector] public Vector3 EscalaBloque = new Vector3(1,1,1);
    private GameObject gameManager;
    [HideInInspector] SpriteRenderer LimiteBordes;
    [HideInInspector] AudioControl audioControl;
    [HideInInspector] float anchoCamara;
    [HideInInspector] float altoCamara;
    private void Awake()
    {
        gameManager = GameObject.Find("GamePlayManager");
        altoCamara = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;
        var objLimiteBordes = GameObject.Find("Scene_Border_Image");
        if (objLimiteBordes != null)
        {
            LimiteBordes = objLimiteBordes.GetComponent<SpriteRenderer>();
            if (LimiteBordes != null)
            {
                altoCamara = LimiteBordes.bounds.extents.y;
                anchoCamara = LimiteBordes.bounds.extents.x;
            }
        }
        var objAudioManager = GameObject.Find("AudioManager");
        if (objAudioManager != null)
        {
            audioControl = objAudioManager.GetComponent<AudioControl>();
        }
    }
    void Start()
    {
    }
    void Update()
    {
        transform.Translate(0, -10 * Time.deltaTime, 0);
        CheckCollisions();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            gameManager.GetComponent<AdministradorPowerUps>().CallPowerUp(Clave);
            Destroy(this.gameObject);
        }
    }
    private void CheckCollisions()
    {
        Vector3 pos = transform.position;
        if (pos.y < -altoCamara)
        {
            Destroy(this.gameObject);
        }
    }
}