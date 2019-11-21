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

    private int jumpCount;

    public PlayerGravity playerGravity;
    public Transform cam;
    private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;

        camF = camF.normalized;
        camR = camR.normalized;

        movementDirection = (camF * movement.z + camR * movement.x);

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
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);

        if(isMoving == true)
        {
            if(playerGravity.gravity.y < 0)
            {
                transform.rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            }
            
            if(playerGravity.gravity.y > 0)
            {
                transform.rotation = Quaternion.LookRotation(movementDirection, Vector3.down);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            jumpCount -= 1;
            isGrounded = false;
            rb.velocity = transform.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        if (isGrounded == false)
        {
            rb.freezeRotation = true;
        }
        else
        {
            rb.freezeRotation = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        jumpCount = 1;
    }
}
