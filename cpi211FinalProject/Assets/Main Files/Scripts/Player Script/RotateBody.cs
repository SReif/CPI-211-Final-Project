using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBody : MonoBehaviour
{
    private bool canChange = false;
    private bool gravSet = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 270f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gravSet)
        {
            Physics.gravity *= -1;
            Physics.gravity *= -1;
            gravSet = false;
        }
        if(Physics.gravity.y > 0 && !canChange)
        {
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            canChange = true;
        }
        else
        {
            //transform.Rotate(0, 180f, 0);
        }
    }
}
