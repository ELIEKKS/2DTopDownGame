using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    private int direction;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
            }
            else
            {
                dashTime -= Time.deltaTime;
            }
        }
    }
}
