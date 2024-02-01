using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bloque_Explosivo : Bloque
{
    void OnDestroy()
    {
        //La idea que tengo con este bloque es que cuando se destruya
        //reduzca la resistencia de los bloques adyacentes en 1
    }
}