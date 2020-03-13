using UnityEngine;

public class GoalEndZone : MonoBehaviour
{
    public int playerId = 1;

    private GameManager gameManager;

    public void Initialise(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

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

