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
    /// Reference to the Game Manager
    /// </summary>
    public GameManager GameManager;

    /// <summary>
    /// To hold the positions of the left and right goal zones
    /// </summary>
    public Transform LeftGoalZone, RightGoalZone;

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
    /// Check if the ball has passed the goal zones, if so, send score update to Game Manager
    /// </summary>
    private void Update()
    {
        if (transform.position.x < LeftGoalZone.position.x)
        {
            int playerId = 2;
            GameManager.GoalScored(playerId);

        }
        else if (transform.position.x > RightGoalZone.position.x)
        {
            int playerId = 1;
            GameManager.GoalScored(playerId);
        }
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
    public void PreventAnyBallInteractions()
    {
        transform.position = originalPosition;
        rigidbody2D.velocity = Vector3.zero;
    }

    /// <summary>
    /// If the ball hit a paddle, set the ball vertical velocity to be the paddles vertical velocity
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        PaddleController paddle = collision2D.gameObject.GetComponent<PaddleController>();

        // If the paddle does not exist (i.e. it is not attached to the gameObject, 
        // we DO NOT work with it. )
        // Prevents NullReferenceException Error
        // For more information see here: https://www.youtube.com/watch?v=Y8buHhKcjRc
        if (paddle != null)
        {
            AddPaddleVelocityToBall(paddle);
        }
    }

    /// <summary>
    /// Set the balls vertical velocity to be the paddles,
    /// and then limit the ball speed to MaxSpeed
    /// </summary>
    private void AddPaddleVelocityToBall(PaddleController paddle)
    {
        // Ball horizontal velocity
        float xVelocity = rigidbody2D.velocity.x;

        // Paddle vertical velocity
        float yVelocity = paddle.GetVelocity().y;

        if (yVelocity == 0)
        {
            return;
        }

        // Limit the speed of the ball to MaxSpeed
        Vector3 newVelocity = new Vector3(xVelocity, yVelocity);

        /*
         * When using vectors it is important to realise that they
         * are arrows, and have two major properties
         * 1. Magnitude (how long the arrow is)
         * 2. Direction (which way the arrow is pointing)
         *
         * When we Normalize an arrow (a vector), we ensure the length is 1 unit,
         * but maintain its direction.
         *
         *
         * Brackeys has a very useful explanation on Vectors for more information:
         *
         * https://www.youtube.com/watch?v=wXI9_olSrqo
         */

        newVelocity = newVelocity.normalized;
        
        // We assign our own magnitude to the vector, to ensure the velocity vector
        // Maintains a magnitude of MaxSpeed
        newVelocity *= MaxSpeed;

        // Assign the calculated velocity to rigidbody
        rigidbody2D.velocity = newVelocity;
    }
}
