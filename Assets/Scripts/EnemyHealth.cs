using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float startingHealth;
    public float currentHealth;
    public float playerDamage = 2;

 

	void Awake()
    {
        currentHealth = currentHealth + startingHealth;
        
    }
	
	public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == ("PlayerShot"))
        {
            currentHealth -= playerDamage;
            Destroy(coll.gameObject);
            Debug.Log("Hit");
        }
    }
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Dead");
        }
        
        
          
        }
    
}
