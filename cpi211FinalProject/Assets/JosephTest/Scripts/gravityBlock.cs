using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityBlock : MonoBehaviour
{
    //public float gravitySpeed = 15f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Debug.Log("hit wall");


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

}
