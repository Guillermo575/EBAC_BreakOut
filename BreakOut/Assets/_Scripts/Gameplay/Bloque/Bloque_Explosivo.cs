using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bloque_Explosivo : Bloque
{
    public int BlastDamage = 3;
    public float RadioDamage = 10;
    void OnDestroy()
    {
        var ps = particleSpawned.gameObject.GetComponent<ParticleSystem>().main;
        ps.startSpeed = RadioDamage/0.1f;
        var lstBloques = GameObject.FindGameObjectsWithTag("Bloque");
        foreach (var obj in lstBloques)
        {
            var  distanceBetweenObjects = Vector3.Distance(this.gameObject.transform.position, obj.transform.position);
            if (distanceBetweenObjects <= RadioDamage)
            {
                var objBloque = obj.GetComponent<Bloque>();
                objBloque.resistencia -= BlastDamage;
                objBloque.CambiarTextura();
            }
        }
    }
}