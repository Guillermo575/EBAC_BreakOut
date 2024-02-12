using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropdownDificultad : MonoBehaviour
{
    public Opciones opciones;
    private TMP_Dropdown dificultad;
    private void Start()
    {
        dificultad = GetComponent<TMP_Dropdown>();
        dificultad.value = (int)opciones.NivelDificultad;
        dificultad.onValueChanged.AddListener(delegate { opciones.CambiarDificultad(dificultad.value); });
    }
}