using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundEmitter : MonoBehaviour
{
    public void PlayEngineStart()
    {
        GetComponent<AudioSource>().Play();
    }
}
