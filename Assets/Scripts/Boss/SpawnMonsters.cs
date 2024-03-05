using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int numSpawnPoints = 2;
    public float spawnAreaRadius = 2f;

    void Start()
    {
        SpawnMonsters();
    }

    void SpawnMonsters()
    {
        for (int i = 0; i < numSpawnPoints; i++)
        {
            Vector2 spawnPoint = (Random.insideUnitCircle * spawnAreaRadius) + (Vector2)transform.position;

            Instantiate(monsterPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
