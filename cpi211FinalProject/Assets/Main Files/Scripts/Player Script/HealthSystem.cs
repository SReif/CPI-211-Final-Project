using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float health;
    public int lives = 3;

    public SceneLoader loader;

    public GameObject self;
    public GameObject explosion;
    public GameObject player;

    public bool iFrame;
    public float timer;
    public float waitTime = 1.0f;

    public GameObject body;
    public Material p_Material;

    public Text livesDisplay;

    private GameObject playerObject;
    private Rigidbody playerRigidbody;
    private bool died = false;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = playerObject.GetComponent<Rigidbody>();
        loader = FindObjectOfType<SceneLoader>();
        health = MaxHealth;
        p_Material.SetFloat("_alpha", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        checkStatus();
        invincibilityFrame();
        livesDisplay.text = "Lives: " + lives.ToString();
        if (died)
        {
            playerRigidbody.velocity = new Vector3(0f, 0f, 0f);
            died = false;
            Debug.Log("Fix momentum?");
        }
    }

    public void Damage(float damageAmount)
    {
        if(iFrame == false)
        {
            health -= damageAmount;
            iFrame = true;
            FindObjectOfType<AudioManager>().Play("Hurt");
        } 
    }
    public void checkStatus()
    {
        if (health <= 0)
        {
            Debug.Log(gameObject.name + " died");
            if(gameObject.tag == "Enemy")
            {
                Destroy(self, 2f * Time.deltaTime);
                //Instantiate(explosion, self.transform.position, self.transform.rotation);
            }

            /*if(gameObject.tag == "Player")
            {
                if(lives <= 0)
                {
                    Physics.gravity = new Vector3(0f, -9.8f, 0);
                    //Destroy(self);
                }
                else
                {
                    Physics.gravity = new Vector3(0f, -9.8f, 0);
                    //lives -= 1;
                    //loader.Retry();
                }
                //FindObjectOfType<SceneLoader>().Lose();
                //Instantiate(explosion, self.transform.position, self.transform.rotation);
            }
            died = true;*/
           // Debug.Log("Fires");
        }
    }

    //sets player's ability to become damaged to false for a set amount of time.
    public void invincibilityFrame()
    {
        
        if (iFrame == true)
        {
            p_Material.SetFloat("_alpha", timer/waitTime);
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                p_Material.SetFloat("_alpha", 1f);
                timer = 0f;
                iFrame = false;
            }
        }

    }
}
