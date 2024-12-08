using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    private Rigidbody2D rb; // Reference to Rigidbody2D
    private Vector2 movement; // Stores player movement direction

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get player input for horizontal and vertical movement
        movement.x = Input.GetAxisRaw("Horizontal"); // Left/Right or A/D
        movement.y = Input.GetAxisRaw("Vertical");   // Up/Down or W/S
    }

    void FixedUpdate()
    {
        // Apply movement using Rigidbody2D
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        Debug.Log("Player hit an enemy!");
        FindObjectOfType<LifeSystem>().LoseLife(); // Call LoseLife from LifeSystem script
    }
}

}




