using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    GameManager gameManager;


    public bool gamePaused = false;
    public bool gameOver = false;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverMenu.SetActive(true);
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                Pause();
            }
            else
            {
                Resume();               
            }
            
        }
    }

    public void Pause()
    {
        Cursor.SetCursor(gameManager.CustomCursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = true;
        Time.timeScale = 0;
        if (!gameOver)
        {
            pauseMenu.SetActive(true);
        }
        gamePaused = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gamePaused = false;
    }

    public void Restart()
    {
        Cursor.visible = false;
        Time.timeScale = 1;       
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        gamePaused = false;
        gameOver = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
