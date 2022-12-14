using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{
    public Color startColor = Color.green;
    public Color endColor = Color.black;
    [Range(0, 10)]
    public float speed = 1;
    private Renderer renderer;
    private Destroyable destroyable;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        GameObject star = args.interactableObject.GetAttachTransform(args.interactorObject).gameObject;
        if (star.TryGetComponent<Destroyable>(out destroyable))
        {
            renderer = star.GetComponent<Renderer>();
            renderer.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
        }
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        GameObject star = args.interactableObject.GetAttachTransform(args.interactorObject).gameObject;
        if (star.TryGetComponent<Destroyable>(out destroyable))
        {
            renderer = star.GetComponent<Renderer>();
            renderer.material.color = Color.white;
        }
    }
}
