using UnityEngine;
using UnityEngine.UI;

public class ScoreControllerUI : MonoBehaviour
{
    /// <summary>
    /// The score before a player wins
    /// </summary>
    public int MaxScore = 5;

    /// <summary>
    /// The respective texts for displaying the two players scores
    /// </summary>
    public Text playerOneScoreText, playerTwoScoreText;

    /// <summary>
    /// The current instance of the Game Manager
    /// </summary>
    public GameManager GameManager;

    /// <summary>
    /// The actual scores of the two players
    /// </summary>
    private int playerOneScore, playerTwoScore;


    // Display the scores
    public void UpdateScore()
    {
        playerOneScoreText.text = playerOneScore.ToString();
        playerTwoScoreText.text = playerTwoScore.ToString();
    }

    /// <summary>
    /// Add 1 to one of the player's score.
    /// If the score is more or equal to the <see cref="MaxScore"/>, then signal that they have won.
    /// </summary>
    /// <param name="id">
    /// 1 for Player One, 2 for Player Two
    /// </param>
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

        if (playerOneScore >= MaxScore)
        {
            GameManager.PlayerWins(1, playerOneScore, 2, playerTwoScore);
        }
        else if (playerTwoScore >= MaxScore)
        {
            GameManager.PlayerWins(2, playerTwoScore, 1, playerOneScore);
        }
    }

    /// <summary>
    /// Return the scores to 0, and display
    /// </summary>
    public void ResetScore()
    {
        playerOneScore = playerTwoScore = 0;
        UpdateScore();
    }
}
