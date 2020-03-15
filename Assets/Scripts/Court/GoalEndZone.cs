using UnityEngine;

public class GoalEndZone : MonoBehaviour
{
    /// <summary>
    /// The id of the player
    /// </summary>
    [Header("1 for Player One, 2 for Player Two")]
    public int playerId = 1;

    private GameManager gameManager;

    /// <summary>
    /// Ensure this instance has access to the game manager
    /// </summary>
    public void Initialise(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    /// <summary>
    /// If the collision happened with the ball, then tell the game manager a goal was scored
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        BallController ballController = collider2D.gameObject.GetComponent<BallController>();
        if (ballController == null)
        {
            return;
        }
        gameManager.GoalScored(playerId);
    }
}

