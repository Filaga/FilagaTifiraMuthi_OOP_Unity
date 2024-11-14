using UnityEngine;

public class EnemyForward : Enemy
{
    public float speed = 3f;
    private bool movingUp;

    protected override void Start()
    {
        base.Start();

        float screenHeight = Camera.main.orthographicSize;
        float screenWidth = screenHeight * Camera.main.aspect;
        transform.position = new Vector3(Random.Range(-screenWidth, screenWidth), Random.value > 0.5f ? -screenHeight : screenHeight, 0);

        movingUp = transform.position.y < 0;
    }

    private void Update()
    {
        float moveDirection = movingUp ? 1 : -1;
        transform.Translate(Vector3.up * moveDirection * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.y) > Camera.main.orthographicSize)
        {
            movingUp = !movingUp;
        }
    }
}
