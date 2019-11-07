using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableInteraction : MonoBehaviour
{
    public bool rotateLeft = false;
    public bool rotateRight = false;
    public bool rotateUp = false;
    public bool rotateDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OrangeCube")
        {
            rotateUp = true;
        }
        else if(other.tag == "BlueCube")
        {
            rotateDown = true;
        }
        else if(other.tag == "PurpleCube")
        {
            rotateLeft = true;
        }
        else if(other.tag == "YellowCube")
        {
            rotateRight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "OrangeCube")
        {
            rotateUp = false;
        }
        else if(other.tag == "BlueCube")
        {
            rotateDown = false;
        }
        else if(other.tag == "PurpleCube")
        {
            rotateLeft = false;
        }
        else if(other.tag == "YellowCube")
        {
            rotateRight = false;
        }
    }
}
