using System.Collections;
using UnityEngine;

public class GameGravityScript : MonoBehaviour
{
    // Static boolean that can be used by other objects to check the current gravity state.
    private static bool gravity = true;
    [SerializeField]
    // Three audio-based components to play sounds when the Gravity Engine is turned on.
    private AudioSource gravityengine;
    public AudioClip engineStart;
    public AudioClip engineEnd;

    public static bool GetGravity()
    {
        return gravity;
    }
    // Turns on gravity by rewriting the physics to their original values.
    private void EnableGravity()
    {
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        gravity = true;
    }
    // Turns off gravity by changing the physics' gravity vector to a zero vector.
    private void DisableGravity()
    {
        Physics.gravity = Vector3.zero;
        gravity = false;
    }
    // Turns gravity either off or on depending on the current state. Also plays the gravity engine sounds when needed.
    public void ToggleGravity()
    {
        if (gravity){
            DisableGravity();
            // Gravity engine sound should stop and its turn-off sound should play.
            StartCoroutine(EngineStartup());
        }
        else
        {
            if (!gravityengine.isPlaying)
            {
                EnableGravity();
                gravityengine.Stop();
                gravityengine.PlayOneShot(engineEnd);
            }
        }
    }

    // Coroutine to make sure the main gravity engine sound plays after its startup sound.
    IEnumerator EngineStartup()
    {
        gravityengine.PlayOneShot(engineStart);
        yield return new WaitForSeconds(engineStart.length);
        gravityengine.Play();
    }
}
