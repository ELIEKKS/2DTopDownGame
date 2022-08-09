using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGShooting : MonoBehaviour
{
    public float explosionRadius;
    public float bulletSpeed;

    public Transform firePoint;
    public GameObject RPGbullet;
    public AudioClip shootSound;
    public AudioClip explosionSound;

    public int costToBuy;

    public RPGBulllet bulllet;
    private float timeBtwShots;
    public float startTimeBtwShots;


    public int amountOfBullets, magazineSize;


    void Start()
    {

        transform.parent.gameObject.GetComponent<WeaponSwap>().UpdateAmmoUI(gameObject);
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            timeBtwShots -= Time.deltaTime;
            if(amountOfBullets > 0 && timeBtwShots <= 0)
            {
                amountOfBullets--;
                timeBtwShots = startTimeBtwShots;
                Debug.Log("is shooting");
                Shoot();

                transform.parent.gameObject.GetComponent<WeaponSwap>().UpdateAmmoUI(gameObject);
            }
        }
    }

    public void Shoot()
    {
        RPGBulllet rpgBullet = bulllet.GetComponent<RPGBulllet>();
    
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y); 

        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        GameObject b = Instantiate(RPGbullet, firePoint.transform.position, Quaternion.identity);
        b.transform.position = Vector2.MoveTowards(transform.position, worldPoint2d, bulletSpeed * Time.deltaTime);

        if(b.transform.position.x == worldPoint2d.x && b.transform.position.y == worldPoint2d.y)
        {
            Debug.Log("Special point hit");
            rpgBullet.Explode();
            AudioSource.PlayClipAtPoint(explosionSound, b.transform.position);
        }
    
    }

    void OnDrawGizmosSelected()
    {
        if(firePoint == null)
        return;

        Gizmos.DrawWireSphere(gameObject.transform.position, explosionRadius);
    }
}
