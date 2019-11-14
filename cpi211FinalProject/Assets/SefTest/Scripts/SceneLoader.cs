using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static bool paused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene("SampleScene");
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
            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
            Time.timeScale = 0.0f;
            paused = true;
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

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        paused = false;
    }
}
