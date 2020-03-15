using UnityEngine;

public class BallController : MonoBehaviour
{
    /// <summary>
    /// The first direction we would like the ball to go into when the game starts
    /// </summary>
    public Vector2 FirstDirection;

    /// <summary>
    /// The max speed the ball is allowed to travel at
    /// </summary>
    public float MaxSpeed = 8f;

    /// <summary>
    /// The attached Rigidbody2D
    /// </summary>
    private Rigidbody2D rigidbody2D;

    /// <summary>
    /// The first position of the ball
    /// </summary>
    private Vector3 originalPosition;

    /// <summary>
    /// Called at the very beginning to ensure we have everything we need from the ball.
    ///     - Store the rigidbody2D
    ///     - Store the original position of the ball
    ///     - Normalise the FirstDirection vector, to ensure we have unit vector - a vector with a magnitude of 1
    ///     - Set the rigidbody velocity to FirstDirection multiplied by MaxSpeed
    /// </summary>
    public void InitialiseBall()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        FirstDirection = FirstDirection.normalized;
        rigidbody2D.velocity = FirstDirection * MaxSpeed;
    }

    /// <summary>
    /// Reset the position of the ball to its original position (usually the center)
    /// and sets its next direction to the player who conceded the point.
    /// </summary>
    /// <param name="playerWhoScored">The id of the player who score. 1 for Player One, 2 for Player 2.</param>
    public void BallReset (int playerWhoScored )
    {
        // Choose direction based on player who scored
        Vector3 resetDirection = Vector3.zero;
        if (playerWhoScored == 1)
        {
            resetDirection = Vector3.left;
        }
        else if (playerWhoScored == 2)
        {
            resetDirection = Vector3.right;
        }

        // Reset the ball to its original position
        transform.position = originalPosition;

        // Set the velocity to move in the direction of the player who conceded the point
        rigidbody2D.velocity = resetDirection * MaxSpeed;
    }

    /// <summary>
    /// Prevent any ball interactions
    /// </summary>
    public void Freeze()
    {
        transform.position = originalPosition;
        rigidbody2D.velocity = Vector3.zero;
    }

    /// <summary>
    /// If the ball hit a paddle, set the ball vertical velocity to be the paddles vertical velocity
    /// </summary>
    /// <param name="collision2D"></param>
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        PaddleController paddle = collision2D.gameObject.GetComponent<PaddleController>();
        if (paddle != null)
        {
            AddPaddleVelocityToBall(paddle);
        }
    }

    /// <summary>
    /// Set the balls vertical velocity to be the paddles, and then limit the ball speed to MaxSpeed
    /// </summary>
    private void AddPaddleVelocityToBall(PaddleController paddle)
    {
        // Ball horizontal velocity
        float xVelocity = rigidbody2D.velocity.x;

        // Paddle vertical velocity
        float yVelocity = paddle.GetVelocity().y;

        // Limit the speed of the ball to MaxSpeed
        Vector3 newVelocity = new Vector3(xVelocity, yVelocity);
        newVelocity = newVelocity.normalized;
        newVelocity *= MaxSpeed;
        rigidbody2D.velocity = newVelocity;
    }
}
