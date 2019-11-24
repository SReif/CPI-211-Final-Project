using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class freelook : MonoBehaviour
{
    public CinemachineFreeLook free;
    public CinemachineVirtualCamera follower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            free.Priority = 99;
        }
        else
        {
            free.Priority = 5;
        }
    }
}
