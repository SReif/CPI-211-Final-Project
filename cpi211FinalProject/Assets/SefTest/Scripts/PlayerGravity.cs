using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public bool gravityChanged;
    public Vector3 gravity;

    void Start()
    {
        gravity = Physics.gravity;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            gravity *= -1;
            Physics.gravity = gravity;
            gravityChanged = true;
            FindObjectOfType<AudioManager>().Play("Gravity");
        }

        else
        {
            gravityChanged = false;
        }
    }
}
