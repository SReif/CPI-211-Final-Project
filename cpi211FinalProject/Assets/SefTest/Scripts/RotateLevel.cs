using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    public float speed = 30.0f;
    private Vector3 endRotation;
    private bool rotateX, rotateY, isRotating;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { 
        if(isRotating == false)
        {
            if (Input.GetKeyDown("j"))
            {
                endRotation.y = transform.eulerAngles.y + 90f;
                rotateY = true;
                isRotating = true;
            }

            if (Input.GetKeyDown("l"))
            {
                endRotation.y = transform.eulerAngles.y - 90f;
                rotateY = true;
                isRotating = true;
            }

            if (Input.GetKeyDown("i"))
            {
                endRotation.x = transform.eulerAngles.x + 90f;
                rotateX = true;
                isRotating = true;
            }

            if (Input.GetKeyDown("k"))
            {
                endRotation.x = transform.eulerAngles.x - 90f;
                rotateX = true;
                isRotating = true;
            }
        }

        if(rotateX)
        {
            float angleX = Mathf.MoveTowardsAngle(transform.eulerAngles.x, endRotation.x, speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(angleX, transform.eulerAngles.y, transform.eulerAngles.z);

            if(transform.eulerAngles.x == endRotation.x)
            {
                rotateX = false;
                isRotating = false;
            }
        }

        if(rotateY)
        {
            float angleY = Mathf.MoveTowardsAngle(transform.eulerAngles.y, endRotation.y, speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angleY, transform.eulerAngles.z);

            if (transform.eulerAngles.y == endRotation.y)
            {
                rotateY = false;
                isRotating = false;
            }
        }
    }
}