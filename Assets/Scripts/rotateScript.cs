using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class rotateScript : MonoBehaviour
{
    // List to store the right-hand controller
    private List<InputDevice> rightHandedControllers = new List<InputDevice>();
    private Vector2 triggerValue;
    private bool gripValue;
    [SerializeField]
    private float rotateSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //Stores all right-hand controllers in a list.
        var desiredCharacteristicsRight = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsRight, rightHandedControllers);
        foreach (var device in rightHandedControllers)
        {
            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Only run this (look around) if the grip button is not being pressed.
        if (rightHandedControllers[0].TryGetFeatureValue(CommonUsages.gripButton, out gripValue) && !gripValue)
        {
            // Get the first entry of the right-hand controller list and checks the input value of its joystick.
            if (rightHandedControllers[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out triggerValue) && !triggerValue.Equals(new Vector2(0, 0)))
            {
                // Modiefies the y rotation of the camera if the right joystick is used (look left and right)
                triggerValue.x *= rotateSpeed;
                var currentRotation = transform.eulerAngles;
                var newY = currentRotation.y + triggerValue.x;
                transform.eulerAngles = new Vector3(currentRotation.x, newY, currentRotation.z);
            }
        }
    }
}
