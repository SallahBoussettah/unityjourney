using UnityEngine;

public class Collectible : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ArenaPlayer player = other.GetComponent<ArenaPlayer>();
            player.AddScore(1);
            Debug.Log("Item collected!");
            Destroy(gameObject);
        }
    }

}
