using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour
{
    public float counter;
    public float angle = 90f;
    public float speed = 0.5f;

    private Vector3 rotateAngles;

    private bool rotateLeft, rotateRight, rotateUp, rotateDown;
    public bool isRotating;

    // Start is called before the first frame update
    void Start()
    {
        counter = angle / speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            if(isRotating == false)
            {
                rotateLeft = true;
                isRotating = true;
            }
        }

        if (Input.GetKeyDown("l"))
        {
            if (isRotating == false)
            {
                rotateRight = true;
                isRotating = true;
            }
        }

        if (Input.GetKeyDown("i"))
        {
            if (isRotating == false)
            {
                rotateUp = true;
                isRotating = true;
            }
        }

        if (Input.GetKeyDown("k"))
        {
            if (isRotating == false)
            {
                rotateDown = true;
                isRotating = true;
            }
        }

        Rotate();
    }

    void Rotate()
    {
        if (rotateLeft == true)
        {
            rotateAngles = new Vector3(0f, speed, 0f);

            if (counter > 0)
            {
                transform.Rotate(rotateAngles, Space.World);
                counter--;
            }

            else
            {
                isRotating = false;
                rotateLeft = false;
                counter = angle / speed;
            }
        }

        if (rotateRight == true)
        {
            rotateAngles = new Vector3(0f, -speed, 0f);

            if (counter > 0)
            {
                transform.Rotate(rotateAngles, Space.World);
                counter--;
            }

            else
            {
                isRotating = false;
                rotateRight = false;
                counter = angle / speed;
            }
        }

        if (rotateDown == true)
        {
            rotateAngles = new Vector3(-speed, 0f, 0f);

            if (counter > 0)
            {
                transform.Rotate(rotateAngles, Space.World);
                counter--;
            }

            else
            {
                isRotating = false;
                rotateDown = false;
                counter = angle / speed;
            }
        }

        if (rotateUp == true)
        {
            rotateAngles = new Vector3(speed, 0f, 0f);

            if (counter > 0)
            {
                transform.Rotate(rotateAngles, Space.World);
                counter--;
            }

            else
            {
                isRotating = false;
                rotateUp = false;
                counter = angle / speed;
            }
        }
    }
}