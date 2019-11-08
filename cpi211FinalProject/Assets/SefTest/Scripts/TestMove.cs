using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 1.0f;
    public float jumpForce = 5.5f;
    public Vector3 movement;
    public bool isGrounded, isMoving;

    public PlayerGravity playerGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            isMoving = true;
        }

        else
        {
            isMoving = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(isMoving == true)
        {
            if(playerGravity.gravity.y < 0)
            {
                transform.rotation = Quaternion.LookRotation(movement, Vector3.up);
            }
            
            if(playerGravity.gravity.y > 0)
            {
                transform.rotation = Quaternion.LookRotation(movement, Vector3.down);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = transform.up * jumpForce;
            rb.freezeRotation = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("Collided with " + collision.gameObject.tag);
        if(collision.gameObject.tag == "environment" || collision.gameObject.tag == "non rotating environment")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "environment" || collision.gameObject.tag == "non rotating environment")
        {
            isGrounded = false;
        }
    }
}
