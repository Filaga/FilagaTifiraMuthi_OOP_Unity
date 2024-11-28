using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level = 1;

    private Rigidbody2D rb;
    public CombatManager combatManager;
    public EnemySpawner enemySpawner;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    protected virtual void Start()
    {
        //FacePlayer();
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public int GetLevel()
    {
        return level;
    }

    private void OnDestroy()
    {
        if (combatManager != null)
        {
            combatManager.EnemyDefeated(level);
            
        }
        if (enemySpawner != null)
        {
            enemySpawner.EnemyDefeated();
        }
    }


}


