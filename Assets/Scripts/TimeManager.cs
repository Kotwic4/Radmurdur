using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    private float fixedTimeDiff = 0.02f;

    public GameObject startButton;
    public GameObject stopButton;

    public bool timeOnStart;


    // Use this for initialization
    private void Start()
    {
        if (timeOnStart)
        {
            StartTime();
        }
        else
        {
            StopTime();
        }
    }

    public void StopTime()
    {
        UpdateTime(0.0f);
        UpdateButtons(false);
    }

    public void StartTime()
    {
        UpdateTime(1.0f);
        UpdateButtons(true);
    }

    public void RestartTime()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateTime(float newTime)
    {
        Time.timeScale = newTime;
        Time.fixedDeltaTime = newTime * fixedTimeDiff;
    }

    private void UpdateButtons(bool timeRunning)
    {
        startButton.SetActive(!timeRunning);
        stopButton.SetActive(timeRunning);
    }
}
