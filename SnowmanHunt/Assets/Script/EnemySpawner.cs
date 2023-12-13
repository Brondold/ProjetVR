using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    [SerializeField, Range(0, 1)] private float spawnChance = 0.02f; // Adjust the spawn chance

    public float SpawnRate
    {
        get { return spawnRate; }
        set { spawnRate = value; }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            // Generate a random number to determine if enemy should spawn
            if (Random.value <= spawnChance)
            {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyToSpawn = enemyPrefabs[rand];

                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            }
        }
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }
}
