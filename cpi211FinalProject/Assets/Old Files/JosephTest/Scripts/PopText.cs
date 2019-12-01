using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopText : MonoBehaviour
{
    public Text bossStage;
    public Text gravity;
    public Text PRotation;
    public Image UIboss;
    public Image textBG;

    private bool checkFinalStage = false;

    void Start()
    {
        Debug.Log("start");
        gravity.enabled = false;
        bossStage.enabled = false;
        UIboss.enabled = false;
        textBG.enabled = false;
        PRotation.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (checkFinalStage == false && bosshealth == 100)      // check boss exist in final stage.
        {
            exmaple.enabled = true;
            textBG.enabled = true;
            UIboss.enabled = true;
        }
        */
        if (Input.GetKeyDown("tab"))                               // text for gravity change
        {
            Debug.Log("text disapear");
            gravity.enabled = false;
            UIboss.enabled = false;
            textBG.enabled = false;
        }
        if (Input.GetKeyDown("q")|| Input.GetKeyDown("e"))        // text for rotation
        {
            PRotation.enabled = true;
            textBG.enabled = true;
            UIboss.enabled = true;
        }



            if (Input.GetKeyDown("p"))
        {
            Debug.Log("text apear");
            bossStage.enabled = true;
            gravity.enabled = true;
            UIboss.enabled = true;
            textBG.enabled = true;
            PRotation.enabled = true;
        }
    }
}
