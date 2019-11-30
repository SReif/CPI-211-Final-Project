using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRotate : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    public RotateLevel rotateLevel;
    public GameObject environment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateLevel.isRotating == true)
        {
            Parent(environment, transform.gameObject);
        }

        else
        {
            UnParent(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (floatingTextPrefab && !FindObjectOfType<FloatingText>() && other.gameObject.name != "DeathCube")
        {
            ShowFloatingText("Press 'F' to Interact", other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name != "DeathCube")
        {
            if (other.gameObject.name == "BlueCube" && Input.GetKeyUp("f"))
            {
                Debug.Log("Interacting with " + other.gameObject.name);
                rotateLevel.isCollidingOrange = false;
                rotateLevel.isCollidingBlue = true;
                rotateLevel.isCollidingYellow = false;
                FindObjectOfType<AudioManager>().Play("Interact");
            }

            if (other.gameObject.name == "YellowCube" && Input.GetKeyUp("f"))
            {
                Debug.Log("Interacting with " + other.gameObject.name);
                rotateLevel.isCollidingOrange = false;
                rotateLevel.isCollidingBlue = false;
                rotateLevel.isCollidingYellow = true;
                FindObjectOfType<AudioManager>().Play("Interact");
            }

            if (other.gameObject.name == "OrangeCube" && Input.GetKeyUp("f"))
            {
                Debug.Log("Interacting with " + other.gameObject.name);
                rotateLevel.isCollidingOrange = true;
                rotateLevel.isCollidingBlue = false;
                rotateLevel.isCollidingYellow = false;
                FindObjectOfType<AudioManager>().Play("Interact");
            }
        }
    }

    void Parent(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
    }

    void UnParent(GameObject child)
    {
        transform.parent = null;
    }

    void ShowFloatingText(string input, Transform obj)
    {
        floatingTextPrefab.GetComponent<TextMesh>().text = input;
        Instantiate(floatingTextPrefab, obj.position, Quaternion.identity * transform.rotation, obj);
    }
}
