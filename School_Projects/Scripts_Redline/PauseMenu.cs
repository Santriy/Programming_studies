using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool SettingsOpen = false;




    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SettingsOpen == false && GameManager.winCon == false && GameManager.deathCon == false)
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }
        }

    }

    public void Resume()
    {

        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {

        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        GameManager.deathCon = false;
        HealthScript.health = HealthScript.healthMax;
        //NewPlayerController.score = 0f;
    }

    public void LoadMenu()
    {
        //NewPlayerController.score = 0f;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        GameManager.winCon = false;
    }
}