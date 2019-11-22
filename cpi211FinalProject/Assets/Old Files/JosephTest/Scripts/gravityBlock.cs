using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityBlock : MonoBehaviour
{
    //public float gravitySpeed = 15f;
    public float movementSpeed = 300;
    public GameObject self;

    bool moving = false;
    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moving == false)
        {
            if (Input.GetKey("k") && up == false)  //move up
            {
                moving = true;

                up = true;
                down = false;
                left = false;
                right = false;

                self.GetComponent<Rigidbody>().AddForce(self.transform.up * movementSpeed);
            }
            if (Input.GetKey("j") && left == false)  //move left
            {
                moving = true;

                up = false;
                down = false;
                left = true;
                right = false;

                self.GetComponent<Rigidbody>().AddForce(-self.transform.forward * movementSpeed);
            }
            if (Input.GetKey("i") && down == false) //move down
            {
                moving = true;

                up = false;
                down = true;
                left = false;
                right = false;

                self.GetComponent<Rigidbody>().AddForce(-self.transform.right * movementSpeed);
            }
            if (Input.GetKey("l") && right == false)  //move right
            {
                moving = true;

                up = false;
                down = false;
                left = false;
                right = true;

                self.GetComponent<Rigidbody>().AddForce(self.transform.forward * movementSpeed);
            }
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            moving = false;
            Debug.Log("hit wall");


        }
        if (collision.gameObject.tag == "terrain")
        {

        }
    }

    /* different way

       if (Input.GetKey("w"))  //move up
       {
           transform.position += transform.up * Time.deltaTime * movementSpeed;
       }
       if (Input.GetKey("a"))  //move left
       {
           transform.position -= transform.forward * Time.deltaTime * movementSpeed;
       }
       if (Input.GetKey("s")) //move down
       {
           transform.position -= transform.up * Time.deltaTime * movementSpeed;
       }
       if (Input.GetKey("d"))  //move right
       {
           transform.position += transform.forward * Time.deltaTime * movementSpeed;
       }
       */
    /*
     if (Input.GetKeyDown("w"))
     {
         Physics.gravity = new Vector3(0, 15f, 0);
     }
     if (Input.GetKeyDown("a"))
     {
         Physics.gravity = new Vector3(-15f, 0, 0);
     }
     if (Input.GetKeyDown("s"))
     {
         Physics.gravity = new Vector3(0, -15f, 0);
     }
     if (Input.GetKeyDown("d"))
     {
         Physics.gravity = new Vector3(15f, 0, 0);
     }
     */

}
