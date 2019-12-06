using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PopText : MonoBehaviour
{
    public GameObject dialoguePanel;

    public float timeCount = 2;

    public Text bossStage;
    public Text gravity;
    public Text PRotation;

    public Image UIboss;

    private bool counting = false;
    private bool checkFinalStage = false;

    void Start()
    {
        /*Scene CurrentScene = SceneManager.GetActiveScene();
        string SceneName = CurrentScene.name;
        Debug.Log(SceneName);*/

        dialoguePanel.SetActive(false);
        gravity.enabled = false;
        bossStage.enabled = false;
        UIboss.enabled = false;
        PRotation.enabled = false;
    }

    void Update()
    {
        if(checkFinalStage == false)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("JosephScene"))
            {
                dialoguePanel.SetActive(true);
                bossStage.enabled = true;
                UIboss.enabled = true;
                counting = true;
                checkFinalStage = true;
                timeCount = 2;

                Debug.Log("boss scene check");
            }
        }
        
        if (Input.GetKeyDown("tab"))                              // text for gravity change
        {
            Debug.Log("text appear");
            dialoguePanel.SetActive(true);
            gravity.enabled = true;
            UIboss.enabled = true;
            counting = true;
            timeCount = 2;

        }
        if (Input.GetKeyDown("q")|| Input.GetKeyDown("e"))       // text for rotation
        {
            dialoguePanel.SetActive(true);
            PRotation.enabled = true;
            UIboss.enabled = true;

            counting = true;
            timeCount = 2;
        }


        if (counting == true)                                    // counting down
        {
            timeCount -= Time.deltaTime;
        }

        if (timeCount <= 0)                                     // time = 0, text disappear
        {
            textDisappear();
        }
        Debug.Log(timeCount);

    }

    void textDisappear()                                        // text disappear function
    {
        Debug.Log("text disappear");
        dialoguePanel.SetActive(false);
        bossStage.enabled = false;
        gravity.enabled = false;
        UIboss.enabled = false;
        PRotation.enabled = false;
        counting = false;
    }
}
