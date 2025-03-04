using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_light : InteractableObject
{
    [SerializeField] private string[] arrInteractionsText = new string[2];

    [Header("Punto de Luz")]
    [SerializeField] private GameObject pointLight;

    //Flag de Luz activada
    private bool isEnabled;

    private void Awake()
    {
        isEnabled = false;
    }

    //--------------------------------------------------------------

    public override void EnableInteraction()
    {
        //Reproducimos el Sonido de Switch
        GetComponent<AudioSource>().Play();

        if (isEnabled)
        {
            pointLight.SetActive(false);
            isEnabled = false;

            //Asignamos el mensaje de interaccion inicial
            interactionMessage = arrInteractionsText[0];

            //Actualizando el texto mostrado.
            UIController.Instance.ShowNewInteractionInfo(interactionMessage);
        }
        else
        {
            pointLight.SetActive(true);
            isEnabled = true;
            //Asignamos el mensaje de interaccion secundario
            interactionMessage = arrInteractionsText[1];

            //Actualizando el texto mostrado
            UIController.Instance.ShowNewInteractionInfo(interactionMessage);
        }
    }

    //--------------------------------------------------------------

    void Start()
    {
        //Asignamos el mensaje de interaccion inicial
        interactionMessage = arrInteractionsText[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
