using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MuestraEventos : MonoBehaviour
{
    public UnityEvent MiEventoUnity;
    public event EventHandler OnSpacePressed;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
            MiEventoUnity.Invoke();
        }
    }
}