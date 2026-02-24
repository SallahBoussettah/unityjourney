using UnityEngine;

public class CombatSimulator : MonoBehaviour
{
    void Start()
    {
        int playerHealth = 100;
        int playerArmor = 100;

        playerHealth = TakeDamage(playerHealth, playerArmor, 50);
        CheckHealth(playerHealth);

        playerHealth = TakeDamage(playerHealth, playerArmor, 150);
        CheckHealth(playerHealth);

        playerHealth = TakeDamage(playerHealth, playerArmor, 350);
        CheckHealth(playerHealth);

    }

    int TakeDamage (int health, int armor, int damage)
    {

        if (armor > damage)
        {
            Debug.Log("No damage taken");
        } else
        {
            int actualDamage = damage - armor;
            health = health - actualDamage;
            Debug.Log("Player took " + actualDamage + " damage, Health: " + health);
        }
        
        return health;
    }

    void CheckHealth (int health)
    {
        if (health <= 0)
        {
            Debug.Log("Player's dead");
        } else if (health < 50)
        {
            Debug.Log("Player's health below half");
        } else
        {
            Debug.Log("Player's alive");
        }
    }
}
