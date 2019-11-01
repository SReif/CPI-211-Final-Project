using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityChange : MonoBehaviour
{
    // Start is called before the first frame update
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
}
