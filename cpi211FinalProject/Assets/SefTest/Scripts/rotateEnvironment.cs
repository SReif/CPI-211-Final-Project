using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete]
public class rotateEnvironment : MonoBehaviour
{
    /*
    public float rotationSpeed = 0.5f;
    private float rotationPosition;
    private float endRotation;
    private bool rotateA, rotateB, rotateC, rotateD;
    */

    // Start is called before the first frame update
    void Start()
    {
        /*
        rotateA = false;
        rotateB = false;
        rotateC = false;
        rotateD = false;
        */
    }

    // Update is called once per frame
    
    void Update()
    {
        //Button Pressed
        if (/*Placeholder Statement*/ Input.GetKeyDown("j"))
        {
            /*endRotation = Mathf.Round(transform.eulerAngles.y + 90f);
            rotateA = true;*/

            transform.RotateAround(transform.position, Vector3.up, 90f);
        }

        if (/*Placeholder Statement*/ Input.GetKeyDown("l"))
        {
            /*endRotation = Mathf.Round(transform.eulerAngles.y - 90f);
            rotateB = true;*/

            transform.RotateAround(transform.position, Vector3.up, -90f);
        }

        if (/*Placeholder Statement*/ Input.GetKeyDown("i"))
        {
            /*endRotation = Mathf.Round(transform.eulerAngles.x - 90f);
            rotateC = true;*/

            transform.RotateAround(transform.position, Vector3.right, -90f);
        }

        if (/*Placeholder Statement*/ Input.GetKeyDown("k"))
        {
            /*endRotation = Mathf.Round(transform.eulerAngles.x + 90f);
            rotateD = true;*/

            transform.RotateAround(transform.position, Vector3.right, 90f);
        }

        //Rotation Conditions
        /*
        if(rotateA == true)
        {
            rotationPosition = transform.eulerAngles.y;
            transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);

            if(rotationPosition >= endRotation)
            {
                rotateA = false;
            }
        }

        if (rotateB == true)
        {
            rotationPosition = transform.eulerAngles.y;
            transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);

            if (rotationPosition >= endRotation)
            {
                rotateB = false;
            }
        }

        if (rotateC == true)
        {
            rotationPosition = transform.eulerAngles.x;
            transform.RotateAround(transform.position, Vector3.right, rotationSpeed * Time.deltaTime);

            if (rotationPosition >= endRotation)
            {
                rotateC = false;
            }
        }

        if (rotateD == true)
        {
            rotationPosition = transform.eulerAngles.x;
            transform.RotateAround(transform.position, Vector3.right, rotationSpeed * Time.deltaTime);

            if (rotationPosition >= endRotation)
            {
                rotateD = false;
            }
        }*/
    }
}
