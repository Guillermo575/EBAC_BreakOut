using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameCurrentData", menuName = "Tools/GameCurrentData", order = 6)]
public class SO_GameCurrentData : ScriptableObject
{
    public int VidasActual = 3;
    public typeDifficult DificultadActual;
}