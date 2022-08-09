using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public int killCountInt = 0;
    public int totalKillCount = 0;
    public TextMeshProUGUI killCountIntText;
    public TextMeshProUGUI killCountIntTextShop;
    private void Start() {
        killCountIntText.text = "Kills: " + killCountInt.ToString();
        killCountIntTextShop.text = "Deaths: " + killCountInt.ToString();
    }

    public void AddDeath(int value)
    {
        killCountInt += value;
        totalKillCount += value;
        killCountIntText.text = "Kills: " + killCountInt.ToString();
        killCountIntTextShop.text = "Deaths: " + killCountInt.ToString();
        
    }
    public void RemoveDeath(int value)
    {
        killCountInt -= value;
        killCountIntText.text = "Kills: " + killCountInt.ToString();
        killCountIntTextShop.text = "Kills: " + killCountInt.ToString();
    }
}
 