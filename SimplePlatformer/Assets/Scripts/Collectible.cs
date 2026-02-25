using UnityEngine;

public class Collectible : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.AddScore(1);
            Destroy(gameObject);
        }
    }
}
