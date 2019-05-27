using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class TimeManager : MonoBehaviour
{
    private float fixedTimeDiff = 0.02f;

    public GameObject startButton;
    public GameObject stopButton;
    public GameObject warmUpCounter;

    public bool timeOnStart;
    public float warmUpTimeSeconds = 3f;


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

        warmUpCounter.GetComponent<WarmUpCounterManager>().Stop();
        GetComponent<AudioSource>().Stop();
    }

    public void StartTime()
    {
        UpdateTime(1.0f);
        UpdateButtons(true);

        warmUpCounter.GetComponent<WarmUpCounterManager>().StartCounting(warmUpTimeSeconds);
        GetComponent<AudioSource>().PlayDelayed(warmUpTimeSeconds);
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

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
