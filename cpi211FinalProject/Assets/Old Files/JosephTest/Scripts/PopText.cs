using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopText : MonoBehaviour
{
    public float timeCount = 2;

    public Text bossStage;
    public Text gravity;
    public Text PRotation;

    public Image UIboss;
    public Image textBG;

    //private bool checkFinalStage = false;
    private bool counting = false;
    void Start()
    {
       
        gravity.enabled = false;
        bossStage.enabled = false;
        UIboss.enabled = false;
        textBG.enabled = false;
        PRotation.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        Debug.Log(timeCount);
        /*if (checkFinalStage == false && bosshealth == 100)     // check boss exist in final stage.
        {
            exmaple.enabled = true;
            textBG.enabled = true;
            UIboss.enabled = true;
        }
        */
        if (Input.GetKeyDown("tab"))                              // text for gravity change
        {
            Debug.Log("text appear");
            gravity.enabled = true;
            UIboss.enabled = true;
            textBG.enabled = true;

            counting = true;
            timeCount = 2;

        }
        if (Input.GetKeyDown("q")|| Input.GetKeyDown("e"))       // text for rotation
        {
            PRotation.enabled = true;
            textBG.enabled = true;
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


    }

    void textDisappear()                                        // text disappear function
    {
        Debug.Log("text disappear");
        bossStage.enabled = false;
        gravity.enabled = false;
        UIboss.enabled = false;
        textBG.enabled = false;
        PRotation.enabled = false;
        counting = false;
    }
}
