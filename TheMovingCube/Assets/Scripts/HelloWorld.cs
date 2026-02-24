using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    void Start()
    {
        int playerHealth = 49;
        CheckHealth(playerHealth);
        CheckHealth(0);
        CheckHealth(60);
    }

    void CheckHealth(int health)
    {
        if (health <= 0) 
        { 
            Debug.Log("Player Dead");
        } else if (health < 50)
        {
            Debug.Log("Player health is half");
        } else
        {
            Debug.Log("Player Alive");
        }
    }
}
