using UnityEngine;

public class DamageCalculator : MonoBehaviour
{
    void Start()
    {
        int playerHealth = 100;
        int playerArmor = 100;
        TakeDamage(playerArmor, 400);
    }
    
    void TakeDamage(int armor, int damage)
    {
        int playerDamage = 0;
        if (armor > damage)
        {
            Debug.Log("Armor is greater than the Damage taken");
        } else
        {
            playerDamage = damage - armor;
            Debug.Log("Player had taken " + playerDamage + " Damage");
        }
    }
}
