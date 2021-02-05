using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnterBulding : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot Inside;
    [SerializeField] AudioMixerSnapshot Outside;
    int isPlayerInside=0;
    const float transitionduration = 0.4f;

    public void transitionToInside()
    {
        Inside.TransitionTo(transitionduration);
    }

    public void transitionToOutside()
    {
        Outside.TransitionTo(transitionduration);
    }



    void OnTriggerEnter(Collider other)
    {
        if (isPlayerInside == 1)
            isPlayerInside = 0;
        else
            isPlayerInside = 1;

        if (isPlayerInside ==1) 
            transitionToInside();
        else 
            transitionToOutside();
    }
}
