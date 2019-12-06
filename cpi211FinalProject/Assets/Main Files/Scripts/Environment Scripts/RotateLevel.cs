using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateLevel : MonoBehaviour
{
    public float counter;
    public float angle = 90f;
    public float speed = 0.5f;

    private Vector3 rotateAngles;

    public bool rotateLeft, rotateRight, rotateUp, rotateDown, rotateClockwise, rotateCounterClockwise;
    public bool isRotating;

    public bool isCollidingOrange = false;
    public bool isCollidingBlue = false;
    public bool isCollidingYellow = false;

    // Start is called before the first frame update
    void Start()
    {
        counter = angle / speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "BossLevel")
        {
            if (Input.GetKeyDown("e") && isCollidingOrange)
            {
                if (isRotating == false)
                {
                    rotateLeft = true;
                    isRotating = true;
                    FindObjectOfType<AudioManager>().Play("Rotate");
                }
            }

            if (Input.GetKeyDown("q") && isCollidingOrange)
            {
                if (isRotating == false)
                {
                    rotateRight = true;
                    isRotating = true;
                    FindObjectOfType<AudioManager>().Play("Rotate");
                }
            }

            if (Input.GetKeyDown("e") && isCollidingBlue)
            {
                if (isRotating == false)
                {
                    rotateUp = true;
                    isRotating = true;
                    FindObjectOfType<AudioManager>().Play("Rotate");
                }
            }

            if (Input.GetKeyDown("q") && isCollidingBlue)
            {
                if (isRotating == false)
                {
                    rotateDown = true;
                    isRotating = true;
                    FindObjectOfType<AudioManager>().Play("Rotate");
                }
            }

            if (Input.GetKeyDown("e") && isCollidingYellow)
            {
                if (isRotating == false)
                {
                    rotateClockwise = true;
                    isRotating = true;
                    FindObjectOfType<AudioManager>().Play("Rotate");
                }
            }

            if (Input.GetKeyDown("q") && isCollidingYellow)
            {
                if (isRotating == false)
                {
                    rotateCounterClockwise = true;
                    isRotating = true;
                    FindObjectOfType<AudioManager>().Play("Rotate");
                }
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

        if (rotateClockwise == true)
        {
            rotateAngles = new Vector3(0f, 0f, speed);

            if (counter > 0)
            {
                transform.Rotate(rotateAngles, Space.World);
                counter--;
            }

            else
            {
                isRotating = false;
                rotateClockwise = false;
                counter = angle / speed;
            }
        }

        if (rotateCounterClockwise == true)
        {
            rotateAngles = new Vector3(0f, 0f, -speed);

            if (counter > 0)
            {
                transform.Rotate(rotateAngles, Space.World);
                counter--;
            }

            else
            {
                isRotating = false;
                rotateCounterClockwise = false;
                counter = angle / speed;
            }
        }
    }
}