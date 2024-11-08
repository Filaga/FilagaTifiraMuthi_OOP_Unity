using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder;
    Weapon weapon;

    void Awake()
    {
        weapon = null;
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (weapon != null)
            {
                Destroy(weapon.gameObject);
            }

            weapon = Instantiate(weaponHolder, other.transform);
            weapon.transform.localPosition = Vector3.zero;
            TurnVisual(true);
            Player.Instance.PickUpWeapon();
        }
    }

    void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            foreach (var renderer in weapon.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.enabled = on;
            }

            foreach (var collider in weapon.GetComponentsInChildren<Collider2D>())
            {
                collider.enabled = on;
            }
        }
    }
}