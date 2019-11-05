using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            rb.velocity = transform.forward * speed;
            rb.freezeRotation = true;
        }

        else if (Input.GetKey("a"))
        {
            rb.velocity = transform.right * -speed;
            rb.freezeRotation = true;
        }

        else if (Input.GetKey("s"))
        {
            rb.velocity = transform.forward * -speed;
            rb.freezeRotation = true;
        }

        else if (Input.GetKey("d"))
        {
            rb.velocity = transform.right * speed;
            rb.freezeRotation = true;
        }

        else
        {
            rb.freezeRotation = false;
        }
    }
}
