using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float timeBetweenAttacks;
    public int attackDamage = 10;

    GameObject player;
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    float timer;

    public Object shot;
    public float velocity;
    private float AttackSpeed = 1f;

    private bool ready;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shot = Resources.Load("Shot");
        playerHealth = player.GetComponent<PlayerHealth>();


        //enemyHealth = GetComponent<EnemyHealth>();

    }
    void Start()
    {
        //ready = true;
    }

    void FixedUpdate()
    {
        
       // EnemyShoot();
        ready = false;

    }

    private IEnumerator CoolDown()
    {

        if (shot != null)
        {
            // ready = false;
            while (true)
                if (ready == true)
                {
                    yield return new WaitForSeconds(AttackSpeed);
                    // ready = false;
                    GameObject newBullet = Instantiate(Resources.Load("Shot"), player.transform.position, player.transform.rotation) as GameObject;
                    // Rigidbody newBullet = Instantiate(shot, transform.position, transform.rotation) as Rigidbody;
                    
                    ready = true;
                    Debug.Log("Shot");
                }
        }
    }
    void EnemyShoot()
    {
        
        {
            StartCoroutine(CoolDown());
        }
    }
}
