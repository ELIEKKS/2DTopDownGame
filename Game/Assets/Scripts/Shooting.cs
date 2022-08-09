using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip shootSound;

    public int costToBuy;

    private float timeBtwShots;
    public float startTimeBtwShots;


    public int amountOfBullets, magazineSize;
    public float spread, bulletSpeed;

    public GameObject player;

    void Start()
    {
        transform.parent.gameObject.GetComponent<WeaponSwap>().UpdateAmmoUI(gameObject);
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            timeBtwShots -= Time.deltaTime;
            if(amountOfBullets > 0 && timeBtwShots <= 0)
            {
                amountOfBullets--;
                timeBtwShots = startTimeBtwShots;
                Shoot();
                
                transform.parent.gameObject.GetComponent<WeaponSwap>().UpdateAmmoUI(gameObject);
            }
        }
    }





    void Shoot()
    {
        GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
        Vector2 dir = transform.rotation * Vector2.right;
        Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread,spread);
        brb.velocity = (dir + pdir)*bulletSpeed;
        Destroy(b, 5);
    }
}
