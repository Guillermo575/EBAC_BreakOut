using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AdministradorBloques : MonoBehaviour
{
    public GameObject MenuFinNivel;
    void Update()
    {
        if (transform.childCount == 0)
        {
            Time.timeScale = 0;
            MenuFinNivel.SetActive(true);
        }
    }
}