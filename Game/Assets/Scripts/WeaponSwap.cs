using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSwap : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;

    private int currentGunMagazinSize, currentGunAmountOfAmmo;
    public GameObject currentGun;

    public TextMeshProUGUI amountOfBulletText;

    // Start is called before the first frame update

    public void UpdateAmmoUI(GameObject currentGun)
    {
        Shooting shootingScript = currentGun.GetComponent<Shooting>();
        
        if(shootingScript != null)
        {
            amountOfBulletText.text = "Bullets: " + shootingScript.amountOfBullets + "/" + shootingScript.magazineSize;
        }
        else 
        {
           amountOfBulletText.text = "Knife"; 
        }
    }

    // Start is called before the first frame update
    void Awake() 
    {
        SetGuns();
        UpdateAmmoUI(currentGun);
    }


    public void SetGuns()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //next Weapon
            if(currentWeaponIndex < totalWeapons-1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
                UpdateAmmoUI(currentGun); 
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //previous Weapon
            if (currentWeaponIndex > 0) 
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
                UpdateAmmoUI(currentGun);
                
            }
        }
    }
}