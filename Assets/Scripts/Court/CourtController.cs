using UnityEngine;

public class CourtController : MonoBehaviour
{
    /// <summary>
    /// Paddle to the right
    /// </summary>
    public PaddleController PaddleOne;

    /// <summary>
    /// Goal End Zone to the right
    /// </summary>
    public GoalEndZone EndZoneOne;

    /// <summary>
    /// Paddle to the left
    /// </summary>
    public PaddleController PaddleTwo;

    /// <summary>
    /// Goal End Zone to left
    /// </summary>
    public GoalEndZone EndZoneTwo;

    /// <summary>
    /// The current ball being used
    /// </summary>
    public BallController CurrentBall;

    /// <summary>
    /// Initalise the ball, the paddles and the end zones
    /// </summary>
    public void BeginGame(GameManager gameManager)
    {
        CurrentBall.InitialiseBall();
        PaddleOne.Initialise();
        PaddleTwo.Initialise();

        EndZoneOne.Initialise(gameManager);
        EndZoneTwo.Initialise(gameManager);
    }

    /// <summary>
    /// Reset the ball to the center when a player has scored
    /// </summary>
    /// <param name="playerId">
    /// The id of the player that scored. 1 for Player One, 2 for Player Two.
    /// </param>
    public void GoalScored(int playerId)
    {
        CurrentBall.BallReset(playerId);
    }

    /// <summary>
    /// Stop any interaction on the ball, and the paddles
    /// </summary>
    public void FreezeObjects()
    {
        CurrentBall.Freeze();

        PaddleOne.StopInput();
        PaddleTwo.StopInput();
    }

    /// <summary>
    /// When a new game has begun, reset the paddles to the center
    /// </summary>
    public void ResetCourt()
    {
        PaddleOne.ResetPaddle();
        PaddleTwo.ResetPaddle();
    }
}
