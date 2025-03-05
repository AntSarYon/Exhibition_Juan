using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    //Referencia a C�mara
    private Transform cameraMain;

    private Rigidbody mRb;
    private AudioSource mAudioSource;

    private Vector2 mDirection;
    private Vector2 mDeltaLook;

    [Header("Velocidad de Movimiento")]
    [SerializeField] private float movementSpeed;

    [Header("Velocidad de Rotaci�n")]
    [SerializeField] private float turnSpeed;

    //Objeto interactuable actual
    [HideInInspector] public InteractableObject targetInteractableObject;

    //--------------------------------------------------------------------

    void Awake()
    {
        //Asignamos Instancia
        Instance = this;

        //Obtenemos referencia al componente RigidBody
        mRb = GetComponent<Rigidbody>();
    }

    //--------------------------------------------------------------------

    #region InputActions
    private void OnMove(InputValue value)
    {
        //Obtenemos Direccion de movimiento (en un Vector2, con X e Y)
        mDirection = value.Get<Vector2>();
    }

    private void OnLook(InputValue value)
    {
        //Obtenemos el Vector2 generado por la rotaci�n del Raton
        mDeltaLook = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        //Intentamos Iteractuar
        TryInteract();
    }

    #endregion

    //--------------------------------------------------------------------------------------------

    private void TryInteract()
    {
        if (targetInteractableObject != null)
        {
            //Activamos su interaccion
            targetInteractableObject.EnableInteraction();
        }

        //Si no hay interaccion al frente
        else
        {
            //Si el dialogo esta activo...
            if (UIController.Instance.HasDialogueEnabled)
            {
                //Interactuamos para desactivarlo
                UIController.Instance.InteractWithDialogue();
            }
        }

        

    }

    //--------------------------------------------------------------------------------------------

    private void ControlSpeed()
    {
        Vector3 flatVelocity = new Vector3(mRb.velocity.x, 0, mRb.velocity.z);

        //Limitamos la velocidad dentro del limite
        if (flatVelocity.magnitude > movementSpeed)
        {
            Vector3 velocidadLimitada = flatVelocity.normalized * movementSpeed;
            mRb.velocity = new Vector3(velocidadLimitada.x, mRb.velocity.y, velocidadLimitada.z);
        }
    }

    //--------------------------------------------------------------------------------------------

    private void MoverseConFuerza()
    {
        //Aplicamos una fuerza al RB del Player para moverlo
        mRb.AddForce(
            (mDirection.y * transform.forward + mDirection.x * transform.right).normalized * movementSpeed,
            ForceMode.Force
            );

    }

    //--------------------------------------------------------------------------------------------

    private void ControlarRotacion()
    {
        //Asignamos la sensibilidad del Mouse segun el GameManager
        //turnSpeed = 10;

        //Actualizamos constantemente la rotaci�n horizontal del Player en torno al Eje Y
            transform.Rotate(
                Vector3.up,
                turnSpeed * Time.deltaTime * mDeltaLook.x
            );

            ////Actualizamos constantemente la rotaci�n vertical del Player en torno al Eje X
            cameraMain.GetComponent<CameraMovement>().RotateUpDown(
                -turnSpeed * Time.deltaTime * mDeltaLook.y
            );
        
    }

    //--------------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos referencia a la Camara Principal (Vista de jugador)
        cameraMain = transform.Find("CameraHandler").Find("Main Camera");

        //Bloqueamos el Cursor para que este no sea visible
        Cursor.lockState = CursorLockMode.Locked;
    }

    //----------------------------------------------------------------------

    void FixedUpdate()
    {
        MoverseConFuerza();
    }

    //-------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        ControlSpeed();

        ControlarRotacion();
    }
}
