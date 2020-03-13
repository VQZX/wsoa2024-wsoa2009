using UnityEngine;

public class CourtController : MonoBehaviour
{
    public PaddleController PaddleOne;
    public GoalEndZone EndZoneOne;

    public PaddleController PaddleTwo;
    public GoalEndZone EndZoneTwo;

    public BallController CurrentBall;

    public void BeginGame(GameManager gameManager)
    {
        CurrentBall.InitialiseBall();
        PaddleOne.Initialise();
        PaddleTwo.Initialise();

        EndZoneOne.Initialise(gameManager);
        EndZoneTwo.Initialise(gameManager);
    }

    public void GoalScored(int playerId)
    {
        CurrentBall.BallReset(playerId);
    }
}
