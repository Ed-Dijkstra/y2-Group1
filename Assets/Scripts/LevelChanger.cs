
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int LevelToLoad;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Ending");
        }


    }

    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

}
