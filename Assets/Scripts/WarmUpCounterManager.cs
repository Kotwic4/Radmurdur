using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WarmUpCounterManager : MonoBehaviour
{
    public float warmUpTimeSeconds;

    public void Start()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public void StartCounting(float newWarmUpTimeSeconds)
    {
        warmUpTimeSeconds = newWarmUpTimeSeconds;
        Step();
    }

    public void Stop()
    {
        GetComponent<TextMeshProUGUI>().enabled = false;
        warmUpTimeSeconds = 0;
    }

    private void Step()
    {
        var fullSecond = Mathf.CeilToInt(warmUpTimeSeconds);
        if (fullSecond > 0)
        {
            GetComponent<TextMeshProUGUI>().text = fullSecond.ToString();
            GetComponent<TextMeshProUGUI>().enabled = true;

            warmUpTimeSeconds -= 1f;
            Invoke("Step", 1);
        }
        else
        {
            Stop();
        }
    }
}
