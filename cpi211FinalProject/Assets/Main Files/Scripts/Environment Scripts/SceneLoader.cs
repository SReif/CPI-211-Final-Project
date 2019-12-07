﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool paused = false;
    public bool playing;
    public string currentLevel;

    public static SceneLoader instance;
    private GameObject boss;

    public float introSceneTimer = 180f;

    public GoalInteract victoryCondition;

    private void Start()
    {
        playing = false;
        if(SceneManager.GetActiveScene().name == "BossLevel")
        {
            boss = FindObjectOfType<BossMechanic>().gameObject;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() != null && SceneManager.GetActiveScene().name != "LoseScene")
        {
            currentLevel = SceneManager.GetActiveScene().name;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "StartScene" && SceneManager.GetActiveScene().name != "OptionScene" && SceneManager.GetActiveScene().name != "IntroScene")
        {
            Debug.Log("Paused is " + paused);
            if(paused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }

        Sound();

        if(currentLevel == "IntroScene")
        {
            introSceneTimer -= Time.deltaTime;
            if(introSceneTimer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if(Time.timeScale == 1f)
        {
            paused = false;
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

            FindObjectOfType<AudioManager>().Pause();

            if (SceneManager.GetActiveScene().name == "BossLevel")
            {
                boss.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        SceneManager.UnloadSceneAsync("PauseScene");
        Time.timeScale = 1.0f;
        paused = false;
        // playing = false;

        //FindObjectOfType<AudioManager>().Pause();
        FindObjectOfType<AudioManager>().UnPause();

        if (SceneManager.GetActiveScene().name == "BossLevel")
        {
            boss.SetActive(true);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
        paused = false;
        victoryCondition.victory = false;
    }

    public void Retry()
    {
        Debug.Log("Current Scene " + currentLevel);
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1.0f;
        paused = false;
        victoryCondition.victory = false;
    }

    public void Lose()
    {
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Additive);
        Time.timeScale = 0.0f;
    }

    private void Sound()
    {
        if (!playing)
        {
           
            if (SceneManager.GetActiveScene().name == "StartScene")
            {
                FindObjectOfType<AudioManager>().Stop();
                FindObjectOfType<AudioManager>().Play("title_background");
                playing = true;
            }

            else if (SceneManager.GetActiveScene().name == "IntroScene")
            {
                FindObjectOfType<AudioManager>().Stop();
                FindObjectOfType<AudioManager>().Play("intro_background");
                playing = true;
            }

            else if (SceneManager.GetActiveScene().name == "BossLevel" && !victoryCondition.victory)
            {
                FindObjectOfType<AudioManager>().Stop();
                FindObjectOfType<AudioManager>().Play("boss_background");
                playing = true;
            }

            else 
            {
                FindObjectOfType<AudioManager>().Stop();
                FindObjectOfType<AudioManager>().Play("main_background");
                playing = true;
                Debug.Log("Firing");
            }
        }
    }
}
