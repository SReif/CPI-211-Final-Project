using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRotate : MonoBehaviour
{
    public GameObject floatingTextPrefab, interactables, orangeCubePrefab, blueCubePrefab, yellowCubePrefab;
    private GameObject tempPrefab;
    private RotateLevel rotateLevel;
    private GameObject environment;
    public bool switched;

    // Start is called before the first frame update
    void Start()
    {
        rotateLevel = FindObjectOfType<RotateLevel>();
        environment = GameObject.FindGameObjectWithTag("environment");

        tempPrefab = orangeCubePrefab;
        rotateLevel.isCollidingOrange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateLevel.isRotating == true)
        {
            Parent(environment, transform.gameObject);
            Debug.Log("Parented");
        }

        else
        {
            UnParent(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (floatingTextPrefab && !FindObjectOfType<FloatingText>() && other.gameObject.name != "DeathCube" && other.gameObject.name != "DeathPanel" && other.gameObject.name != "Portal")
        {
            ShowFloatingText("[F] Interact", other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name != "DeathCube")
        {
            if (other.gameObject.name == "BlueCube" && Input.GetKeyUp("f") || other.gameObject.name == "BlueCube(Clone)" && Input.GetKeyUp("f"))
            {
                Debug.Log("Interacting with " + other.gameObject.name);
                rotateLevel.isCollidingOrange = false;
                rotateLevel.isCollidingBlue = true;
                rotateLevel.isCollidingYellow = false;
                FindObjectOfType<AudioManager>().Play("Interact");
                ChangeCube(other.gameObject);
            }

            if (other.gameObject.name == "YellowCube" && Input.GetKeyUp("f") || other.gameObject.name == "YellowCube(Clone)" && Input.GetKeyUp("f"))
            {
                Debug.Log("Interacting with " + other.gameObject.name);
                rotateLevel.isCollidingOrange = false;
                rotateLevel.isCollidingBlue = false;
                rotateLevel.isCollidingYellow = true;
                FindObjectOfType<AudioManager>().Play("Interact");
                ChangeCube(other.gameObject);
            }

            if (other.gameObject.name == "OrangeCube" && Input.GetKeyUp("f") || other.gameObject.name == "OrangeCube(Clone)" && Input.GetKeyUp("f"))
            {
                Debug.Log("Interacting with " + other.gameObject.name);
                rotateLevel.isCollidingOrange = true;
                rotateLevel.isCollidingBlue = false;
                rotateLevel.isCollidingYellow = false;
                FindObjectOfType<AudioManager>().Play("Interact");
                ChangeCube(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switched = false;
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

    void ChangeCube(GameObject obj)
    {
        if(!switched)
        {
            Instantiate(tempPrefab, obj.transform.position, Quaternion.identity, interactables.transform);
            Destroy(obj);
            switched = true;
        }

        if (rotateLevel.isCollidingOrange == true)
        {
            tempPrefab = orangeCubePrefab;
        }

        if(rotateLevel.isCollidingBlue == true)
        {
            tempPrefab = blueCubePrefab;
        }

        if (rotateLevel.isCollidingYellow == true)
        {
            tempPrefab = yellowCubePrefab;
        }
    }
}
