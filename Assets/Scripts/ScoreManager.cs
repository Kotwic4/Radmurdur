using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int OneStarScore = 0;
    public int TwoStarScore = 0;
    public int ThreeStarScore = 0;
    public bool visibileScore = true;

    public int currentScore = 0;

    public int goodSoundGain = 10;
    public int badSoundLoss = 5;
    public int missSoundloss = 1;

    public GameObject scoreBoard;

    public GameObject gameController;

    private void UpdateText()
    {
        GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();
    }

    public void goodSound()
    {
        currentScore += goodSoundGain;
        UpdateText();
    }

    public void badSound()
    {
        currentScore -= badSoundLoss;
        UpdateText();
    }

    public void missSound()
    {
        currentScore -= missSoundloss;
        UpdateText();
    }

    public void finishLevel()
    {
        int starNumber = 0;
        if (currentScore >= OneStarScore)
        {
            starNumber = 1;
        }
        if (currentScore > TwoStarScore)
        {
            starNumber = 2;
        }
        if (currentScore > ThreeStarScore)
        {
            starNumber = 3;
        }

        gameController.GetComponent<TimeManager>().StopTime();

        scoreBoard.SetActive(true);
        scoreBoard.GetComponent<Summary>().setStars(starNumber);
    }
}
