using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalInteract : MonoBehaviour
{
    private bool victory;

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if(victory == false)
            {
                Time.timeScale = 0.0f;
                SceneManager.LoadScene("VictoryScene", LoadSceneMode.Additive);
                victory = true;
            }
            

            /*
            if(SceneManager.GetActiveScene.name == "LastLeveL")
            {
                SceneManager.LoadScene("VictoryScene");
            }

            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
             */
        }
    }
}
