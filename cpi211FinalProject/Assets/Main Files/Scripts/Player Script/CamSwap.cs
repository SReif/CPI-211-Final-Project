using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwap : MonoBehaviour
{
    public bool isSwapped = false;

    public GameObject camera1;
    public GameObject camera2;

    public SimpleTestCamControl camControl1;
    public camControl camControl2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("c") && !isSwapped)
        {
            camera1.GetComponent<Camera>().enabled = false;
            camControl1.enabled = false;

            camera2.GetComponent<Camera>().enabled = true;
            camControl2.enabled = true;
            isSwapped = true;
        }
        else if(Input.GetKeyDown("c") && isSwapped)
        {
            camera1.GetComponent<Camera>().enabled = true;
            camControl1.enabled = true;

            camera2.GetComponent<Camera>().enabled = false;
            camControl2.enabled = false;
            isSwapped = false;
        }
    }
}
