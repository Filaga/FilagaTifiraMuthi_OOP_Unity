using UnityEngine;

public class EnemyTargeting : Enemy
{
    public float speed = 4f;
    private Transform player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 targetPosition = player.position;
            targetPosition.y += 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

