using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    private GameObject player;
    private int loadCount;
    Vector3 gravityVector;

    public SceneLoader loader;

    public Transform spawnPoint;

    public Transform stage;

    private bool canLoseLife = true;

    private void Start()
    {
        gravityVector = Physics.gravity;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(/*!player*/player.GetComponent<HealthSystem>().health <= 0 && loadCount == 0 && player.GetComponent<HealthSystem>().lives <= 0)
        {
            player.GetComponent<SimpleTestMove>().enabled = false;
            player.GetComponent<HealthSystem>().enabled = false;
            SceneManager.LoadScene("LoseScene", LoadSceneMode.Additive);
            loadCount = 1;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(/*!player*/player.GetComponent<HealthSystem>().health <= 0 && loadCount == 0 && player.GetComponent<HealthSystem>().lives > 0 && canLoseLife)
        {
            stage.rotation = Quaternion.Euler(0, 0, 0);
            player.GetComponent<HealthSystem>().lives -= 1;
            player.GetComponent<HealthSystem>().health = 100f;
            //loader.Retry();
            player.transform.position = spawnPoint.position;
            //canLoseLife = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<HealthSystem>().health = 0;
            Physics.gravity = gravityVector;
        }
    }

}
