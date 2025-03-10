using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [HideInInspector] public string interactionMessage;

    public abstract void EnableInteraction();
}
