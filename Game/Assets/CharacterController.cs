using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 moveDir;
    public float moveSpeed;
    public float dashAmount;
    private bool isDashButtonDown;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveY = 0f;
        float moveX = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f; 
        }

        moveDir = new Vector3(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed;

        if(isDashButtonDown)
        {
            rb.MovePosition(transform.position + moveDir * dashAmount);
            isDashButtonDown = false;
        }
    }
    
}
