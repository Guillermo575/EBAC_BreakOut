using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Opciones", menuName = "Tools/Opciones", order = 1)]
public class Opciones : ObjetoPersistente
{
    public float VelocidadBola = 30;
    public dificultad NivelDificultad = dificultad.facil;
    public enum dificultad
    {
        facil,
        normal,
        dificil
    }
    public void CambiarVelocidad(float nuevaVelocidad)
    {
        VelocidadBola = nuevaVelocidad;
    }
    public void CambiarDificultad(float nuevaDificultad)
    {
        NivelDificultad = (dificultad)nuevaDificultad;
    }
}