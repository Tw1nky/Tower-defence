using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldStats : MonoBehaviour
{
    public static int HP = 10;
    public static int gold = 500;
    public static int level = 0;

    public Text hptext;
    public Text goldText;
    public Text levelText;

    public GameObject pauseUI;


    private void Update()
    {
        hptext.text = "HP: " + HP;
        goldText.text = "Gold: " + gold;
        levelText.text = "Level: " + level;
    }

    public static void reset()
    {
        HP = 10;
        gold = 500;
        level = 0;
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);

    }
    public void resumeGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
