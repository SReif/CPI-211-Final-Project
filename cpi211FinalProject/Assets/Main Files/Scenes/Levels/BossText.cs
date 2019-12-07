using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossText : MonoBehaviour
{
    public GameObject dialoguePanel;
    private RotateLevel rotateLevel;

    public float timeCount = 2;
    public float pulseCount = 3;
    private float randomNum;

    public Text bossText1;
    public Text bossText2;
    public Text bossText3;
    public Text bossText4;
    public Text bossText5;
    public Text bossStage;

    public Image UIboss;

    private bool counting = false;
    private bool checkFinalStage = false;
    private bool checkRotate = false;
    private bool canPopText = true;
    private bool pulsing = false;

    void Start()
    {
        rotateLevel = FindObjectOfType<RotateLevel>();

        dialoguePanel.SetActive(false);

        bossText1.enabled = false;
        bossText2.enabled = false;
        bossText3.enabled = false;
        bossText4.enabled = false;
        bossText5.enabled = false;

        bossStage.enabled = false;

        UIboss.enabled = false;
    }

    void Update()
    {
        if (pulsing == true)                                    // counting down
        {
            pulseCount -= Time.deltaTime;
        }

        if (pulseCount <= 0)                                     // time = 0, text disappear
        {
            canPopText = true;
            pulsing = false;
        }

        if (checkFinalStage == false)                            //check boss scene so it only run ones
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BossLevel"))    // check for scene name
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


        if (canPopText == true)
        {
            if (rotateLevel.isRotating == true)
            {
                checkRotate = true;
                canPopText = false;
            }
        }
        if (checkRotate == true)
        {
            randomNum = Random.Range(1, 5);
            checkRotate = false;
        }

        Debug.Log("Random num" + randomNum);
        if (counting == false && pulsing == false)
        {
            if (randomNum == 1)                              // 
            {
                dialoguePanel.SetActive(true);
                bossText1.enabled = true;
                UIboss.enabled = true;
                counting = true;
                timeCount = 2;
                pulseCount = 3;

            }
            if (randomNum == 2)                              //
            {
                dialoguePanel.SetActive(true);
                bossText2.enabled = true;
                UIboss.enabled = true;
                counting = true;
                timeCount = 2;
                pulseCount = 3;

            }
            if (randomNum == 3)                              // 
            {
                dialoguePanel.SetActive(true);
                bossText3.enabled = true;
                UIboss.enabled = true;
                counting = true;
                timeCount = 2;
                pulseCount = 3;

            }
            if (randomNum == 4)                              // 
            {
                dialoguePanel.SetActive(true);
                bossText4.enabled = true;
                UIboss.enabled = true;
                counting = true;
                timeCount = 2;
                pulseCount = 3;

            }
            if (randomNum == 5)                              // 
            {
                dialoguePanel.SetActive(true);
                bossText5.enabled = true;
                UIboss.enabled = true;
                counting = true;
                timeCount = 2;
                pulseCount = 3;
            }
        }

        if (counting == true)                                    // counting down
        {
            timeCount -= Time.deltaTime;
        }

        if (timeCount <= 0)                                     // time = 0, text disappear
        {
            textDisappear();
        }
        //Debug.Log(timeCount);

    }

    void textDisappear()                                        // text disappear function
    {
        Debug.Log("text disappear");
        dialoguePanel.SetActive(false);

        bossStage.enabled = false;
        bossText1.enabled = false;
        bossText2.enabled = false;
        bossText3.enabled = false;
        bossText4.enabled = false;
        bossText5.enabled = false;

        UIboss.enabled = false;

        counting = false;
        pulsing = true;
        
    }
}
