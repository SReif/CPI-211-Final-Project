using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBody : MonoBehaviour
{
    private bool canChange = false;
    private bool gravSet = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.gravity.y >= 0 && !canChange)
        {

            //transform.rotation = Quaternion.Euler(0f, player.rotation.y + 90f, 0f);
            transform.Rotate(0f, 180f, 180f, Space.Self);
            canChange = true;
            Debug.Log("ROTATED" + transform.rotation.y.ToString());
        }
        else if(Physics.gravity.y < 0 && canChange)
        {
            //transform.rotation = Quaternion.Euler(0f, player.rotation.y + 270f, 180f);
            transform.Rotate(0f, 180f, 180f, Space.Self);
            canChange = false;
            Debug.Log("ROTATED AGAIN");
        }
    }
}
