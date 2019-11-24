using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacobTestRotate : MonoBehaviour
{
    public Transform environment;
    public int frameCounter = 180;
    public int frameCounter2 = 180;
    public bool rotatedOnce = false;
    public bool rotatedTwice = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(frameCounter > 0)
        {
            environment.transform.Rotate(0f, 0.5f, 0f, Space.World);
            frameCounter--;
        }
        else if(!rotatedOnce)
        {
            //environment.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
            rotatedOnce = true;
        }
        if(rotatedOnce && frameCounter2 > 0)
        {
            environment.transform.Rotate(.5f, 0f, 0f,Space.World);
            frameCounter2--;
        }
        else if(rotatedOnce && !rotatedTwice)
        {
            //environment.transform.eulerAngles = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);
            rotatedOnce = true;
        }
    }
}
