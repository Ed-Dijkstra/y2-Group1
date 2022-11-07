using UnityEngine;

public class FuelPuzzle : MonoBehaviour
{
    public GameObject fuelTank;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(fuelTank))
        {
            Destroy(other.gameObject);
            transform.GetChild(0).gameObject.SetActive(true);
            GameEndingScript.CompletePuzzles();
            Debug.Log("Completed All puzzles");
        }
    }
}
