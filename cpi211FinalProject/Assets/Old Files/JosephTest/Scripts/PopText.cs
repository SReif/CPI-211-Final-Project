using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopText : MonoBehaviour
{
    public Text text;
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p"))
        {

                Debug.Log("text disapear");
                text.enabled = false;
        }
        if (Input.GetKeyDown("o"))
        {
                Debug.Log("text apear");
                text.enabled = true;
        }
    }
}
