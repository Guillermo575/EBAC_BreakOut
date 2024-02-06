using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
public class MuestraSubscriptor : MonoBehaviour
{
    MuestraEventos subscriptor;
    void Start()
    {
        subscriptor = GetComponent<MuestraEventos>();
        subscriptor.OnSpacePressed += MensajeEscuchadoPorElSubscriptor;
    }
    void Update()
    {
    }
    private void MensajeEscuchadoPorElSubscriptor(object sender, EventArgs e)
    {
        Debug.Log("el evento se escucho desde otra clase");
    }
    public void EventUnityTriggered()
    {
        Debug.Log("el evento UNITY se escucho desde otra clase");
    }
}