using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public float firingRate = 2f;

    private Transform weaponTransform;

    void Start()
    {
        weaponTransform = transform.Find("Weapon").transform;
        //weaponTransform = gameObject.transform;
        StartCoroutine(Fire());
        //bulletPrefab = Resources.Load("Bullet") as Rigidbody;
    }

    IEnumerator Fire()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(firingRate);
            Rigidbody bullet = Instantiate(bulletPrefab, weaponTransform.position, Quaternion.identity) as Rigidbody;
            bullet.AddForce(weaponTransform.forward * 1000f);
        }
    }
}
