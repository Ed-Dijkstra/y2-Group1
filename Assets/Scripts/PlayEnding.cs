using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnding : MonoBehaviour
{
    public Animator animatorDoor;
    public Animator animatorLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animatorDoor.SetTrigger("Ending");
            animatorLight.SetTrigger("Ending");
        }
    }
}
