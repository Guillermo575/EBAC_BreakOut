using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bloque : MonoBehaviour
{
    public int resistencia = 1;
    void Start()
    {
    }
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public virtual void RebotarBola()
    {
    }
}