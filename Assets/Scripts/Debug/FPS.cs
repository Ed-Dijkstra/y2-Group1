using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    Text fpsText;
    public int refreshRate = 10;
    int frameCounter;
    float totalTime;
    void Start()
    {
        fpsText = GetComponent<Text>();
        frameCounter = 0;
        totalTime = 0;
    }
    void Update()
    {
        if (frameCounter == refreshRate)
        {
            float averageFPS = (1.0f / (totalTime / refreshRate));
            fpsText.text = averageFPS.ToString("F1");
            frameCounter = 0;
            totalTime = 0;
        } else
        {
            totalTime += Time.deltaTime;
            frameCounter++;
        }
    }
}
