using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{

[HideInInspector]
    public Health player;
    public int costToBuy;

    void Start()
    {
        player = GetComponentInParent<Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Health healthScript = player.GetComponent<Health>();
            //Heal Player
            int FullHeal = healthScript.maxHealth - healthScript.currentHealth;
            healthScript.AddHealth(FullHeal);
        }
    }
}
