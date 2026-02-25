using UnityEngine;

public class ArenaPlayer : MonoBehaviour
{
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public float currentSpeed;
    public float walkSpeed = 10f;
    public float sprintSpeed = 25f;
    public float stamina = 100f;
    public float staminaMax = 100f;
    public float staminaGain = 20f;
    public float staminaDrain = 10f;
    public bool isExhausted;
    public bool isMoving;
    public bool isAlive = true;  
    
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Health: " + currentHealth);
        Debug.Log("Stamina: " + stamina);
    }

    void Update()
    {
        //Check if the player is alive
        if (!isAlive) { return; }

        //Check if the player is moving
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
        { 
            isMoving = true; 
        } else
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && !isExhausted && isMoving)
        {
            currentSpeed = sprintSpeed;
            stamina = stamina - (staminaDrain * Time.deltaTime);
            if (stamina <= 0)
            {
                isExhausted = true;
            }
        } else
        {
            currentSpeed = walkSpeed;
            if (stamina < staminaMax)
            {
                if (!isMoving)
                {
                    stamina = stamina + (2 * staminaGain * Time.deltaTime);
                } else
                {
                    stamina = stamina + (staminaGain * Time.deltaTime);
                }
            }
            if (stamina > 50)
            {
                isExhausted = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(25);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(20);
        }
        
    }

    void TakeDamage(float damage)
    {
        currentHealth =  currentHealth - damage;
        Debug.Log("Player took " + damage + " Damage!");
        if (currentHealth <= 0)
        {
            isAlive = false;
            Debug.Log("Player is Dead!");
        }
    }

    void Heal(float healAmount)
    {
        if (!isAlive)
        {
            return;
        }
        if (currentHealth < maxHealth)
        {
            float healing = currentHealth + healAmount;
            currentHealth = healing;
            Debug.Log("Player's health is : " + currentHealth + " and healed : " + healAmount + "!");
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;

        if (!isAlive)
        {
            return;
        }
        // Checking movement;
        if (Input.GetKey(KeyCode.W))
        {
            direction.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;
        }
        direction = direction.normalized;
        rb.MovePosition(transform.position + direction * currentSpeed * Time.fixedDeltaTime);

    }
}
