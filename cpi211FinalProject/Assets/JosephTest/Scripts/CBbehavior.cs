using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthSystem>().Damage(10);
        }
        if (collision.gameObject.tag == "untagged" || collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
