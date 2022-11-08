using UnityEngine;

public class SnapScript : MonoBehaviour
{
    // This ID will be used to determine what object can snap into this place.
    [SerializeField]
    private int snapId;
    // Field to store the collider.
    private Snappable snapObject;
    void OnTriggerEnter(Collider other)
    {
        // If the touching object has a Snappable component, and its ID is the same as this one's ID.
        if (other.gameObject.TryGetComponent<Snappable>(out snapObject) && snapObject.GetSnapId().Equals(snapId))
        {
            // Activate this objects child (the snapped object).
            transform.GetChild(0).gameObject.SetActive(true);
            // Remove the other object.
            Destroy(other.gameObject);
            // Send a message to the PipePuzzle component on the Game object; this will unlock the door once all four pipes have been repaired.
            PipePuzzle.CompletePipe(snapId);
        }
    }
}
