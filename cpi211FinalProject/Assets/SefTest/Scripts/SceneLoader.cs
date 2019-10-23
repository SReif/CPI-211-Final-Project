using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void moveScene()
    {
        if(SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I'm Triggered!");
        Debug.Log("Current Scene: " + SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Total Scenes: " + SceneManager.sceneCountInBuildSettings);
        moveScene();
    }

}
