using UnityEngine;
using UnityEngine.UI;

public class ScoreControllerUI : MonoBehaviour
{
    public int MaxScore = 5;

    public Text playerOneScoreText, playerTwoScoreText;

    private int playerOneScore, playerTwoScore;

    // UI Functions
    public void UpdateScore()
    {
        playerOneScoreText.text = playerOneScore.ToString();
        playerTwoScoreText.text = playerTwoScore.ToString();
    }

    public void IncrementPlayerScore(int id)
    {
        if (id == 1)
        {
            playerOneScore++;
        }
        else if (id == 2)
        {
            playerTwoScore++;
        }

        UpdateScore();
    }
}
