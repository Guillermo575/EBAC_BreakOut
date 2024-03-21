using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "Difficult_Atributes", menuName = "Tools/Difficult_Atributes", order = 5)]
public class SO_DifficultAtributes : ScriptableObject
{
    public List<typeDifficult> difficult_List;
    public typeDifficult Obtener(string Nombre)
    {
        return (from x in difficult_List where x.Nombre.ToUpper() == Nombre.ToUpper() select x).First();
    }
}
[Serializable]
public class typeDifficult
{
    public int Index;
    public String Nombre;
    public int NumeroVidas;
    public Vector3 EscalaJugador;
    public float TimerLanzamiento;
    public float MultiploPuntos;
}