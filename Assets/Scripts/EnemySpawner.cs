using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;

    public bool isSpawning = false;

    private void Start()
    {
        ResetSpawnCount();
        StartCoroutine(SpawnEnemies());
    }

    public void ResetSpawnCount()
    {
        spawnCount = defaultSpawnCount * spawnCountMultiplier;
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (isSpawning && spawnCount > 0)
            {
                yield return new WaitForSeconds(spawnInterval);
                SpawnEnemy();
                spawnCount--;
            }
            else
            {
                yield return null; 
            }
        }
    }

    private void SpawnEnemy()
    {
        if (spawnedEnemy != null)
        {
            Enemy enemy = Instantiate(spawnedEnemy);
            enemy.combatManager = combatManager;
            enemy.enemySpawner = this;
        }
    }

    public void EnemyDefeated()
    {
        totalKill++;
        totalKillWave++;

        if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            spawnCountMultiplier += multiplierIncreaseCount;
            totalKillWave = 0;
        }
    }
}
