using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public Transform CannonEmitter;
    public GameObject CannonBall;
    public float cannonSpeed = 1000;
    public float shotDelay = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotDelay--;
       if(shotDelay % 80 == 0)
        {
            Fire(); 
        }
    }
    void Fire()
    {
        GameObject instBullet = Instantiate(CannonBall, CannonEmitter.position,CannonEmitter.transform.rotation) as GameObject;

        //CannonBall.transform.position += transform.forward * cannonSpeed * Time.deltaTime;

        instBullet.GetComponent<Rigidbody>().AddForce(CannonEmitter.transform.up * cannonSpeed);

    }
}
