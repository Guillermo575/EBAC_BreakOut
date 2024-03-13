using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PowerUp_Res", menuName = "Tools/PowerUp_Resources", order = 4)]
public class SO_PowerUps : ScriptableObject
{
    public List<typePowerUp_R> powerUp_List;
}
[Serializable]
public class typePowerUp_R
{
    public int Index;
    public string Clave;
    public string NombrePowerup;
    public string mensaje;
    public Texture icon;
    public Sprite SpriteIcon;
}