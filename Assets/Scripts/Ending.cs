using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Ending");
        }
    }
}
