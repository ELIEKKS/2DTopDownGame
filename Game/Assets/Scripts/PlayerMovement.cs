using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private GameObject shootingScript;
    private Vector3 moveDir;
    public float moveSpeed;
    public float dashAmount;
    public float timeBetweenDashes;
    private bool canDash = true;
    public AudioClip dashSound;
    public GameObject dashEffect;
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
            Dashing();
        }
    }

    void Dashing()
    {
        if(canDash)
        {
            StartCoroutine(dash());

        }
    }

    IEnumerator dash()
    {
        canDash = false;
        AudioSource.PlayClipAtPoint(dashSound, transform.position);
        GameObject _dashEffect = Instantiate(dashEffect, transform.position, transform.rotation);
        Destroy(_dashEffect, 5f);
        rb.MovePosition(transform.position + moveDir * dashAmount);
        yield return new WaitForSeconds(timeBetweenDashes);
        canDash = true;
    }



    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed;
    }
}
