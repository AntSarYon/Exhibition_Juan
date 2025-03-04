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

    //--------------------------------------------------

    void Awake()
    {
        Instance = this;
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
