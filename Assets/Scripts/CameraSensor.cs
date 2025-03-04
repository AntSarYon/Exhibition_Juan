using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSensor : MonoBehaviour
{
    [Header("Layer de interactuables")]
    [SerializeField] private LayerMask InteractableLayer;

    [Header("Referencia a PlayerController")]
    [SerializeField] private PlayerController pController;

    //Flag de Interaccion a la vista
    private bool bInteractionInSight;

    //---------------------------------------------------------

    void Awake()
    {
        //Iniciamos sin interacciones a la vista
        bInteractionInSight = false;
    }

    //---------------------------------------------------------
    void Update()
    {
        RaycastHit InteractionHit;
        bool wasInteractionHit = Physics.Raycast(transform.position, transform.forward, out InteractionHit, 2.5f, InteractableLayer);

        //Si estamos tocando una interaccion
        if (wasInteractionHit)
        {
            Debug.Log("Interaction percibida");

            //Si ya habia una interaccion a al vista antes (esta misma)
            if (bInteractionInSight)
            {
                //No hacemos nada
            }

            //Si no estabamos detectando ninguna interaccion antes
            else
            {
                //Obtenemos referencia al Objeto de la interaccion
                GameObject percievedObject = InteractionHit.transform.gameObject;

                //Almacenamos su informacion de interaccion en el jugador
                InteractableObject interaction = percievedObject.GetComponent<InteractableObject>();
                pController.targetInteractableObject = interaction;

                //Mostramos el texto de interaccion, actualizando el texto segun corresponda.
                UIController.Instance.ShowNewInteractionInfo(interaction.interactionMessage);
            }
        }

        //Si no tocamos ninguna interaccion
        else
        {
            //Ocultamos informacion de interaccion
            UIController.Instance.HideInteractionInfo();

            if (pController.targetInteractableObject != null)
            {
                //Quitamos la referencia a un Target Interactuable del jugador
                pController.targetInteractableObject = null;
            }
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 2.5f);
    }
}
