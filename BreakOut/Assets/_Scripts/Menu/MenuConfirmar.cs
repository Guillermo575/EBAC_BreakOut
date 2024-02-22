using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class MenuConfirmar : MonoBehaviour
{
    public TMP_Text txtTitulo;
    GameObject pnlAnterior;
    UnityEvent EventoConfirmar;
    public void OpenWindow(GameObject pnlAnterior, UnityEvent EventoConfirmar, string titulo = null)
    {
        this.gameObject.SetActive(true);
        this.pnlAnterior = pnlAnterior;
        this.EventoConfirmar = EventoConfirmar;
        if (!string.IsNullOrEmpty(titulo))
        {
            txtTitulo.text = titulo;
        }
        pnlAnterior.SetActive(false);
    }
    public void ConfirmarNo()
    {
        pnlAnterior.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ConfirmarSi()
    {
        pnlAnterior.SetActive(true);
        EventoConfirmar.Invoke();
        this.gameObject.SetActive(false);
    }
}