using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "PuntajeAlto", menuName = "Tools/PuntajeAlto", order = 0)]
public class PuntajeAlto : ObjetoPersistente
{
    public List<PuntuacionNivel> lst_PuntuacionNivel;
    public PuntuacionNivel GetPuntuacionNivel(String Nivel)
    {
        var lstNivel = (from x in lst_PuntuacionNivel where x.Nombre == Nivel select x).ToList();
        if (lstNivel.Count == 0)
        {
            var objNuevo = new PuntuacionNivel { Nombre = Nivel };
            lst_PuntuacionNivel.Add(objNuevo);
            lstNivel.Add(objNuevo);
        }
        return lstNivel.First();
    }
}
[Serializable]
public class PuntuacionNivel
{
    public String Nombre;
    public int puntajeAlto = 0;
    public int puntaje = 0;
}