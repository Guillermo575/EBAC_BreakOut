using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bloque_Premio : Bloque
{
    void OnDestroy()
    {
        //La idea que tengo con este bloque es que cuando se destruya
        //deje caer un objeto que al tocar el jugador le de una bonificacion como:
        //Mas puntos, una vida extra, etc.
    }
}