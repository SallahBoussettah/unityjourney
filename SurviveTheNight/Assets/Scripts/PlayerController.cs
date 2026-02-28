using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Rigidbody refrence and walkspeed
    Rigidbody rb;
    public float walkSpeed = 10f;
    public float jumpForce = 10f;

    // Health states
    public float health = 100f;
    public float maxHealth = 100f;
    public bool isAlive;

    public float rotationSpeed = 5f;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI healthPack;

    List<string> inventory = new List<string>(); 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isAlive = true;
        healthText.text = $"Health: {health:F0}/{maxHealth}";
        healthPack.text = $"Health Pack(s): {inventory.Count(i => i == "HealthPack")}";
    }

    // Update is called once per frame
    void Update()
    {
        // Jump will add raycast later
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && isAlive)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.H) && isAlive)
        {
            UseHealthPack();
        }
    }

    public void AddItem(string item)
    {
        inventory.Add(item);
        healthPack.text = $"Health Pack(s): {inventory.Count(i => i == "HealthPack")}";
    }

    public void UseHealthPack()
    {
        if (inventory.Contains("HealthPack"))
        {
            if(health == maxHealth)
            {
                Debug.Log("Already Full Health!");
            } else
            {
                Heal(20f);
                inventory.Remove("HealthPack");
                healthPack.text = $"Health Pack(s): {inventory.Count(i => i == "HealthPack")}";
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive)
        {
            return;
        }
        health = Mathf.Max(health - damage, 0);
        healthText.text = $"Health: {health:F0}/{maxHealth}";
        if(health <= 0)
        {
            isAlive = false;
            Debug.Log("Player is Dead!");
        }
    }

    public void Heal(float heal)
    {
        if (!isAlive)
        {
            return;
        }
        health = Mathf.Min(health + heal, maxHealth);
        healthText.text = $"Health: {health:F0}/{maxHealth}";
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }

    void FixedUpdate()
    {
        if(!isAlive)
        {
            return;
        }
        Vector3 direction = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            direction.z += 1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            direction.z -= 1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            direction.x += 1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;
        }
        direction = direction.normalized;
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.fixedDeltaTime * rotationSpeed);
        }
        rb.MovePosition(transform.position + direction * walkSpeed * Time.fixedDeltaTime);
    }
}
