using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private Bullet bulletPrefab;
    private HitboxComponent hitboxComponent;

    void Start()
    {
        hitboxComponent = GetComponent<HitboxComponent>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        InvincibilityComponent invincibilityComponent = other.GetComponent<InvincibilityComponent>();
        Debug.Log("S1");
        if (invincibilityComponent != null && !invincibilityComponent.isInvincible)
        {
            Debug.Log("S2");
            invincibilityComponent.StartBlinking();

            HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
            if (hitbox != null)
            {
                Debug.Log("S3");
                hitbox.Damage(damage);
            }
        }
    }
}

