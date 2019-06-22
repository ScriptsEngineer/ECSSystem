using UnityEngine;

public class FPS : MonoBehaviour
{

    private int count;

    float timeA;
    public int fps;
    public int lastFPS;

    public GUIStyle textStyle;


    void Start()
    {
        timeA = Time.timeSinceLevelLoad;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad - timeA <= 1)
        {
            fps++;
        }
        else
        {
            lastFPS = fps + 1;
            timeA = Time.timeSinceLevelLoad;
            fps = 0;
        }
    }

    public void SetElementCount(int count)
    {
        this.count = count;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 5, 30, 30), "FPS " + lastFPS, textStyle);
        GUI.Label(new Rect(5, 35, 30, 30), "COUNT " + count, textStyle);
    }

}