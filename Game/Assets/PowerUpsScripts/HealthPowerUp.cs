using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public AudioClip powerUp;
    public HealthBar healthBar;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            GameObject player = other.gameObject;
            Health healthScript = player.GetComponent<Health>();
            if(healthScript)
            {
                healthScript.IncreaseMaxHealth(10);
                if(healthScript.currentHealth > healthScript.maxHealth / 2)
                {
                    healthScript.currentHealthText.text = healthScript.currentHealth.ToString();
                    Destroy(gameObject);
                }
                else
                {
                    healthScript.currentHealth = healthScript.maxHealth / 2;
                    healthScript.currentHealthText.text = healthScript.currentHealth.ToString();
                    if(healthBar != null)
                    healthBar.SetHealth(healthScript.currentHealth);
                    Destroy(gameObject);
                }
                
            }
        }
    }
}
