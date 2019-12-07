using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popText : MonoBehaviour
{
    private bool tip = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(tip == true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                transform.gameObject.SetActive(false);
                tip = false;
            }
        }
    }
}
