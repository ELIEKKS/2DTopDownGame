using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class bossHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public AudioClip deathSound;
    public WeightedRandomList<GameObject> drop;
    public int deathValue;
    public GameObject killCount;
    public GameObject bossHealthBarPrefab;


    


    void Start()
    {
        currentHealth = maxHealth;
        bossHealthBarPrefab = GameObject.FindWithTag("bossHealthBar");
        if(bossHealthBarPrefab)
        {
            bossHealthBarPrefab.SetActive(true);
            bossHealthBar bossHealthBarScript = bossHealthBarPrefab.GetComponent<bossHealthBar>();
            bossHealthBarScript.SetMaxHealth(maxHealth);
            bossHealthBarScript.SetHealth(currentHealth);
        }
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        bossHealthBarPrefab = GameObject.FindWithTag("bossHealthBar");
        bossHealthBar bossHealthBarScript = bossHealthBarPrefab.GetComponent<bossHealthBar>();
        Debug.Log("current health");
        bossHealthBarScript.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            bossHealthBarPrefab = GameObject.FindWithTag("bossHealthBar");
            bossHealthBarPrefab.SetActive(false);
            Destroy(gameObject);
            GameObject itemToDrop = drop.GetRandom();
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Instantiate(itemToDrop, transform.position, transform.rotation);
            KillCount killCount = GameObject.FindObjectOfType(typeof(KillCount)) as KillCount;
            killCount.AddDeath(deathValue);
            
        }
    }
}
