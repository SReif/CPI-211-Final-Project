using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{
    public Camera cam;

    //zoom variables
    private float zoomFactor = 1.0f, minZoom = 10.0f, maxZoom = 100.0f;

    //rotate variables
    private float rotSpeed = 5.0f;
    private float minRotate = 0.0f, maxRotate = 10.0f;
    private Vector3 offset;

    void Start()
    {
        cam.transform.position = FindObjectOfType<Camera>().transform.position;
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
        //rotates on right mouse down
        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotSpeed, Vector3.up) * offset;
            //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotSpeed, Vector3.right) * offset;
            //offset.y = Mathf.Clamp(offset.y, minRotate, maxRotate);
            
            
        }
        cam.transform.position = transform.position + offset;
        cam.transform.LookAt(transform.position);
    }
}
