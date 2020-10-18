using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{

    public GameObject _enemy;
    public GameObject _enemy2;
    public GameObject _enemy3;
    public GameObject _enemy4;
    public int xPos;
    public int zPos;
    public int _enemyCount;

    void Start()
    {
        StartCoroutine(Enemy1Drop());
        StartCoroutine(Enemy2Drop());
        StartCoroutine(Enemy3Drop());
        StartCoroutine(Enemy4Drop());
    }

    IEnumerator Enemy1Drop()
    {
        while (_enemyCount < 5)
        {
            xPos = Random.Range(320, 340);
            zPos = Random.Range(2, 15);
            Instantiate(_enemy, new Vector3(xPos, 207, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            _enemyCount += 1;
        }
    }

    IEnumerator Enemy2Drop()
    {
        while (_enemyCount < 6)
        {
            xPos = Random.Range(320, 340);
            zPos = Random.Range(2, 15);
            Instantiate(_enemy2, new Vector3(xPos, 207, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3);
            _enemyCount += 1;
        }
    }

    IEnumerator Enemy3Drop()
    {
        while (_enemyCount < 5)
        {
            xPos = Random.Range(320, 340);
            zPos = Random.Range(2, 15);
            Instantiate(_enemy3, new Vector3(xPos, 207, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);
            _enemyCount += 1;
        }
    }

    IEnumerator Enemy4Drop()
    {
        while (_enemyCount < 5)
        {
            xPos = Random.Range(320, 340);
            zPos = Random.Range(2, 15);
            Instantiate(_enemy4, new Vector3(xPos, 207, zPos), Quaternion.identity);
            yield return new WaitForSeconds(6);
            _enemyCount += 1;
        }
    }
}
