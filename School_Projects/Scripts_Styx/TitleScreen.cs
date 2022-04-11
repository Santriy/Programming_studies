using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject crossfade;

    private void Awake()
    {
        crossfade.SetActive(true);
    }

    public void StartGame()
    {
        crossfade.SetActive(true);
        crossfade.GetComponent<Animator>().SetTrigger("FadeIn");
        Invoke("StartLevel", 2.5f);
    }

    public void QuitGame()
    {
        crossfade.SetActive(true);
        crossfade.GetComponent<Animator>().SetTrigger("FadeIn");
        Invoke("Quit", 2f);
    }

    void Quit()
    {
        Application.Quit();
    }

    void StartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
