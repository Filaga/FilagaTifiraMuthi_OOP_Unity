using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;

    private Rigidbody2D rb;
    private IObjectPool<Bullet> objectPool;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

    public void Init(IObjectPool<Bullet> pool)
    {
        objectPool = pool;
    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
        if (rb != null){
            rb.velocity = transform.up * bulletSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            objectPool.Release(this);
        }
        if (other.CompareTag("Player"))
        {
            objectPool.Release(this);
        }
    }

    private void OnBecameInvisible()
    {
        objectPool.Release(this);
    }

    private void OnEnable()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
    }
}


