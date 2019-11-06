using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public bool gravityChanged;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Physics.gravity *= -1;
            gravityChanged = true;
        }

        else
        {
            gravityChanged = false;
        }
    }
}
