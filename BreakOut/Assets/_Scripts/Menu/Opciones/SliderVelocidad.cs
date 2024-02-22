using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SliderVelocidad : MonoBehaviour
{
    public Opciones opciones;
    Slider slider;
    public void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.value = (int)opciones.VelocidadBola;
        slider.onValueChanged.AddListener(delegate { ControlarCambios(); });
    }
    public void ControlarCambios()
    {
        opciones.CambiarVelocidad(slider.value);
    }
}
