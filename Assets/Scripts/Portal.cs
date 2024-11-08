using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    Vector2 newPosition;

    void Start()
    {
        ChangePosition();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }

        if (Player.Instance != null && Player.Instance.HasWeapon())
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Main");
        }
    }

    void ChangePosition()
    {
        newPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }
}
