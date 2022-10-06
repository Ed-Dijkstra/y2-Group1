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
                OpenDoor(leftDoor, "left");
                OpenDoor(rightDoor, "right");
                hasFired = true;
            }
        }
    }

    void OpenDoor(GameObject door, string direction)
    {
        // 2.5 == right, -2.5 == left
        float directionInt = 2.5f;
        if (direction.Equals("left"))
        {
            directionInt *= -1;
        }
        door.transform.Translate(new Vector3(directionInt, 0, 0));
    }

    public void OnSelect()
    {
        opening = true;
    }
}
