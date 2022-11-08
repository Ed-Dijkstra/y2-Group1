using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    // Lock boolean - door won't open if it's locked. Serializable so it can be different for each door.
    [SerializeField]
    private bool locked = false;
    // Audio source for door-open sound.
    private AudioSource source;
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        // If the collider is a player, open the door.
        if (other.CompareTag("Player"))
        {
            if (!locked)
            {
                animator.SetBool("Opening", true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // If the collider leaving is a player, close the door again.
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Opening", false);
        }
    }
    public void SetLock(bool lockState)
    {
        locked = lockState;
    }
    public void PlaySound()
    {
        // Plays the door-open sound. This is triggered within the animator.
        source.Play();
    }
}
