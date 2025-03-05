using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Header("Interaction Text")]
    [SerializeField] private TextMeshProUGUI txtInteractionInfo;

    [Header("Dialogue Text")]
    [SerializeField] private TextMeshProUGUI txtDialogue;

    //Flag de dialogo a habilitado
    public bool HasDialogueEnabled;

    private Animator mAnimator;
    private AudioSource mAudioSource;

    //--------------------------------------------------

    void Awake()
    {
        Instance = this;

        //Obtencion de referencia a componentes
        mAnimator = GetComponent<Animator>();
        mAudioSource = GetComponent<AudioSource>();

        //iniciamos con flag de dialogo desactivado
        HasDialogueEnabled = false;
    }

    //--------------------------------------------------

    public void InteractWithDialogue()
    {
        //DEPENDIENDO DE IS EL fLAG DE DIALOGO ESTA ACTIVO, O NO

        if (HasDialogueEnabled)
        {
            //Desactivamos el flag de dialogo 
            HasDialogueEnabled = false;

            //Reproducimos la animacion de CERRAR DIALOGO
            mAnimator.Play("HideDialogue");
        }
        else
        {
            //Activamos el flag de dialogo
            HasDialogueEnabled = true;

            //Reproducimos la animacion de ABRIR DIALOGO
            mAnimator.Play("ShowDialogue");
        }
    }

    //--------------------------------------------------

    public void PlayDialogueSound()
    {
        mAudioSource.Play();
    }

    //--------------------------------------------------

    public void UpdateDialogueText(string newDialogueText)
    {
        //Actualizamos el Dialogo del Panel de Dialogo
        txtDialogue.text = newDialogueText;
    }

    //--------------------------------------------------

    void Start()
    {
        //Desactivamos el GO de texto de interaccion
        HideInteractionInfo();
    }

    //--------------------------------------------------

    public void ShowNewInteractionInfo(string interactionInfo)
    {
        //ACTUALIZAMOS EL TEXTO CON LA interaccion correspondiente
        txtInteractionInfo.text = interactionInfo;

        //Activamos el texto de Interaccion
        txtInteractionInfo.gameObject.SetActive(true);
    }

    //--------------------------------------------------

    public void HideInteractionInfo()
    {
        //Ocultamos el texto de Interaccion
        txtInteractionInfo.gameObject.SetActive(false);
    }
}
