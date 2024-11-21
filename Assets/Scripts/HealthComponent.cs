using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 100f;
    private float health;

    public float Health
    {
        get { return health; }
        private set { health = Mathf.Max(0, value); }
    }

    void Start()
    {
        health = maxHealth;
    }

    public void Subtract(float amount)
    {
        Health -= amount;
        Debug.Log("HP: " + Health);
        if (Health <= 0)
        {
            Destroy(gameObject);
            
        }
    }
}

