using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SliderVolumenMusica : MonoBehaviour
{
    public Opciones opciones;
    Slider slider;
    public void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.value = (int)opciones.VolumenMusica;
        slider.onValueChanged.AddListener(delegate { ControlarCambios(); });
    }
    public void ControlarCambios()
    {
        opciones.CambiarVolumenMusica(slider.value);
    }
}