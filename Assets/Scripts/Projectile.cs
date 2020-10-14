using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float MoveSpeed;
    private Transform Player;
    private Vector3 target;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerBody").transform;

        target = new Vector3(Player.position.x, Player.position.y, Player.position.z);
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
