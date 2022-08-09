using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public KillCount killCount;
    public TextMeshProUGUI killsText;

    private void Start() 
    {
        KillCount killCountScript = killCount.GetComponent<KillCount>();
        killsText.text = " Kill: " + killCountScript.totalKillCount.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
