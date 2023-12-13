using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] enemySpawners;
    [SerializeField] private float initialSpawnRate = 1f;
    [SerializeField] private float spawnRateIncreaseRate = 0.1f;
    [SerializeField] private float maxSpawnRate = 3f;

    private void Start()
    {
        StartCoroutine(AdjustSpawnRates());
    }

    private IEnumerator AdjustSpawnRates()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        while (true)
        {
            yield return wait;

            // Increase spawn rate for all spawners
            foreach (EnemySpawner spawner in enemySpawners)
            {
                spawner.SpawnRate += spawnRateIncreaseRate;

                // Clamp spawn rate to a maximum value
                spawner.SpawnRate = Mathf.Min(spawner.SpawnRate, maxSpawnRate);
            }
        }
    }
}
