using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalInteract : MonoBehaviour
{
    public bool victory;
    private SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            /*
            if(victory == false)
            {
                Time.timeScale = 0.0f;
                SceneManager.LoadScene("VictoryScene", LoadSceneMode.Additive);
                victory = true;
            }
            */
            if(SceneManager.GetActiveScene().name == "BossLevel" && victory == false)
            {
                FindObjectOfType<BossMechanic>().gameObject.SetActive(false);
                Time.timeScale = 0.0f;
                SceneManager.LoadScene("VictoryScene", LoadSceneMode.Additive);
                FindObjectOfType<AudioManager>().Stop();
                FindObjectOfType<AudioManager>().Play("victory_background");
                victory = true;
            }

            if(SceneManager.GetActiveScene().name != "BossLevel")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
