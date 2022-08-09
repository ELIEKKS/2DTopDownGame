using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadPowerUp : MonoBehaviour
{    
    public AudioClip powerUp;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            GameObject player = other.gameObject;
            Shooting shootingScript = player.GetComponentInChildren<Shooting>();
            if(shootingScript)
            {
                shootingScript.spread -= 0.02f;
            }
            Destroy(gameObject);
        }
    }
}
