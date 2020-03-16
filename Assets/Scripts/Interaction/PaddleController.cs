using UnityEngine;

public class PaddleController : MonoBehaviour
{
    /// <summary>
    /// Inputs
    /// </summary>
    public KeyCode UpButton, DownButton;

    /// <summary>
    /// 5 units for second
    /// </summary>
    public float Speed = 5f;

    /// <summary>
    /// The reference for the upper bound and the lower bound
    /// </summary>
    public Transform upperBoundary, lowerBoundary;

    /// <summary>
    /// To adjust where the paddle stops in relation to the boundary
    /// </summary>
    public float offsetFromBoundary = 1;

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
    /// but not able to change it
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

        HandleInput();
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
    private void HandleInput()
    { 
        if (Input.GetKey(UpButton))
        {
            // The next upwards position
            float yPosition = CalculateUpPosition();

            // Ensure and validate the position only exists within the bounds of the court
            yPosition = ClampPaddleBetweenBoundaries(yPosition);

            // Assign the newly calculated and validated position
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);

            // Set the velocity to be upwards
            velocity = Vector3.up * Speed;

        }
        else if (Input.GetKey(DownButton))
        {
            // The next upwards position
            float yPosition = CalculateDownPosition();

            // Ensure and validate the position only exists within the bounds of the court
            yPosition = ClampPaddleBetweenBoundaries(yPosition);

            // Assign the newly calculated and validated position
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);

            // Set the velocity to be downwards
            velocity = Vector3.down * Speed;
        }

    }
    
    /// <summary>
    /// The current y-position minus speed * Time.deltaTime.
    /// Multiply by Time.deltaTime to ensure the calculation is per-frame, not per-second
    /// </summary>
    private float CalculateDownPosition()
    {
        return transform.position.y - Time.deltaTime * Speed;
    }

    /// <summary>
    /// If the yPosition is more than [the upper boundary - offsetFromBoundary],
    /// return [the upper boundary - offsetFromBoundary].
    /// If the y-position is less than [the lower boundary + offsetFromBoundary],
    /// return [the lower boundary + offsetFromBoundary].
    /// Otherwise, return the yPosition
    /// </summary>
    private float ClampPaddleBetweenBoundaries(float yPosition)
    {
        return Mathf.Clamp(yPosition, lowerBoundary.position.y + offsetFromBoundary, 
            upperBoundary.position.y - offsetFromBoundary);
    }

    /// <summary>
    /// The current y-position plus speed * Time.deltaTime.
    /// Multiply by Time.deltaTime to ensure the calculation is per-frame, not per-second
    /// </summary>
    private float CalculateUpPosition()
    {
        float yPosition;
        yPosition = transform.position.y + Time.deltaTime * Speed;
        return yPosition;
    }
}
