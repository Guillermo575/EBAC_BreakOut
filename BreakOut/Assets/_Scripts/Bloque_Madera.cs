using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bloque_Madera : Bloque
{
    void Start()
    {
        resistencia = 3;
    }
    public override void RebotarBola()
    {
        base.RebotarBola();
    }
}