using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RotateScript : MonoBehaviour
{
    // List to store the right-hand controller.
    private List<InputDevice> rightHandedControllers = new List<InputDevice>();
    // Field to store the input for the joystick.
    private Vector2 joystickValue;
    // The speed of rotation.
    [SerializeField]
    private float rotateSpeed = 1.5f;
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
    void FixedUpdate()
    {
        // Get the first entry of the right-hand controller list and checks the input value of its joystick.
        if (rightHandedControllers[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickValue) && !joystickValue.Equals(new Vector2(0, 0)))
        {
            // Modifies the y rotation of the camera if the right joystick is used (look left and right but not vertically)
            joystickValue.x *= rotateSpeed;
            var currentRotation = transform.eulerAngles;
            var newY = currentRotation.y + joystickValue.x;
            transform.eulerAngles = new Vector3(currentRotation.x, newY, currentRotation.z);
        }
    }
}
