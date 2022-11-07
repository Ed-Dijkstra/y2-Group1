using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovementScript : MonoBehaviour
{
    // For storing the controllers and getting input data.
    private List<InputDevice> leftHandedControllers = new List<InputDevice>();
    // Input vector for left joystick.
    private Vector2 joystickValue;
    // Store the camera to get it's direction values later.
    private GameObject cameraObject;
    // Speed of movement.
    [SerializeField]
    private float moveSpeed = 11f;
    private CharacterController cc;
    private Vector3 moveVector = Vector3.zero;
    void Start()
    {
        //Stores all left-hand controllers in a list so I can check for their inputs later.
        var desiredCharacteristicsLeft = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsLeft, leftHandedControllers);
        foreach (var device in leftHandedControllers)
        {
            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }
        //Camera object is the child of this object's child. Stored to use its direction vector later
        cameraObject = transform.GetChild(0).GetChild(0).gameObject;
        cc = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        // Get the first entry of the left-hand controller list and checks the input values of its joystick.
        if (leftHandedControllers[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickValue) && !joystickValue.Equals(new Vector2(0, 0)))
        {
            // I store the forward and right vectors of the camera and align the input joystick vector with them. This is the direction the player moves in.
            var cameraForward = new Vector3(cameraObject.transform.forward.x, cameraObject.transform.forward.y, cameraObject.transform.forward.z);
            var cameraRight = new Vector3(cameraObject.transform.right.x, cameraObject.transform.right.y, cameraObject.transform.right.z);
            moveVector = (moveSpeed * (cameraForward * joystickValue.y + cameraRight * joystickValue.x).normalized);
        } else
        {
            // If there are no inputs, the player shouldn't move.
            moveVector = Vector3.zero;
        }
        // Movement with gravity is different from movement without. Luckily, this is an easy fix, as the CharacterController method SimpleMove() automatically removes vertical movement whereas Move() doesn't.
        // I only need to use Time.deltaTime, as SimpleMove() automatically applies is, where Move() doesn't.
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
