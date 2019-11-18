using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float health;
    public GameObject self;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        checkStatus();
    }

    public void Damage(float damageAmount)
    {
        health -= damageAmount;
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
        }
    }
}
