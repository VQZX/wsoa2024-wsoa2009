using UnityEngine;

public class PaddleController : MonoBehaviour
{
    /// <summary>
    /// Inputs for controlling upwards and downwards motion
    /// </summary>
    public KeyCode UpButton, DownButton;

    /// <summary>
    /// 5 units per second
    /// </summary>
    public float Speed = 5f;

    /// <summary>
    /// The reference for the upper bound and the lower bound
    /// </summary>
    public Transform UpperBoundary, LowerBoundary;

    /// <summary>
    /// To adjust where the paddle stops in relation to the boundary
    /// </summary>
    public float OffsetFromBoundary = 1;

    /// <summary>
    /// A means of controlling stopping input from the player
    /// </summary>
    private bool canMove;

    /// <summary>
    /// The current velocity of the paddle
    /// </summary>
    private Vector2 velocity;

    /// <summary>
    /// The default position for the paddles
    /// </summary>
    private Vector3 originalPosition;


    /// <summary>
    /// Returns private value of velocity to ensure that we can read the value of velocity
    /// but are not able to change it
    /// </summary>
    public Vector2 GetVelocity()
    {
        return velocity;
    }

    /// <summary>
    /// Called from GameManager to allow the Paddles to move
    /// by setting the variable canMove to true
    /// </summary>
    public void Initialise()
    {
        canMove = true;
    }

    /// <summary>
    /// Store the position of the paddles at the very beginning
    /// </summary>
    private void Awake()
    {
        originalPosition = transform.position;
    }

    /// <summary>
    /// See if the paddle is allowed to accept input and then process input
    /// </summary>
    private void Update()
    {
        if (!canMove)
        {
            return;
        }

        ProcessInput();
    }

    /// <summary>
    /// Stop processing input
    /// </summary>
    public void StopInput()
    {
        canMove = false;
    }

    /// <summary>
    /// Return paddle to original position
    /// </summary>
    public void ResetPaddle()
    {
        transform.position = originalPosition;
    }

    /// <summary>
    /// If UpButton pressed, move the paddle up. If the Down button is pressed move the paddle down.
    /// </summary>
    private void ProcessInput()
    {
        /*
         * There are several ways to perform input in Unity.
         * Please consider reading up on the different methods
         * ( Input.GetButton("Fire1"), Input.GetAxis("Vertical"), Input.GetKey(KeyCode.UpArrow) etc)
         * It is important to understand when the different methods are appropriate.
         * Consider which approach to use for your specific solution.
         */

        if (Input.GetKey(UpButton))
        {
            // The next upwards position
            // We are calculating the y-position every 
            float yPosition = transform.position.y + Time.deltaTime * Speed;

            // Ensure and validate the position only exists within the bounds of the court
            // If the yPosition is more than [the upper boundary - offsetFromBoundary],
            // return [the upper boundary - offsetFromBoundary].
            // If the y-position is less than [the lower boundary + offsetFromBoundary],
            // return [the lower boundary + offsetFromBoundary].
            // Otherwise, return the yPosition
            yPosition = Mathf.Clamp(yPosition, LowerBoundary.position.y + OffsetFromBoundary,
                UpperBoundary.position.y - OffsetFromBoundary);

            // Assign the newly calculated and validated position
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);

            // Set the velocity to be upwards
            velocity = Vector3.up * Speed;
        }
        else if (Input.GetKey(DownButton))
        {
            // The next downwards position
            float yPosition = transform.position.y - Time.deltaTime * Speed;

            // If the yPosition is more than [the upper boundary - offsetFromBoundary],
            // return [the upper boundary - offsetFromBoundary].
            // If the y-position is less than [the lower boundary + offsetFromBoundary],
            // return [the lower boundary + offsetFromBoundary].
            // Otherwise, return the yPosition
            yPosition = Mathf.Clamp(yPosition, LowerBoundary.position.y + OffsetFromBoundary,
                UpperBoundary.position.y - OffsetFromBoundary);

            // Assign the newly calculated and validated position
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);

            // Set the velocity to be downwards
            velocity = Vector3.down * Speed;
        }
    }
}
