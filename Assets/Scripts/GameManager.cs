using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimerUI TimerUI;
    public CourtController CourtController;
    public ScoreControllerUI ScoreControllerUI;

    public float MaxTimeAmount = 3;

    private bool timerComplete = false;

    private float currentTime;


    public void GoalScored(int playerId)
    {
        CourtController.GoalScored(playerId);
        ScoreControllerUI.IncrementPlayerScore(playerId);
    }

    private void Start ()
    {
        ResetTimer(MaxTimeAmount);
    }

    private void Update ()
    {
        // Start timer first
        if ( !timerComplete )
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        if (currentTime <= 0)
        {
            timerComplete = true;
            TimerUI.Deactivate();

            StartGame();
        }
        currentTime -= Time.deltaTime;
        int roundedOffTimer = Mathf.CeilToInt(currentTime);
        TimerUI.SetTime(roundedOffTimer);

    }

    private void StartGame()
    {
        CourtController.BeginGame(this);
    }

    private void ResetTimer(float time)
    {
        TimerUI.Activate();
        currentTime = time;
    }

    
}
