using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScript : MonoBehaviour
{
    // This ID will be used to determine what object can snap into this place.
    [SerializeField]
    private int snapId;
    private Snappable snapObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // If the touching object has a Snappable component, and its ID is the same as this one's ID.
        // TODO: check for rotation so you have to rotate the object correctly before it snaps.
        if (other.gameObject.TryGetComponent<Snappable>(out snapObject) && snapObject.GetSnapId().Equals(snapId))
        {
            // Activate this objects child (the snapped object
            transform.GetChild(0).gameObject.SetActive(true);
            // Remove the other object
            Destroy(other.gameObject);
            PipePuzzle.CompletePipe(snapId);
        }
    }
}
