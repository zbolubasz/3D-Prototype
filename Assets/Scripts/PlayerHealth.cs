 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth;
    public int currentHealth;

    PlayerMove playerMovement;
    ShootForward canShoot;
    public bool isDead;
    public GameObject weapon1;
    public GameObject weapon2;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMove>();
        canShoot = GetComponentInChildren<ShootForward>();

        currentHealth = startingHealth;
    }	

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == ("EnemyShot"));
        TakeDamage(1);
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
            
        }
    }
    void Death()
    {
        isDead = true;
        playerMovement.enabled = false;
        canShoot.enabled = false;
        //GameObject.weapon1.enabled = false;
        //weapon2.enabled = false;
    }
}
