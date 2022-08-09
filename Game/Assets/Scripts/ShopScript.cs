using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class ShopScript : MonoBehaviour
{
    public Text shopText;
    private bool shopingAllowed;

    public int countDownTime;
    public Text countDownDisplay;


    public TextMeshProUGUI coinsText;


    public GameObject player;
    public KillCount killCount;

    public GameObject shopUI;
    public Transform gunHolder;

    

    private void Start() 
    {
        shopText.gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");

        coinsText.text = "Coins: " + killCount.killCountInt.ToString();

    }

    private void Update() 
    {
        if(shopingAllowed && Input.GetKeyDown(KeyCode.F))
        {
            Shop();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShop();
        }
    }


    public void AddGun(GameObject gun)
    {
        WeaponSwap weaponScript = player.GetComponentInChildren<WeaponSwap>();
        Shooting shootingScript = gun.GetComponent<Shooting>();

        if(killCount.killCountInt >= shootingScript.costToBuy)
        {
            if(weaponScript != null && shootingScript != null)
            killCount.RemoveDeath(shootingScript.costToBuy);
            shootingScript.amountOfBullets = shootingScript.magazineSize;
            weaponScript.UpdateAmmoUI(gun);
            Instantiate(gun, gunHolder);
            weaponScript.SetGuns();
        }
        else 
        {
            Debug.Log("note enough money!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            shopText.gameObject.SetActive(true);
            shopingAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            shopText.gameObject.SetActive(false);
            shopingAllowed = false;
        }
    }

    public void CloseShop()
    {
        shopUI.gameObject.SetActive(false);
        new WaitForSeconds(3);
        Time.timeScale = 1;
    }

 


    public void Shop()
    {
        shopUI.gameObject.SetActive(true);
        //Set active some Shop UI
        Time.timeScale = 0;
    }
}


