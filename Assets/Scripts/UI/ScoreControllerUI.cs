using UnityEngine;
using UnityEngine.UI;

public class ScoreControllerUI : MonoBehaviour
{
    /// <summary>
    /// The score before a player wins
    /// </summary>
    public int MaxScore = 5;

    /// <summary>
    /// For displaying the player one text score
    /// </summary>
    public Text playerOneScoreText;

    /// <summary>
    /// For displaying the player two text score
    /// </summary>
    public Text playerTwoScoreText;

    /// <summary>
    /// The current instance of the Game Manager
    /// </summary>
    public GameManager GameManager;

    /// <summary>
    /// The actual scores of the two players
    /// </summary>
    private int playerOneScore, playerTwoScore;


    /// <summary>
    /// Display the score
    /// </summary>
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

        // Display the score to the screen
        UpdateScore();

        // When the either score is equal or greater than the max score,
        // tell the game manager who won, and with what score
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
    /// Return the scores to 0, and display the new score (0 for player 1, 0 for player 2) to the screen
    /// </summary>
    public void ResetScore()
    {
        playerOneScore = playerTwoScore = 0;
        UpdateScore();
    }
}
