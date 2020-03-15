using System;
using UnityEngine;
using UnityEngine.UI;

public class OutcomeUI : MonoBehaviour
{
    /// <summary>
    /// The text to display the message to
    /// </summary>
    public Text OutputText;

    /// <summary>
    /// The instance of the game manager
    /// </summary>
    public GameManager GameManager;

    /// <summary>
    /// The format we use to output the text
    /// </summary>
    public string format = "Player {0} Wins with {1} points. \n\n\n Player {2} loses with {1} points.";
    
    /// <summary>
    /// Activate with the the game outcome data, and set the text based on the incoming data
    /// </summary>
    public void Activate(int winningPlayer, int winningPlayerScore, int losingPlayer, int losingPlayerScore)
    {
        gameObject.SetActive(true);
        string output = 
            string.Format(format, winningPlayer, winningPlayerScore, losingPlayer, losingPlayerScore);
        OutputText.text = output;
    }

    /// <summary>
    /// Restarts a new game, called through Unity Event OnButtonClicked
    /// </summary>
    public void NewGamePressed()
    {
        GameManager.NewGame();
    }

    /// <summary>
    /// Hide the UI
    /// </summary>
    public void Deactivate()
    {
        gameObject.SetActive(false);

    }
}
