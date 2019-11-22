using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTextScroll : MonoBehaviour
{
    public Transform text;
    public float scrollSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.transform.position += new Vector3(0f, scrollSpeed, scrollSpeed);
    }
}
