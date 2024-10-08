using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.ParticleSystem;
using UnityEngine.UIElements;
using System;

public class Bloque : MonoBehaviour
{
    public int resistencia = 1;
    public UnityEvent AumentarPuntaje;
    public BloqueTexturaRuptura objTexturaRuptura;
    public ParticleSystemRenderer particleDeath;
    [HideInInspector]public GameObject particleSpawned;
    MathRNG objMathRNG = new MathRNG(45289574);
    Renderer m_Renderer;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        m_Renderer = this.gameObject.GetComponent<Renderer>();
        ConfigurarDificultad();
    }
    void Update()
    {
        if (resistencia <= 0)
        {
            SpawnParticle();
            MetodoDestroy();
            AumentarPuntaje.Invoke();
            Destroy(this.gameObject);
        }
    }

    private void SpawnParticle()
    {
        var obj = this.gameObject;
        particleSpawned = Instantiate(particleDeath.gameObject) as GameObject;
        particleSpawned.transform.position = obj.transform.position;
        particleSpawned.GetComponent<ParticleSystemRenderer>().material = m_Renderer.material;
        Destroy(particleSpawned, particleSpawned.GetComponent<ParticleSystem>().main.duration);
    }

    /**
     * Funcion para rebotar la bola que colisione con este bloque\n 
     * es una clase virtual para que otros objetos puedan heredar y hacer modificaciones
     */
    public virtual void RebotarBola(Collision collision)
    {
        var ClassBola = collision.gameObject.GetComponent<Bola>();
        resistencia -= ClassBola.damage;
        if (resistencia < 0)
        {
            collision.rigidbody.velocity = ClassBola.ultimaVelocidad;
            return;
        }
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = ClassBola.velocidadBola * direccion;
        Vector3 v = collision.rigidbody.velocity;
        v.x = v.x < 1 && v.x > -1 ? objMathRNG.NextValueFloat(-v.y, v.y) : v.x;
        v.y = v.y < 1 && v.y > -1 ? objMathRNG.NextValueFloat(-v.x, v.x) : v.y;
        collision.rigidbody.velocity = v;
    }
    public virtual void MetodoDestroy()
    {
    }
    public void CambiarTextura()
    {
        var materialObj = m_Renderer.material;
        var indextexture = objTexturaRuptura.texturasGrietas.Length - resistencia;
        indextexture = indextexture < 0 ? 0 : indextexture;
        indextexture = indextexture >= objTexturaRuptura.texturasGrietas.Length ? objTexturaRuptura.texturasGrietas.Length - 1 : indextexture;
        var texturaObj = objTexturaRuptura.texturasGrietas[indextexture];
        materialObj.SetTexture("_EmissionMap", texturaObj);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
            CambiarTextura();
        }
    }
    public void ConfigurarDificultad()
    {
        var objgameManager = GameObject.Find("GamePlayManager");
        if (objgameManager != null)
        {
            var gameManager = objgameManager.GetComponent<GameManager>();
            if (gameManager != null)
            {
                if (gameManager.DataPartida != null)
                {
                    var Multiplo = gameManager.DataPartida.DificultadActual.MultiploBloqueResistencia;
                    Multiplo = Multiplo <= 0 ? 1: Multiplo;
                    resistencia = (int)(resistencia * Multiplo);
                }
            }
        }
    }
}