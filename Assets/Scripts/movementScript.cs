using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovementScript : MonoBehaviour
{
    // For storing the controllers and getting input data
    private List<InputDevice> leftHandedControllers = new List<InputDevice>();
    // Input vector for left joystick
    private Vector2 joystickValue;
    private GameObject cameraObject;
    // Input bool for left grip button
    private bool gripValue;
    [Tooltip("Speed of movement. 1 is really fast.")]
    [SerializeField]
    private float moveSpeed = 1f;
    private CharacterController cc;
    private Vector3 moveVector = Vector3.zero;
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
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the first entry of the left-hand controller list and checks the input value of its joystick.
        if (leftHandedControllers[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickValue) && !joystickValue.Equals(new Vector2(0, 0)))
        {
            var cameraForward = new Vector3(cameraObject.transform.forward.x, cameraObject.transform.forward.y, cameraObject.transform.forward.z);
            var cameraRight = new Vector3(cameraObject.transform.right.x, cameraObject.transform.right.y, cameraObject.transform.right.z);        
            //rb.AddForce((cameraObject.transform.forward * joystickValue.y + cameraObject.transform.right * joystickValue.x).normalized * moveSpeed * Time.fixedDeltaTime - currentVelocity, ForceMode.VelocityChange);
            //rb.velocity = (cameraForward * joystickValue.y + cameraRight * joystickValue.x).normalized * moveSpeed * Time.fixedDeltaTime;
            moveVector = (moveSpeed * (cameraForward * joystickValue.y + cameraRight * joystickValue.x).normalized);
            // Moves the object in the direction the joystick is pressed relative to the camera rotation.
        } else
        {
            moveVector = Vector3.zero;
        }
        if (GameGravityScript.GetGravity())
        {
            cc.SimpleMove(moveVector);
        } else
        {
            moveVector *= Time.fixedDeltaTime;
            cc.Move(moveVector);
        }
    }
}
