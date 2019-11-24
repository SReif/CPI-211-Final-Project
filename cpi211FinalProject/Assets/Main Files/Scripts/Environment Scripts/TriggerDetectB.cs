using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetectB : MonoBehaviour
{
    public RotateLevel envRot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            envRot.isCollidingBlue = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            envRot.isCollidingBlue = false;
        }
    }
}
