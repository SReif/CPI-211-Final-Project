using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToolTip : MonoBehaviour
{
    public GameObject toolTip, jump, gravityShift, rotate;
    private GameObject temp1, temp2;
    private SimpleTestMove simpleTestMove;
    private PlayerGravity playerGravity;
    private RotateLevel rotateLevel;

    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        toolTip.SetActive(false);
        simpleTestMove = FindObjectOfType<SimpleTestMove>();
        playerGravity = FindObjectOfType<PlayerGravity>();
        rotateLevel = FindObjectOfType<RotateLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpActive();
        gravityActive();
        rotateActive();

        if (Input.GetKey(KeyCode.Tab))
        {
            toolTip.SetActive(true);
        }else
            {
                toolTip.SetActive(false);
            }
    }

    private void jumpActive()
    {
        if(simpleTestMove.jumpCount <= 0)
        {
            jump.SetActive(false);
        }else
            {
                jump.SetActive(true);
            }
    }

    private void gravityActive()
    {
        if(playerGravity.gravityCount < 2 && playerGravity.gravityChanged)
        {
            if (GameObject.Find("Gravity Up"))
            {
                temp1 = GameObject.Find("Gravity Up");
                temp1.SetActive(false);
            }
            
            else
            {
                temp2 = GameObject.Find("Gravity Down");
                temp2.SetActive(false);
            }
        }
        
        if(playerGravity.gravityCount == 2)
        {
            if (!temp1 || !temp2)
            {
                return;
            }
            else
            {
                temp1.SetActive(true);
                temp2.SetActive(true);
            }
        }

        /*
        if (playerGravity.gravityCount < 1)
        {
            temp1 = GameObject.Find("Gravity Up");
            temp2 = GameObject.Find("Gravity Down");

            temp1.SetActive(false);
            temp2.SetActive(false);
        }

        else
        {
            temp1.SetActive(true);
            temp2.SetActive(true);
        }
        */
    }

    private void rotateActive()
    {
        if(rotateLevel.isRotating == true)
        {
            rotate.SetActive(false);
        }else
            {
                rotate.SetActive(true);
            }
    }

}
