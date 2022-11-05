using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectClicker : MonoBehaviour
{
    public Animator animator;
    private Destroyable destScript;

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                if (hit.transform)
                {
                    PrintName(hit.transform.gameObject);
                    Destroyable destScript = hit.collider.GetComponent<Destroyable>();
                    if (destScript != null)
                    {
                        if (destScript.gameObject.name == "Leo.007 Heart")
                        {
                            animator.SetBool("Right", true);
                        }
                        else
                        {
                            animator.SetTrigger("WrongTrigger");
                            destScript.RemoveMe();
                        }
                    }
                }
            }
        }
    }
    */

    public void ActivateStar(SelectEnterEventArgs args)
    {
        GameObject star = args.interactableObject.GetAttachTransform(args.interactorObject).gameObject;
        var name = star.name;
        print(name);
        if (star.TryGetComponent(out destScript))
        {
            if (name == "Leo.007 Heart")
            {
                animator.SetBool("Right", true);
            } else
            {
                animator.SetTrigger("WrongTrigger");
                destScript.RemoveMe();
            }
        }
    }

    /*private void PrintName(GameObject go)
    {
        print(go.name);

    }
    */
}