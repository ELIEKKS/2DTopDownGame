using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public AudioClip deathSound;
    public WeightedRandomList<GameObject> drop;
    public int deathValue;
    public GameObject killCount;


    void Start()
    {
        

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject itemToDrop = drop.GetRandom();
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Instantiate(itemToDrop, transform.position, transform.rotation);
            KillCount killCount = GameObject.FindObjectOfType(typeof(KillCount)) as KillCount;
            killCount.AddDeath(deathValue);
            
        }
    }
}
