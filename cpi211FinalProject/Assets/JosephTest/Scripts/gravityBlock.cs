using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityBlock : MonoBehaviour
{
    //public float gravitySpeed = 15f;
    public float movementSpeed = 300f;
    public GameObject self;

    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;
    bool terrain = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (up == false && down == false && left == false && right == false)

            if (Input.GetKey("w"))  //move up
            {
                up = true;
                self.GetComponent<Rigidbody>().AddForce(self.transform.up * movementSpeed);
            }
            if (Input.GetKey("a"))  //move left
            {
                left = true;
                self.GetComponent<Rigidbody>().AddForce(-self.transform.forward * movementSpeed);
            }
            if (Input.GetKey("s")) //move down
            {
                down = true;
                self.GetComponent<Rigidbody>().AddForce(-self.transform.up * movementSpeed);
            }
            if (Input.GetKey("d"))  //move right
            {
                right = true;
                self.GetComponent<Rigidbody>().AddForce(self.transform.forward * movementSpeed);
            }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            up = false;
            down = false;
            left = false;
            right = false;

            self.GetComponent<Rigidbody>().AddForce(self.transform.forward * 0);

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
