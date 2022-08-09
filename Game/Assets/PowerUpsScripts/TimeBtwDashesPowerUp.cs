using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBtwDashesPowerUp : MonoBehaviour
{
    public AudioClip powerUp;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            GameObject player = other.gameObject;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if(playerMovement)
            {
                playerMovement.timeBetweenDashes += -.2f;
            }
            Destroy(gameObject);
        }
    }
}
