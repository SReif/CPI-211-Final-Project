using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanic : MonoBehaviour
{
    private float startTime, currentTime, minT, maxT;
    public RotateLevel rotateLevel;
    private int rotateID;

    // Start is called before the first frame update
    void Start()
    {
        minT = 60.0f;
        maxT = 180.0f;

        startTime = Random.Range(minT, maxT);
        currentTime = startTime;
        Debug.Log("Time until next rotation" + startTime);
    }

    // Update is called once per frame
    void Update()
    {
        //A new countdown timer will begin when the stage stops rotating and the timer has hit 0.
        if(rotateLevel.isRotating == false && currentTime <= 0)
        {
            RandomRotate();
            startTime = Random.Range(minT, maxT);
            currentTime = startTime;
            Debug.Log("Time until next rotation" + startTime);
        }
        
        if(rotateLevel.isRotating == false)
        {
            currentTime--;
        }
    }

    //Each rotation direction has it's own corresponding ID that will be randomly chosen.
    private void RandomRotate()
    {
        rotateID = Random.Range(0, 5);

        if (rotateID == 0)
        {
            rotateLevel.rotateUp = true;
            rotateLevel.isRotating = true;
        }

        if (rotateID == 1)
        {
            rotateLevel.rotateDown = true;
            rotateLevel.isRotating = true;
        }

        if (rotateID == 2)
        {
            rotateLevel.rotateLeft = true;
            rotateLevel.isRotating = true;
        }

        if (rotateID == 3)
        {
            rotateLevel.rotateRight = true;
            rotateLevel.isRotating = true;
        }

        if (rotateID == 4)
        {
            rotateLevel.rotateClockwise = true;
            rotateLevel.isRotating = true;
        }

        if (rotateID == 5)
        {
            rotateLevel.rotateCounterClockwise = true;
            rotateLevel.isRotating = true;
        }
    }
}
