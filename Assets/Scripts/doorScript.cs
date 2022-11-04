using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private bool locked = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!locked)
            {
                animator.SetBool("Opening", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Opening", false);
        }
    }

    public void SetLock(bool lockState)
    {
        locked = lockState;
    }

    
}
