using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snappable : MonoBehaviour
{
    // ID used to define what it will snap into. The snap object will have the same ID.
    [SerializeField]
    private int snapId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetSnapId()
    {
        return snapId;
    }
}
