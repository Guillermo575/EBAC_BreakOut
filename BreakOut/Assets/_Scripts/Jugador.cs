using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Jugador : MonoBehaviour
{
    #region Variables Editor
    public float VelocidadPaddle = 150f;
    public ControlMode ControlModeSelected = ControlMode.KeyBoard;
    #endregion

    #region Variables Internas
    int limiteMinX = -23;
    int limiteMaxX = 23;
    Transform transform;
    Vector3 mousePos2D;
    Vector3 mousePos3D;
    public enum ControlMode
    {
        KeyBoard = 1,
        Mouse = 2,
    }
    #endregion

    #region General
    void Start()
    {
        transform = this.gameObject.transform;
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        limiteMinX = (int)(Camera.main.transform.position.x -(width/2) + transform.localScale.y);
        limiteMaxX = (int)(Camera.main.transform.position.x + (width / 2) - transform.localScale.y);
    }
    void Update()
    {
        switch (ControlModeSelected)
        {
            case ControlMode.Mouse: InputMouse(); break;
            case ControlMode.KeyBoard: InputKeyboard(); break;
        }
        var lstGamepads = Input.GetJoystickNames();
        if (lstGamepads.Length > 0)
        {
            if (!string.IsNullOrEmpty(lstGamepads.First()))
            {
                InputGamePad();
            }
        }
    }
    #endregion

    #region Colisiones
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            Vector3 direccion = collision.contacts[0].point - transform.position;
            direccion = direccion.normalized;
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        }
    }
    #endregion

    #region Controles
    private void InputMouse()
    {
        mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        VerifyLimits(pos);
    }
    private void InputKeyboard()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.down * VelocidadPaddle * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.up * VelocidadPaddle * Time.deltaTime);
        }
        VerifyLimits(transform.position);
    }
    private void InputGamePad()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * VelocidadPaddle * Time.deltaTime);
        VerifyLimits(transform.position);
    }
    private void VerifyLimits(Vector3 pos)
    {
        if (pos.x < limiteMinX)
        {
            pos.x = limiteMinX;
        }
        else if (pos.x > limiteMaxX)
        {
            pos.x = limiteMaxX;
        }
        transform.position = pos;
    }
    #endregion
}