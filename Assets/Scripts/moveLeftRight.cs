using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeftRight : MonoBehaviour
{
    private float timer = 5f;
    private float modifier = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(modifier, 0, 0));
        timer += 0.1f;
        if (timer > 10)
        {
            modifier *= -1;
            timer = 0;
        }
    }
}
