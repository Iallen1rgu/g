using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f; // Movement speed
    public Transform pointA; // First patrol point
    public Transform pointB; // Second patrol point
    public Transform player; // Reference to the player
    public float detectionRange = 5f; // Range to detect the player

    private Transform currentTarget; // Current patrol target
    private PlayerVisibility playerVisibility; // Reference to the player's visibility script

    void Start()
    {
        currentTarget = pointA; // Start at point A

        if (player != null)
        {
            playerVisibility = player.GetComponent<PlayerVisibility>();
        }
    }

    void Update()
    {
        // Check if the player is hiding or out of detection range
        if (player != null && playerVisibility != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange && !playerVisibility.IsHiding())
            {
                // If the player is not hiding and is in range, chase the player
                ChasePlayer();
            }
            else
            {
                // Otherwise, patrol between the points
                Patrol();
            }
        }
        else
        {
            // If no player or visibility script is found, continue patrolling
            Patrol();
        }
    }

    void Patrol()
    {
        // Move towards the current patrol target
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // Switch target when close to the current one
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }

    void ChasePlayer()
    {
        // Move towards the player's position
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}




