using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWayPoint : MonoBehaviour
{
    public Transform self;
    public float movementSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "environment")
        {
            movementSpeed = -movementSpeed;
            //FindObjectOfType<AudioManager>().Play("Thud");
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthSystem>().Damage(10);
        }
    }
}

