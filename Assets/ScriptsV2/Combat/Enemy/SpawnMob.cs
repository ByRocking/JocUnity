using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawner;
    public int number;
    public int spawnRate;

    bool spawned = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kevin") && !spawned)
        {
            spawned = true;
            StartCoroutine(StartSpawn());
        }
    }

    public void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }

    IEnumerator StartSpawn()
    {
        for (int i = 1; i <= number; i++)
        {
            Invoke("SpawnEnemy",0f);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
