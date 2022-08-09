using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Health : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public TextMeshProUGUI currentHealthText;
    public AudioClip deathSound;
    public GameObject deathScreen;
    public AudioClip hitEffect;
    public HealthBar healthBar;

    public bool damagebreak = false;
    public float damagebreaktimer = 5f; 
    public float damagebreaktimertotal = 5f;  
    public bool colorchange = false; 
    public float colorchangetimer = 1f;
    public Color red; 
    public Color white;

    void Start()
    {
        
        damagebreaktimer = damagebreaktimertotal;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        healthBar.SetHealth(currentHealth);
        currentHealthText.text = currentHealth.ToString();
    }


    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        damagebreak = true;
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        currentHealthText.text = currentHealth.ToString();
        AudioSource.PlayClipAtPoint(hitEffect, transform.position);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }


     void Update () 
     { 

 
         if (damagebreaktimer <= 0) { 
             damagebreak = false;    
             damagebreaktimer = damagebreaktimertotal;
         }
 
         if (damagebreak) {
             damagebreaktimer -= 1 * Time.deltaTime; 
             colorchange = true;
         } 
 
         if (colorchange) { 
             
             StartCoroutine ("color"); 
             colorchange = false;
 
         } else { 
             GetComponent<SpriteRenderer> ().color = white;
         }
 
     } 
 
     IEnumerator color(){   
          {
             GetComponent<SpriteRenderer> ().color = red;     
             yield return new WaitForSeconds(0.3f); 
             GetComponent<SpriteRenderer> ().color = white;     
             yield return new WaitForSeconds(0.3f);  
 
         }
 
     }
}

