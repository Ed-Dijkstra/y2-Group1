using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingScript : MonoBehaviour
{
    private static bool puzzlesComplete = false;
    public int scene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && puzzlesComplete)
        {
            SceneManager.LoadScene(scene);
        } else if (other.CompareTag("Player"))
        {
            Debug.Log("puzzles not yet compete");
        }
    }

    public static void CompletePuzzles()
    {
        puzzlesComplete = true;
    }
}
