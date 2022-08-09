using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
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
                playerMovement.moveSpeed += .5f;
            }
            Destroy(gameObject);
        }
    }
}
