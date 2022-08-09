using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazinSize : MonoBehaviour
{
    public AudioClip powerUp;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            GameObject player = other.gameObject;
            Shooting shootingScript = player.GetComponentInChildren<Shooting>();
            WeaponSwap weaponSwapScript = player.GetComponentInChildren<WeaponSwap>();
            if(shootingScript && weaponSwapScript)
            {
                shootingScript.magazineSize += 10;
                shootingScript.amountOfBullets = shootingScript.magazineSize / 2;
                weaponSwapScript.UpdateAmmoUI(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
