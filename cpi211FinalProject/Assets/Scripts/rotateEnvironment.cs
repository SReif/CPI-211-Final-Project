using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete]
public class rotateEnvironment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (/*Placeholder Statement*/ Input.GetKeyDown("q"))
        {
            transform.RotateAround(transform.position, Vector3.up, 90f);
        }

        if (/*Placeholder Statement*/ Input.GetKeyDown("e"))
        {
            transform.RotateAround(transform.position, Vector3.up, -90f);
        }

        if (/*Placeholder Statement*/ Input.GetKeyDown("w"))
        {
            transform.RotateAround(transform.position, Vector3.right, -90f);
        }

        if (/*Placeholder Statement*/ Input.GetKeyDown("s"))
        {
            transform.RotateAround(transform.position, Vector3.right, 90f);
        }
    }
}
