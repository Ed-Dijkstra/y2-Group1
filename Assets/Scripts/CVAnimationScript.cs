using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVAnimationScript : MonoBehaviour
{
    private bool canSeeCV;
    private Animator anim;

    // Start is called before the first frame update
    // On start I am getting the necessary components for the code to work
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnTriggerEnter will be checked on a box collider, so the animation does not play when player is far away but can see the object
    private void OnTriggerEnter(Collider other)
    {
        canSeeCV = true;
        Debug.Log("Collision has happened");
    }

    private void OnTriggerExit(Collider other)
    {
        canSeeCV = false;
        Debug.Log("Collision has stopped");
    }

    // OnBecameVisible will make sure the animation is played only when the camera is looking at the game object and the player is nearby
    private void OnBecameVisible()
    {
        anim.enabled = true;
        Debug.Log("Object is Visible");
    }

    private void OnBecameInvisible()
    {   

            anim.enabled = false;
 
    }
}
