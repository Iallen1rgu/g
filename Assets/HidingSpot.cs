using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerVisibility playerVisibility = collision.GetComponent<PlayerVisibility>();
            if (playerVisibility != null)
            {
                playerVisibility.SetHiding(true); // Set player to hidden
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerVisibility playerVisibility = collision.GetComponent<PlayerVisibility>();
            if (playerVisibility != null)
            {
                playerVisibility.SetHiding(false); // Set player to visible again
            }
        }
    }
}



