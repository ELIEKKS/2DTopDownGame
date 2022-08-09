using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReffill : MonoBehaviour
{
    public AudioClip powerUp;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            GameObject player = other.gameObject;
            Health healthScript = player.GetComponent<Health>();
            if(healthScript)
            {
                healthScript.currentHealth = healthScript.maxHealth;
            }
            Destroy(gameObject);
        }
    }
}
