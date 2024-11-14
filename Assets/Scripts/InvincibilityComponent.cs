using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [Header("Invincibility Settings")]
    [SerializeField] private int blinkingCount = 7;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;

    public bool isInvincible = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalMaterial = spriteRenderer.material;
    }

    public IEnumerator Blink()
    {
        if (isInvincible)
            yield break;

        isInvincible = true;

        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;

            yield return new WaitForSeconds(blinkInterval);

            spriteRenderer.material = originalMaterial;

            yield return new WaitForSeconds(blinkInterval);
        }

        isInvincible = false;
    }

    public void StartBlinking()
    {
        if (!isInvincible)
        {
            StartCoroutine(Blink());
        }
    }
}

