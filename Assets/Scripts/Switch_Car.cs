using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Switch_Car : InteractableObject
{
    [SerializeField] private string InteractionsText;

    [Header("Punto de Luz")]
    [SerializeField] private Animator CarAnimator;

    //Flag de Luz activada
    private bool wasEnabled;

    //--------------------------------------------------

    private void Awake()
    {
        wasEnabled = false;
    }

    private void Start()
    {
        interactionMessage = InteractionsText;
    }

    //--------------------------------------------------------------

    public override void EnableInteraction()
    {
        //Si aun no ha sido activado
        if (!wasEnabled)
        {
            CarAnimator.Play("Move");

            wasEnabled = true;

            interactionMessage = "Esta interaccion ya fue activada";

            //Actualizando el texto mostrado.
            UIController.Instance.ShowNewInteractionInfo(interactionMessage);
        }
        else
        {
            
        }
    }

    
}
