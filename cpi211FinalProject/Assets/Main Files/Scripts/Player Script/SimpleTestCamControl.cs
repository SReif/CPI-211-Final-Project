﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTestCamControl : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player, Camera;
    float mouseX, mouseY;
    private bool canChange = false;
    // Start is called before the first frame update
    void Start()
    {
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        if(Physics.gravity.y < 0)
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        }
        else
        {
            mouseX -= Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        }
        mouseY = Mathf.Clamp(mouseY, -60, 80);

        transform.LookAt(Target);
        if(Physics.gravity.y < 0 && canChange)
        {
            mouseX += 180;
            canChange = false;
        }
        else if(Physics.gravity.y >= 0 && !canChange)
        {
            mouseX += 180;
            canChange = true;
        }
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
