using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{   
    public void RemoveMe()
    {
      
        {
            Debug.Log("Remove function in being called on " + name);
            Destroy(gameObject);
        }
    }

}
