using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float health;

    public GameObject self;
    public GameObject explosion;
    public GameObject player;

    public bool iFrame;
    public float timer;
    public float waitTime = 1.0f;

    public GameObject body;
    private Material p_Material;
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        p_Material = body.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        checkStatus();
        invincibilityFrame();
    }

    public void Damage(float damageAmount)
    {
        if(iFrame == false)
        {
            health -= damageAmount;
            iFrame = true;
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
                Instantiate(explosion, self.transform.position, self.transform.rotation);
            }

            if(gameObject.tag == "Player")
            {
                Destroy(self);
                Instantiate(explosion, self.transform.position, self.transform.rotation);

                //FindObjectOfType<SceneLoader>().Lose();
            }
        }
    }

    //sets player's ability to become damaged to false for a set amount of time.
    public void invincibilityFrame()
    {
        
        if (iFrame == true)
        {
            p_Material.color = new Color(p_Material.color.r, p_Material.color.g, p_Material.color.b, timer/waitTime);
            timer += Time.deltaTime;
            Debug.Log(timer);

            if (timer >= waitTime)
            {
                p_Material.color = new Color(p_Material.color.r, p_Material.color.g, p_Material.color.b, 1f);
                timer = 0f;
                iFrame = false;
            }
        }

        body.GetComponent<Renderer>().material.color = p_Material.color;
    }
}
