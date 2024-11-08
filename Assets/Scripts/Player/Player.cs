using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    PlayerMovement playerMovement;
    Animator animator;
    bool hasWeapon = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        GameObject engineEffect = GameObject.Find("EngineEffect");
        if (engineEffect != null)
        {
            animator = engineEffect.GetComponent<Animator>();
        }
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        if (animator != null)
        {
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
    }

    public void PickUpWeapon()
    {
        hasWeapon = true;
    }

    public bool HasWeapon()
    {
        return hasWeapon;
    }
}
