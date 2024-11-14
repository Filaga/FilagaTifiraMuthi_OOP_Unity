using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 3f;
    private bool movingRight;

    protected override void Start()
    {
        base.Start();

        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize;
        transform.position = new Vector3(Random.value > 0.5f ? -screenWidth : screenWidth, Random.Range(-screenHeight, screenHeight), 0);
        
        movingRight = transform.position.x >= 0;
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
    }
}

