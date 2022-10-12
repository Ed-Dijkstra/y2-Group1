using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorScript : MonoBehaviour
{
    GameObject rightDoor;
    GameObject leftDoor;
    bool opening = false;
    bool hasFired = false;
    float timer = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rightDoor = transform.GetChild(1).gameObject;
        leftDoor = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasFired)
        {
            if (opening)
            {
                if (timer > 0f)
                {
                    rightDoor.transform.Translate(new Vector3(0.05f, 0, 0));
                    leftDoor.transform.Translate(new Vector3(-0.05f, 0, 0));
                    timer -= 0.05f;
                } else
                {
                    hasFired = true;
                }
            }
        }
    }

    public void OnSelect()
    {
        opening = true;
    }
}
