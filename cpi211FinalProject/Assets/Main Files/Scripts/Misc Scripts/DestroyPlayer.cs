using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    private GameObject player;
    private int loadCount;
    Vector3 gravityVector;

    private void Start()
    {
        gravityVector = Physics.gravity;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(!player && loadCount == 0)
        {
            SceneManager.LoadScene("LoseScene", LoadSceneMode.Additive);
            loadCount = 1;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            Destroy(other.gameObject);
            Physics.gravity = gravityVector;
        }
    }

}
