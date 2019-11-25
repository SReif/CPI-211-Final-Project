using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotationSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x -180f, transform.rotation.y + 180f, transform.rotation.z + 0f);
        Physics.gravity *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
