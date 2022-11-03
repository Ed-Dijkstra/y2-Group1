using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovementScript : MonoBehaviour
{
    // For storing the controllers and getting input data
    private List<InputDevice> leftHandedControllers = new List<InputDevice>();
    private Vector2 triggerValue;
    private GameObject cameraObject;
    private bool gripValue;
    [Tooltip("Speed of movement. 1 is really fast.")]
    [SerializeField]
    private float moveSpeed = 0.1f;
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //Stores all left-hand controllers in a list.
        var desiredCharacteristicsLeft = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsLeft, leftHandedControllers);
        foreach (var device in leftHandedControllers)
        {
            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }
        //Camera object is the child of this object's child. Stored to use its rotation value later
        cameraObject = transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Don't run this if the grip button on the left controller is being held down.
        if (leftHandedControllers[0].TryGetFeatureValue(CommonUsages.gripButton, out gripValue) && !gripValue)
        {
            // Get the first entry of the left-hand controller list and checks the input value of its joystick.
            if (leftHandedControllers[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out triggerValue) && !triggerValue.Equals(new Vector2(0, 0)))
            {
                // modify the value so you don't go super fast
                var directionVector = new Vector3(triggerValue.x, 0, triggerValue.y);
                // Moves the object in the direction the joystick is pressed relative to the camera rotation.
                var Up = new Vector3(0f, rb.velocity.y, 0f);
                rb.velocity = (((cameraObject.transform.forward * directionVector.x + cameraObject.transform.right * directionVector.z).normalized * moveSpeed + Up) * Time.fixedDeltaTime);
            }
        }
    }
}
