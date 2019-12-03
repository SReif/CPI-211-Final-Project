using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private RotateLevel rotateLevel;
    public GameObject yellowColor, orangeColor, blueColor;

    void Start()
    {
        rotateLevel = FindObjectOfType<RotateLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateLevel.isCollidingOrange == true)
        {
            orangeColor.SetActive(true);
            blueColor.SetActive(false);
            yellowColor.SetActive(false);
        }

        if (rotateLevel.isCollidingBlue == true)
        {
            orangeColor.SetActive(false);
            blueColor.SetActive(true);
            yellowColor.SetActive(false);
        }

        if (rotateLevel.isCollidingYellow == true)
        {
            orangeColor.SetActive(false);
            blueColor.SetActive(false);
            yellowColor.SetActive(true);
        }
    }
}
