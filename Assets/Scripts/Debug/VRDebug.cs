using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRDebug : MonoBehaviour
{
    private List<InputDevice> rightHandedControllers = new List<InputDevice>();
    public GameObject UI;
    public GameObject UIAnchor;
    private bool UIActive;
    private bool trigger;
    private bool button;
    void Start()
    {
        var desiredCharacteristicsRight = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristicsRight, rightHandedControllers);
        UI.SetActive(true);
        UIActive = true;
    }
    void Update()
    {
        if (rightHandedControllers[0].TryGetFeatureValue(CommonUsages.triggerButton, out trigger) && trigger)
        {
            UIActive = !UIActive;
            UI.SetActive(UIActive);
        }
        if (UIActive)
        {
            UI.transform.position = UIAnchor.transform.position;
            UI.transform.eulerAngles = new Vector3(UIAnchor.transform.eulerAngles.x, UIAnchor.transform.eulerAngles.y, 0);
        }
        if (rightHandedControllers[0].TryGetFeatureValue(CommonUsages.primaryButton, out button) && button)
        {
            Debug.Log("Button pressed.");
        }
    }
}
