using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : InteractableObject
{

    [SerializeField] [TextArea] private string dialogueText;

    //-------------------------------------------------------

     void Awake()
    {
        interactionMessage = "Hablar con critico de arte.";
    }

    //------------------------------------------------------------

    void Start()
    {
        
    }

    //------------------------------------------------------------

    public override void EnableInteraction()
    {
        //Actualizamos el Texto del panel
        UIController.Instance.UpdateDialogueText(dialogueText);

        //Activamos la Interaccion del panel de dialogo
        UIController.Instance.InteractWithDialogue();
    }
}
