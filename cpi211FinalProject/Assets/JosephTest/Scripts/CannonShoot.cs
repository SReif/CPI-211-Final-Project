﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public Transform CannonEmitter;
    public GameObject CannonBall;
    public float cannonSpeed = 1000;
    public float shotTime = 120;
    private float shotDelay = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotDelay--;
       if(shotDelay % shotTime == 0)
        {
            Fire(); 
        }
    }
    void Fire()
    {
        GameObject instBullet = Instantiate(CannonBall, CannonEmitter.position,CannonEmitter.transform.rotation) as GameObject;
        instBullet.GetComponent<Rigidbody>().AddForce(CannonEmitter.transform.up * cannonSpeed);
        Destroy(instBullet, 5);

    }
}
