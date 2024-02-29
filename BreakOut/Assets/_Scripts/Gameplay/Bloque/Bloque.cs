using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.ParticleSystem;
using UnityEngine.UIElements;

public class Bloque : MonoBehaviour
{
    public int resistencia = 1;
    public UnityEvent AumentarPuntaje;
    public BloqueTexturaRuptura objTexturaRuptura;
    public ParticleSystemRenderer particleDeath;
    MathRNG objMathRNG = new MathRNG(45289574);
    Renderer m_Renderer;

    void Start()
    {
        m_Renderer = this.gameObject.GetComponent<Renderer>();
    }
    void Update()
    {
        if (resistencia <= 0)
        {
            SpawnParticle();
            Destroy(this.gameObject);
            AumentarPuntaje.Invoke();
        }
    }
    private void SpawnParticle()
    {
        var obj = this.gameObject;
        var particula = Instantiate(particleDeath.gameObject) as GameObject;
        particula.transform.position = obj.transform.position;
        particula.GetComponent<ParticleSystemRenderer>().material = m_Renderer.material;
        Destroy(particula, particula.GetComponent<ParticleSystem>().main.duration);
    }
    public virtual void RebotarBola(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        Vector3 v = collision.rigidbody.velocity;
        v.x = v.x < 1 && v.x > -1 ? objMathRNG.NextValueFloat(-v.y, v.y) : v.x;
        v.y = v.y < 1 && v.y > -1 ? objMathRNG.NextValueFloat(-v.x, v.x) : v.y;
        collision.rigidbody.velocity = v;
        resistencia--;
    }
    public virtual void CambiarTextura()
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
}