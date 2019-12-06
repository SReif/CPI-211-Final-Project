using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    Rigidbody playerRigidBody;
    public bool gravityChanged;
    public Vector3 gravity;
    public int gravityCount;
    GameObject playerObject;
    private HealthSystem healthSystem;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        healthSystem = playerObject.GetComponent<HealthSystem>();
        gravityCount = 2;
        gravity = Physics.gravity;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && gravityCount > 0 || Input.GetKeyDown(KeyCode.RightShift) && gravityCount > 0)
        {
            gravityCount -= 1;
            //gravity *= -1;
            if(Physics.gravity.y < 0)
            {
                Physics.gravity = new Vector3(0f, 9.81f, 0f);
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
            //Physics.gravity = gravity;
            gravityChanged = true;
            FindObjectOfType<AudioManager>().Play("Gravity");
        }

        else
        {
            gravityChanged = false;
        }
        Debug.Log(gravity.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gravityCount = 2;
    }
}
