using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float speed;
    private Transform target;

    public RotateLevel rotateLevel;
    public PlayerGravity playerGravity;
    public bool interacting;

    public GameObject environment;
    private bool canChange = true;
    public Transform camera;
    void Start()
    {
        speed = rotateLevel.speed;
        target = FindObjectOfType<Camera>().transform;
    }

    void Update()
    {
        GravityChanged();
        
        if (rotateLevel.isRotating == true)
        {
            Parent(environment, transform.gameObject);
            //Rotate();
        }

        else
        {
            UnParent(transform.gameObject);
        }

    }

    
    void Parent(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
    }

    void UnParent(GameObject child)
    {
        transform.parent = null;
    }

    /*
    //If using, include an object/empty object for the player to look at.
    void Rotate()
    {
        //Vector3 lookPosition = new Vector3(0f, 0f, target.position.z - transform.position.z);
        Vector3 lookPosition = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, target.position.z - transform.position.z);

        if (Physics.gravity.y < 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookPosition, Vector3.up);
            transform.rotation = targetRotation;
        }

        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookPosition, Vector3.down);
            transform.rotation = targetRotation;
        }
            
    }
    */

    void GravityChanged()
    {
        if(Physics.gravity.y > 0)//if(playerGravity.gravityChanged == true)
        {
            Vector3 camPosition = camera.position;
            //Vector3 targetRotation = new Vector3(180f, transform.rotation.y, transform.rotation.z);
            Vector3 targetRotation = new Vector3(180f, 0f, 180f);
            transform.Rotate(targetRotation);
            //camera.position = camPosition;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "BlueCube" && interacting == false)
        {
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                Debug.Log("Interacting");
                interacting = true;
                rotateLevel.rotateLeft = true;
                rotateLevel.isRotating = true;
                FindObjectOfType<AudioManager>().Play("Interact");
                FindObjectOfType<AudioManager>().Play("Rotate");
            }
        }

        if (other.name == "OrangeCube" && interacting == false)
        {
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                Debug.Log("Interacting");
                interacting = true;
                rotateLevel.rotateRight = true;
                rotateLevel.isRotating = true;
                FindObjectOfType<AudioManager>().Play("Interact");
                FindObjectOfType<AudioManager>().Play("Rotate");
            }
        }

        if (other.name == "PurpleCube" && interacting == false)
        {
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                Debug.Log("Interacting");
                interacting = true;
                rotateLevel.rotateUp = true;
                rotateLevel.isRotating = true;
                FindObjectOfType<AudioManager>().Play("Interact");
                FindObjectOfType<AudioManager>().Play("Rotate");
            }
        }

        if (other.name == "YellowCube" && interacting == false)
        {
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                Debug.Log("Interacting");
                interacting = true;
                rotateLevel.rotateDown = true;
                rotateLevel.isRotating = true;
                FindObjectOfType<AudioManager>().Play("Interact");
                FindObjectOfType<AudioManager>().Play("Rotate");
            }
        }

        if (other.name == "GreenCube" && interacting == false)
        {
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                Debug.Log("Interacting");
                interacting = true;
                rotateLevel.rotateClockwise = true;
                rotateLevel.isRotating = true;
                FindObjectOfType<AudioManager>().Play("Interact");
                FindObjectOfType<AudioManager>().Play("Rotate");
            }
        }

        if (other.name == "RedCube" && interacting == false)
        {
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                Debug.Log("Interacting");
                interacting = true;
                rotateLevel.rotateCounterClockwise = true;
                rotateLevel.isRotating = true;
                FindObjectOfType<AudioManager>().Play("Interact");
                FindObjectOfType<AudioManager>().Play("Rotate");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interacting = false;
    }

    /*
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Player is colliding with " + collision.gameObject.name);

        if (rotateLevel.isRotating == true)
        {
            //collision.transform.position = transform.position;
            collision.transform.rotation = transform.rotation;
        }
    }
    */
}
