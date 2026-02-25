using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ArenaPlayer : MonoBehaviour
{
    // Health
    public float currenthealth = 100f;
    public float maxHealth = 100f;

    // Movement Speed
    public float currentSpeed = 15f;
    public float walkSpeed = 15f;
    public float sprintSpeed = 30f;

    // Stamina
    public float currentStamina = 100f;
    public float maxStamina = 100f;
    public float gainStamina = 25f;
    public float drainStamina = 20f;
    public bool isExhausted;

    // isMoving and isAlive
    public bool isMoving;
    public bool isAlive = true;

    // Score count
    public int currentScore;

    Rigidbody rb;

    public TextMeshProUGUI ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive) { return; }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) { isMoving = true; } else { isMoving = false; }

        if (Input.GetKey(KeyCode.LeftShift) && !isExhausted && isMoving)
        {
            currentStamina = currentStamina - (drainStamina * Time.deltaTime);
            currentSpeed = sprintSpeed;
            if (currentStamina <= 0)
            {
                isExhausted = true;
            }
        } else
        {
            currentSpeed = walkSpeed;
            if (currentStamina < maxStamina)
            {
                if(!isMoving)
                {
                    currentStamina = currentStamina + (2 * gainStamina * Time.deltaTime);
                } else
                {
                    currentStamina = currentStamina + (gainStamina * Time.deltaTime);
                }
            }
            if (currentStamina > 50)
            {
                isExhausted = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(25);   
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(25);   
        }
    }

    public void AddScore(int amount)
    {
        currentScore = currentScore + amount;
        ui.text = "Score: " + currentScore;
    }
    
    void TakeDamage(int amount)
    {
        if (!isAlive) { return; }

        currenthealth = currenthealth - amount;
        if (currenthealth <= 0)
        {
            isAlive = false;
        }

    }

    void Heal(int amount)
    {
        if(!isAlive) { return; }

        if (currenthealth < maxHealth)
        {
            currenthealth = currenthealth + amount;
        }
        if (currenthealth > maxHealth)
        {
            currenthealth = maxHealth;
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;

        if (!isAlive) { return; }
        // Checking inputs
        if (Input.GetKey(KeyCode.W))
        {
            direction.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.z -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1;
        }
        direction = direction.normalized;
        rb.MovePosition(transform.position + direction *  currentSpeed * Time.fixedDeltaTime);
    }
}
