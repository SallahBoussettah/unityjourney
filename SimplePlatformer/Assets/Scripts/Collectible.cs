using UnityEngine;

public class Collectible : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddScore(1); // Add 1 point to the player's score
                player.PlaySoundEffect(player.collectibleSound);
                Destroy(gameObject); // Destroy the collectible after it's collected
            }
        }
    }
}
