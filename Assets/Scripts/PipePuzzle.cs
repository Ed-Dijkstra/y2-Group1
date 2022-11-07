using UnityEngine;

public class PipePuzzle : MonoBehaviour
{
    // Booleans to track which of the pipe parts have been repaired
    private static bool pipe1 = false;
    private static bool pipe2 = false;
    private static bool pipe3 = false;
    private static bool pipe4 = false;
    // The door to unlock
    public GameObject doorObject;
    private static DoorScript door;
    private void Start()
    {
        door = doorObject.GetComponent<DoorScript>();
    }
    private static void CheckPipes()
    {
        // Unlocks the door if all pipes have been repaired.
        if (pipe1 && pipe2 && pipe3 && pipe4)
        {
            door.SetLock(false);
        }
    }
    public static void CompletePipe(int i)
    {
        // Checks the given pipe off as repaired, then checks whether the puzzle is complete.
        if (i == 1)
        {
            pipe1 = true;
        }
        if (i == 2)
        {
            pipe2 = true;
        }
        if (i == 3)
        {
            pipe3 = true;
        }
        if (i == 4)
        {
            pipe4 = true;
        }
        CheckPipes();
    }
}
