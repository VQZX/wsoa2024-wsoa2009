using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// UI controller to display the countdown timer
    /// </summary>
    public TimerUI TimerUI;

    /// <summary>
    /// The parent object with access to all the court components (ball, paddles, goals etc)
    /// </summary>
    public CourtController CourtController;

    /// <summary>
    /// The UI controller for keeping track of the score
    /// </summary>
    public ScoreControllerUI ScoreControllerUI;

    /// <summary>
    /// The pop-up at the end of a game that details the game events
    /// </summary>
    public OutcomeUI OutcomeUI;

    /// <summary>
    /// The countdown timer amount
    /// </summary>
    public float MaxTimeAmount = 3;

    /// <summary>
    /// A flag to check if the timer has completed
    /// </summary>
    private bool timerComplete = false;

    /// <summary>
    /// The current count down timer timer
    /// </summary>
    private float currentTime;

    /// <summary>
    /// Called when a player wins a game
    /// </summary>
    public void PlayerWins(int winningPlayer, int winningPlayerScore, int losingPlayer, int losingPlayerScore)
    {
        OutcomeUI.Activate(winningPlayer, winningPlayerScore, losingPlayer, losingPlayerScore);

        // Freeze Objects
        CourtController.StopObjectsInteraction();
    }

    /// <summary>
    /// Called when a player scores
    /// </summary>
    public void GoalScored(int playerId)
    {
        CourtController.GoalScored(playerId);
        ScoreControllerUI.IncrementPlayerScore(playerId);
    }

    /// <summary>
    /// Resets all the components of the game
    /// </summary>
    public void NewGame()
    {
        ScoreControllerUI.ResetScore();
        ResetTimer(MaxTimeAmount);
        OutcomeUI.Deactivate();
        CourtController.ResetCourt();
    }

    /// <summary>
    /// begins the countdown timer at the beginning
    /// </summary>
    private void Start ()
    {
        ResetTimer(MaxTimeAmount);
    }

    /// <summary>
    /// Updates the timer if it is still running
    /// </summary>
    private void Update ()
    {
        // Start timer first
        if ( !timerComplete )
        {
            UpdateTimer();
        }
    }

    /// <summary>
    /// Update the timer
    /// </summary>
    private void UpdateTimer()
    {
        // When timer is complete, begin the game
        if (currentTime <= 0)
        {
            timerComplete = true;
            TimerUI.Deactivate();

            StartGame();
        }

        // When timer is still active, decrement the time,
        // and update the user interface
        currentTime -= Time.deltaTime;
        int roundedOffTimer = Mathf.CeilToInt(currentTime);
        TimerUI.SetTime(roundedOffTimer);

    }

    /// <summary>
    /// Resets score and initialises the Court controller
    /// </summary>
    private void StartGame()
    {
        CourtController.BeginGame(this);
        ScoreControllerUI.UpdateScore();
    }

    /// <summary>
    /// Reset the countdown timer to some time to begin counting down from
    /// </summary>
    /// <param name="time"></param>
    private void ResetTimer(float time)
    {
        TimerUI.Activate();
        TimerUI.SetTime(time);
        currentTime = time;
        timerComplete = false;
    }

    
}
