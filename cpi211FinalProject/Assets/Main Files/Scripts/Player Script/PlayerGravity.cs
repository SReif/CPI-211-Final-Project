using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public bool gravityChanged;
    public Vector3 gravity;
    public int gravityCount;

    void Start()
    {
        gravityCount = 2;
        gravity = Physics.gravity;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && gravityCount > 0)
        {
            gravityCount -= 1;
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

    private void OnCollisionEnter(Collision collision)
    {
        gravityCount = 2;
    }
}
