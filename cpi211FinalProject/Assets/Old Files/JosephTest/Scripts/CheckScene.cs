using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckScene : MonoBehaviour
{

    public GameObject panel;


    void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        string SceneName = CurrentScene.name;
        Debug.Log(SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
