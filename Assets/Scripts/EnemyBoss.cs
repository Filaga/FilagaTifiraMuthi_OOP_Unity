using UnityEngine;

public class EnemyBoss : Enemy
{
    public Weapon weapon;
    public float shootInterval = 2f;
    private float shootTimer;
    public float speed = 3f;
    private bool movingRight;

    protected override void Start()
    {
        base.Start();
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize;
        transform.position = new Vector3(Random.value > 0.5f ? -screenWidth : screenWidth, Random.Range(-screenHeight, screenHeight), 0);
        
        movingRight = transform.position.x >= 0;
        shootTimer = shootInterval;
        if (weapon != null)
        {
            weapon.enabled = true;
        }
    }

    private void Update()
    {
        float moveDirection = movingRight ? 1 : -1;
        transform.Translate(Vector3.right * moveDirection * speed * Time.deltaTime);

        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        if (Mathf.Abs(transform.position.x) >= screenWidth)
        {
            movingRight = !movingRight;
        }
        shootTimer -= Time.deltaTime;

        /*if (weapon != null)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                Shoot();
                shootTimer = 0f;
            }
        }*/
    }

    private void Shoot()
    {
        if (weapon != null)
        {
            weapon.Shoot();
        }
    }
}

