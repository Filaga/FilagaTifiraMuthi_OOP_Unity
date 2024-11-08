using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;
    Vector2 moveDirection;
    Vector2 moveVelocity;
    Vector2 moveFriction;
    Vector2 stopFriction;
    Rigidbody2D rb;

    private float minX, maxX, minY, maxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        minX = bottomLeft.x +0.35f;
        maxX = topRight.x -0.35f;
        minY = bottomLeft.y;
        maxY = topRight.y -0.6f;
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(inputX, inputY).normalized;

        Vector2 targetVelocity = moveDirection * maxSpeed;
        Vector2 friction = GetFriction();
        Vector2 newVelocity = targetVelocity + friction * Time.fixedDeltaTime;

        newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed.x, maxSpeed.x);
        newVelocity.y = Mathf.Clamp(newVelocity.y, -maxSpeed.y, maxSpeed.y);
        rb.velocity = newVelocity;

        if (newVelocity.magnitude < stopClamp.magnitude)
        {
            rb.velocity = Vector2.zero;
        }

        MoveBound();
    }

    Vector2 GetFriction()
    {
        if (moveDirection.magnitude > 0)
        {
            return moveFriction * moveDirection;
        }
        else
        {
            return stopFriction * rb.velocity.normalized;
        }
    }

    void MoveBound()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0;
    }
}
