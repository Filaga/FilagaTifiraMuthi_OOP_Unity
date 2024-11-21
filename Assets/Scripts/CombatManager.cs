using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Enemy Spawners")]
    public EnemySpawner[] enemySpawners;

    public float timer = 0;
    [SerializeField] private float waveInterval = 5f; 

    public int waveNumber = 1;
    public int totalEnemies = 0;

    private void Start()
    {
        foreach (var spawner in enemySpawners)
        {
            spawner.combatManager = this;
        }

        StartWave();
    }

    private void StartWave()
    {
        totalEnemies = 0;

        foreach (var spawner in enemySpawners)
        {
            if (spawner.spawnedEnemy.level <= waveNumber)
            {
                spawner.isSpawning = true;
                spawner.ResetSpawnCount();
                totalEnemies += spawner.spawnCount;
            }
        }
    }

    public void EnemyDefeated()
    {
        totalEnemies--;

        if (totalEnemies <= 0)
        {
            StartCoroutine(NextWave());
        }
    }

    private IEnumerator NextWave()
    {
        foreach (var spawner in enemySpawners)
        {
            spawner.isSpawning = false;
        }

        timer = waveInterval;

        while (timer > 0)
        {
            timer -= Time.deltaTime; 
            yield return null;      
        }

        waveNumber++;
        StartWave();
    }
}

