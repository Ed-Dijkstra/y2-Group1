using UnityEngine;

public class Snappable : MonoBehaviour
{
    // ID used to define what it will snap into. The snap object will have the same ID.
    [SerializeField]
    private int snapId;

    public int GetSnapId()
    {
        return snapId;
    }
}
