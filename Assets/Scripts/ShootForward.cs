using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour {

    public Rigidbody bullet;
    public float velocity;
    public bool canShoot;

    private void Start()
    {
        canShoot = true;
    }
 
	void Update () {
        if (canShoot == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
                newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
            }
        }
	}
}
