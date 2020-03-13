using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 firstDirection;

    public float speed = 8f;

    private Rigidbody2D rigidbody2D;

    private Vector3 originalPosition;

    public void InitialiseBall()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        rigidbody2D.velocity = firstDirection * speed;
    }

    public void BallReset (int playerWhoScored )
    {
        Vector3 resetDirection = Vector3.down;
        if (playerWhoScored == 1)
        {
            resetDirection = Vector3.right;
        }
        else if (playerWhoScored == 2)
        {
            resetDirection = Vector3.left;
        }

        transform.position = originalPosition;
        rigidbody2D.velocity = resetDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        PaddleController paddle = collision2D.gameObject.GetComponent<PaddleController>();
        if (paddle != null)
        {
            AddPaddleVelocityToBall(paddle);
        }
    }

    private void AddPaddleVelocityToBall(PaddleController paddle)
    {
        float xVelocity = rigidbody2D.velocity.x;
        float yVelocity = paddle.GetVelocity().y;

        /*
            Make sure to explain normalisation of vectors
            This is to ensure that ball only ever has a speed based on speed we set in our variable
        */
        Vector3 newVelocity = new Vector3(xVelocity, yVelocity);
        newVelocity = newVelocity.normalized;
        newVelocity *= speed;
        rigidbody2D.velocity = newVelocity;
    }
}
