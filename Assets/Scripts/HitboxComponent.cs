using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent health;

    void Start()
    {
        health = GetComponent<HealthComponent>();
    }

    public void Damage(Bullet bullet)
    {
        if (health != null)
        {
            InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();
            Debug.Log("Is Invincible: " + (invincibility != null && invincibility.isInvincible));
            if (invincibility != null && invincibility.isInvincible)
            {
                Debug.Log("Invincible, no damage taken");
                return;
            }
            Debug.Log("Damage received: " + bullet.damage);
            health.Subtract(bullet.damage);
        }
    }

    public void Damage(int damage)
    {
        if (health != null)
        {
            InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();

            if (invincibility != null && invincibility.isInvincible)
            {
                health.Subtract(damage);
                return;
            }

            health.Subtract(damage);
        }
    }
}


