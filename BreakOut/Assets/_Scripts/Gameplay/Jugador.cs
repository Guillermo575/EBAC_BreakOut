using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Jugador : MonoBehaviour
{
    #region Variables Editor
    public ControlMode ControlModeSelected = ControlMode.KeyBoard;
    public Opciones opciones;
    public Vector3 EscalaInicial = new Vector3(1, 4, 2);
    public bool EscalaIncrementada = false;
    #endregion

    #region Variables Internas
    float VelocidadPaddle = 150f;
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
    [HideInInspector] SpriteRenderer LimiteBordes;
    [HideInInspector] AudioControl audioControl;
    [HideInInspector] GameObject gameManager;
    #endregion

    #region General
    void Start()
    {
        gameManager = GameObject.Find("GamePlayManager");
        gameManager.GetComponent<GameManager>().OnLifeLose += delegate { transform.localScale = EscalaInicial; EscalaIncrementada = false; };
        transform = this.gameObject.transform;
        transform.localScale = EscalaInicial;
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        limiteMinX = (int)(Camera.main.transform.position.x -(width/2) + transform.localScale.y);
        limiteMaxX = (int)(Camera.main.transform.position.x + (width / 2) - transform.localScale.y);
        LimiteBordes = GameObject.Find("Scene_Border_Image").GetComponent<SpriteRenderer>();
        if (LimiteBordes != null)
        {
            width = LimiteBordes.bounds.extents.x - 3;
            limiteMinX = (int)(LimiteBordes.transform.position.x - (width));
            limiteMaxX = (int)(LimiteBordes.transform.position.x + (width));
        }
        var objAudioManager = GameObject.Find("AudioManager");
        if (objAudioManager != null)
        {
            audioControl = objAudioManager.GetComponent<AudioControl>();
        }
    }
    void Update()
    {
        VelocidadPaddle = opciones.VelocidadPaddle;
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
            audioControl.PlaySoundEffect("Golpe_Paddle");
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

    #region IncrementarEscala
    public void IncrementarEscala() 
    {
        if (!EscalaIncrementada)
        {
            var Incremento =EscalaInicial;
            Incremento.y = Incremento.y * 2f;
            transform.localScale = Incremento; 
            EscalaIncrementada = true;
        }
    }
    #endregion
}