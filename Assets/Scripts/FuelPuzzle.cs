using UnityEngine;

public class FuelPuzzle : MonoBehaviour
{
    public GameObject fuelTank;
    // Much like the SnapScript. It removes the fueltank when it enters the trigger and enables a pre-placed static one.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(fuelTank))
        {
            Destroy(other.gameObject);
            transform.GetChild(0).gameObject.SetActive(true);
            // This is the final puzzle, so it sends the Game a command to start the epilogue scene.
            GameEndingScript.CompletePuzzles();
            Debug.Log("Completed All puzzles");
        }
    }
}
