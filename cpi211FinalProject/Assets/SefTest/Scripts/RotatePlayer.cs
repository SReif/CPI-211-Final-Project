using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float speed;
    public Transform target;

    public RotateLevel rotateLevel;
    public PlayerGravity playerGravity;

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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered " + other);

        if (other.name == "BlueCube")
        {
            Debug.Log("Blue");
        }

        if (other.name == "OrangeCube")
        {
            Debug.Log("Orange");
        }

        if (other.name == "PurpleCube")
        {
            Debug.Log("Purple");
        }

        if (other.name == "YellowCube")
        {
            Debug.Log("Yellow");
        }
    }
}
