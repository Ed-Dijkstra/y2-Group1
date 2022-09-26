using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class movementScript : MonoBehaviour
{
    List<InputDevice> leftHandedControllers = new List<InputDevice>();
    Vector2 triggerValue;
    GameObject cameraObject;
    [Tooltip("Speed of movement. 1 is really fast.")]
    [SerializeField]
    private float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //Stores all left-hand controllers in a list.
        var desiredCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);
        foreach (var device in leftHandedControllers)
        {
            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }
        //Camera object is the child of this object's child. Stored to use its rotation value later
        cameraObject = transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the first entry of the left-hand controller list and checks the input value of its joystick.
        if (leftHandedControllers[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out triggerValue) && !triggerValue.Equals(new Vector2(0, 0)))
        {
            triggerValue *= moveSpeed;
            //Moves the object in the direction the joystick is pressed relative to the camera rotation.
            transform.Translate(new Vector3(triggerValue.x, 0, triggerValue.y), cameraObject.transform);
        }
    }
}
