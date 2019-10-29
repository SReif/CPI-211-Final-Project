using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public Transform CannonEmitter;
    public GameObject CannonBall;
    public float cannonSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fire()
    {
        GameObject instBullet = Instantiate(CannonBall, CannonEmitter.position, CannonEmitter.rotation) as GameObject;
        instBullet.GetComponent<Rigidbody>().AddForce(transform.forward * cannonSpeed);

    }
}
