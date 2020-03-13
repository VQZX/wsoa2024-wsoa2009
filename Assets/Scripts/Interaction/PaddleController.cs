using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode upButton, downButton;

    public float speed = 5f;

    private Rigidbody2D rigidbody2D;

    private bool canMove;

    private Vector2 velocity;

    public Vector2 GetVelocity()
    {
        return velocity;
    }

    public void Initialise()
    {
        canMove = true;
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!canMove)
        {
            return;
        }

        if (Input.GetKey(upButton))
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
            velocity = Vector3.up * speed;
        }
        else if (Input.GetKey(downButton))
        {
            transform.position -= Vector3.up * Time.deltaTime * speed;
            velocity = Vector3.down * speed;
        }
    }
}
