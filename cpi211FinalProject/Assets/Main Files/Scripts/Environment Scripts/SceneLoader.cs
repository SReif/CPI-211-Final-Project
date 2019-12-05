using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static bool paused = false;
    public string currentLevel;

    void Update()
    {
        if (SceneManager.GetActiveScene() != null && SceneManager.GetActiveScene().name != "LoseScene")
        {
            currentLevel = SceneManager.GetActiveScene().name;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if(SceneManager.sceneCount <= 1)
        {
            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
            Time.timeScale = 0.0f;
            paused = true;
        }
    }

    public void Resume()
    {
        SceneManager.UnloadSceneAsync("PauseScene");
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void Retry()
    {
        Debug.Log("Current Scene " + currentLevel);
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void Lose()
    {
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Additive);
        Time.timeScale = 0.0f;
    }
}
