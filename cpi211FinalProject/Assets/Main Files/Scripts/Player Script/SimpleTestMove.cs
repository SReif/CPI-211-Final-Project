using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTestMove : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 1.0f;
    public float jumpForce = 5.5f;
    public Vector3 movement;
    public bool isGrounded, isMoving;

    private int jumpCount;

    public PlayerGravity playerGravity;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
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
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            jumpCount -= 1;
            isGrounded = false;
            if(Physics.gravity.y < 0)
            {
                rb.velocity = transform.up * jumpForce;
            }
            else
            {
                rb.velocity = transform.up * -jumpForce;
            }
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        if (isGrounded == false)
        {
            rb.freezeRotation = true;
        }
        else
        {
            rb.freezeRotation = false;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if(Physics.gravity.y < 0)
        {
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }
        else
        {
            Vector3 playerMovement = new Vector3(-hor, 0f, -ver) * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
            //transform.Rotate(0f, 180f, 180f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        jumpCount = 1;
    }
}
