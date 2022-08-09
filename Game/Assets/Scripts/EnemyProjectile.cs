using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    public GameObject bombPrefab;
    public int bulletDamage;

    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y);
        {
            //DestroyProjectile();
            Destroy(gameObject, 2f);
            
            //Create a Bomb at the current Position
            //Destroy this bullet
        }
    }

    private void FixedUpdate() {
        Destroy(gameObject, 5);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            var healthComponent = other.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(bulletDamage);
            }

            DestroyProjectile();
        }    
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
