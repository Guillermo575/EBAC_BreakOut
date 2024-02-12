using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bloque_Goma : Bloque
{
    void Start()
    {
        resistencia = 2;
    }
    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }
}