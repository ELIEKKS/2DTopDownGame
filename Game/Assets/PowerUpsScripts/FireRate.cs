using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRate : MonoBehaviour
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
                shootingScript.startTimeBtwShots -= 0.02f;
            }
            Destroy(gameObject);
        }
    }
}
