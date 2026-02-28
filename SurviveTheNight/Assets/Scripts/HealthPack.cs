using UnityEngine;

public class HealthPack : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            PlayerController player = other.GetComponent<PlayerController>();
            player.AddItem("HealthPack");
            Destroy(gameObject);
        }
    }
}
