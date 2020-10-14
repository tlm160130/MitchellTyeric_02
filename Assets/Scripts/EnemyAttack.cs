using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float health = 40f;
    public Transform Player;
    public float MoveSpeed;
    public float MaxDist;
    public float MinDist;
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public ParticleSystem muzzleFlash;

    [SerializeField]
    private AudioSource shootSound;

    public GameObject projectile;

    void Start()
    {
        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) > MaxDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
        } else if(Vector3.Distance(transform.position, Player.position) < MinDist && Vector3.Distance(transform.position, Player.position) > MaxDist)
        {
            transform.position = this.transform.position;
        } else if (Vector3.Distance(transform.position, Player.position) < MaxDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, -MoveSpeed * Time.deltaTime);
        }

        if (timeBetweenShots <= 0)
        {
            FireAttack();
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        } else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void FireAttack()
    {
        muzzleFlash.Play();
        shootSound.Play();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
