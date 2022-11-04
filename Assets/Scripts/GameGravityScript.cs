using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGravityScript : MonoBehaviour
{
    private static bool gravity = true;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool GetGravity()
    {
        return gravity;
    }

    public void EnableGravity()
    {
        // Enables gravity on the player and in this object's boolean if it is not enalbed already.
        if (!gravity)
        {
            gravity = true;
        }
    }

    public void DisableGravity()
    {
        // Disables gravity on the player and in this object's boolean if it is not disabled already.
        if (gravity)
        {
            gravity = false;
        }
    }
}
