using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public int resistencia = 1;
    public UnityEvent AumentarPuntaje;
    MathRNG objMathRNG = new MathRNG(45289574);

    void Start()
    {
    }
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
            AumentarPuntaje.Invoke();
        }
    }
    public virtual void RebotarBola(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        Vector3 v = collision.rigidbody.velocity;
        v.x = v.x < 1 && v.x > -1 ? Random.Range(-v.y, v.y) : v.x;
        v.y = v.y < 1 && v.y > -1 ? Random.Range(-v.x, v.x) : v.y;
        collision.rigidbody.velocity = v;
        resistencia--;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }
}