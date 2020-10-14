using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public float damage = 10f;
    public float range = 100f;
    public float ImpactForce = 100f;
    public float FireRate = 20f;
    public Camera fpsCam;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    [SerializeField] 
    private AudioSource shootSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/ FireRate;
            Shoot();
        }
    }

    //Fire the Weapon/RayCast
    void Shoot()
    {
        //calculate direction to shoot the ray
        //cast a debug ray
        //fire the raycast
        muzzleFlash.Play();
        shootSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
           EnemyAttack enemy = hit.transform.GetComponent<EnemyAttack>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * ImpactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
