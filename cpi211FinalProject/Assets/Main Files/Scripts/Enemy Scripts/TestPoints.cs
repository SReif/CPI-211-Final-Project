using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoints : MonoBehaviour
{
    public Transform self;
    public float movementSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Entered " + other.transform.tag);
        if (other.gameObject.tag == "environment")
        {
            movementSpeed = -movementSpeed;
        }
        if (other.gameObject.tag == "Player")
        {
            movementSpeed = -movementSpeed;
            other.gameObject.GetComponent<HealthSystem>().Damage(10);
            Debug.Log("hit player");
        }
    }
}
