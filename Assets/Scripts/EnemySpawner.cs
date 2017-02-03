using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject fractalChild;
    public float spawnRate = 1f;

    

    void Start()
    {
        StartCoroutine(Spawn());
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            
            //Zac Added
            GameObject enemyPrefab = Resources.Load("Enemy") as GameObject;
            Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);

        }
    }
}
