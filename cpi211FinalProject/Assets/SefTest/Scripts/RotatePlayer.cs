using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float speed;
    public Transform target;

    public RotateLevel rotateLevel;
    public PlayerGravity playerGravity;
    public bool interacting;

    private bool canParent = false;

    public GameObject environment;
    void Start()
    {
        speed = rotateLevel.speed;
    }

    void Update()
    {
        GravityChanged();

        
        if (rotateLevel.isRotating == true && canParent)
        {
            Parent(environment, transform.gameObject);
            Rotate();
        }

        
        else
        {
           UnParent();
        }
        
    }

    void Parent(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
    }

    void UnParent()
    {
        transform.parent = null;
    }
 

    void Rotate()
    {
        Vector3 lookPosition = new Vector3(0f, 0f, target.position.z - transform.position.z);

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

    void GravityChanged()
    {
        if(playerGravity.gravityChanged == true)
        {
            Vector3 targetRotation = new Vector3(transform.rotation.x - 180f, transform.rotation.y, transform.rotation.z);
            transform.Rotate(targetRotation);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Entered " + other);

        if (other.name == "BlueCube" && interacting == false)
        {
            Debug.Log("Blue");
            if(rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                interacting = true;
                rotateLevel.rotateLeft = true;
                rotateLevel.isRotating = true;
            }
        }

        if (other.name == "OrangeCube" && interacting == false)
        {
            Debug.Log("Orange");
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                interacting = true;
                rotateLevel.rotateRight = true;
                rotateLevel.isRotating = true;
            }

        }

        if (other.name == "PurpleCube" && interacting == false)
        {
            Debug.Log("Purple");
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                interacting = true;
                rotateLevel.rotateUp = true;
                rotateLevel.isRotating = true;
            }
        }

        if (other.name == "YellowCube" && interacting == false)
        {
            Debug.Log("Yellow");
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                interacting = true;
                rotateLevel.rotateDown = true;
                rotateLevel.isRotating = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interacting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "environment")
        {
            canParent = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "environment")
        {
            canParent = false;
        }
    }
}
