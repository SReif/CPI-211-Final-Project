using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{
    private Camera cam;

    //zoom variables
    private float zoomFactor = 1.0f, minZoom = 10.0f, maxZoom = 100.0f;

    //rotate variables
    private float rotSpeed = 5.0f;
    private float minRotate = 0.0f, maxRotate = 10.0f;
    private Vector3 offset;
    private Vector3 frRotationAxis;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        //cam.transform.position = FindObjectOfType<Camera>().transform.position;
        offset = cam.transform.position - transform.position;
    }

    void Update()
    {
        zoom();
        rcRotate();
    }

    void zoom()
    {
        //zooms on mousewheel forwards/backwards
        if (Input.mouseScrollDelta.y != 0)
        {
            Camera.main.fieldOfView -= Input.mouseScrollDelta.y * zoomFactor;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minZoom, maxZoom);
            Debug.Log("Camera Zoom: " + Camera.main.fieldOfView + "%");
        }
    }

    void rcRotate()
    {
        Vector3 camF = cam.transform.forward;
        Vector3 camR = cam.transform.right;

        camF.y = 0;
        camR.y = 0;

        camF = camF.normalized;
        camR = camR.normalized;

        frRotationAxis = -(camF + camR);

        //rotates on right mouse down
        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotSpeed, Vector3.up) * offset;

            /*If the camera is facing in the same direction as vector3.right, set the reference vector to vector3.forward.
             If the camera is facing in the same direction as vector3.forward, set the reference vector to vector3.right.*/
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotSpeed, frRotationAxis) * offset;

        }
        cam.transform.position = transform.position + offset;
        cam.transform.LookAt(transform.position);
    }
}
