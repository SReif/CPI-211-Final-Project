using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float speed;
   //public Transform target;

    public RotateLevel rotateLevel;
    public PlayerGravity playerGravity;
    public bool interacting;

    public GameObject environment;
    void Start()
    {
        speed = rotateLevel.speed;
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

    /*
    //If using, include an object/empty object for the player to look at.
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
    */

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
        if (other.name == "BlueCube" && interacting == false)
        {
            if (rotateLevel.isRotating == false && Input.GetKeyDown("f"))
            {
                Debug.Log("Interacting");
                interacting = true;
                rotateLevel.rotateLeft = true;
                rotateLevel.isRotating = true;
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
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interacting = false;
    }
}
