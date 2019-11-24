using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBody : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.gravity.y < 0)
        {
            transform.Rotate(0, 0, 0);
        }
        else
        {
            transform.Rotate(0, 180f, 0);
        }
    }
}
