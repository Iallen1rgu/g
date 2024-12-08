using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    private bool isHiding = false; // Tracks if the player is hiding
    private SpriteRenderer spriteRenderer; // To change transparency
    private Collider2D playerCollider; // Reference to the player's collider

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    public bool IsHiding()
    {
        return isHiding;
    }

    public void SetHiding(bool hiding)
    {
        isHiding = hiding;

        // Adjust transparency to indicate hiding
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = hiding ? 0.5f : 1f; // Semi-transparent when hiding
            spriteRenderer.color = color;
        }

        // Ignore collisions with enemies when hiding
        if (playerCollider != null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Collider2D enemyCollider = enemy.GetComponent<Collider2D>();
                if (enemyCollider != null)
                {
                    Physics2D.IgnoreCollision(playerCollider, enemyCollider, hiding);
                }
            }
        }
    }
}


