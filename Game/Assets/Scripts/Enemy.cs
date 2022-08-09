using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;   



    public GameObject projectile;
    public Transform player;

    public AudioClip shootSound;
    public Rigidbody2D rb;


    private float timeBtwShots;
    public float startTimeBtwShots;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }


    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            ShootPlayer();
            Move();
        }
        else
        {

        }
    }

    void Move()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
    }

    void ShootPlayer()
    {


            if(timeBtwShots <= 0)
            {
            Instantiate(projectile, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            timeBtwShots = startTimeBtwShots;
            
            } else
            {
            timeBtwShots -= Time.deltaTime;
            } 
    }
}
