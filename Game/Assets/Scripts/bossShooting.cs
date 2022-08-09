using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShooting : MonoBehaviour
{
    private Transform player;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip shootSound;

    public float stoppingDistance;
    public float retreatDistance;   

    private float timeBtwShots;
    public float startTimeBtwShots;

    public int amountOfBullets, magazineSize;
    public float bulletSpeed;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {

        if(player && timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
            Moving();
            Shooting();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    public void Moving()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, bulletSpeed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
    }

    public void Shooting()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);

        GameObject b = Instantiate(bulletPrefab, firePoint.transform.position,firePoint.rotation);
        Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(player.position.x, player.position.y);
        brb.velocity = dir * bulletSpeed;
        Destroy(b, 5);
    }
}
