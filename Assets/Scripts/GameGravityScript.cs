using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGravityScript : MonoBehaviour
{
    private static bool gravity = true;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private AudioSource gravityengine;
    public AudioClip engineStart;
    public AudioClip engineEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool GetGravity()
    {
        return gravity;
    }

    private void EnableGravity()
    {
        // Enables gravity on the player and in this object's boolean if it is not enalbed already.

            Physics.gravity = new Vector3(0f, -9.81f, 0f);
            gravity = true;
    }

    private void DisableGravity()
    {
        // Disables gravity on the player and in this object's boolean if it is not disabled already.
        if (gravity)
        {
            Physics.gravity = Vector3.zero;
            gravity = false;
        }
    }

    public void ToggleGravity()
    {
        if (gravity){
            DisableGravity();
            gravityengine.Stop();
            gravityengine.PlayOneShot(engineEnd);
        }
        else
        {
            if (!gravityengine.isPlaying)
            {
                EnableGravity();
                StartCoroutine(EngineStartup());
            }
        }
    }

    IEnumerator EngineStartup()
    {
        gravityengine.PlayOneShot(engineStart);
        yield return new WaitForSeconds(engineStart.length);
        gravityengine.Play();
    }
}
