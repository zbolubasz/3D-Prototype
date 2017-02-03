using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    private float movementSpeed = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
    }

    void OnCollisionEnter(Collision Coll)
    {
        if (Coll.gameObject.tag == ("Player")) ;
        Debug.Log("SELF");
    }
}
