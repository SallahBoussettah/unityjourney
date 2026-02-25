using System.Threading.Tasks;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float walkSpeed = 10f;
    public float jumpForce = 10f;
    bool isGrounded;
    Vector3 startLocation;
    int score;

    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public float damagePerSecond = 30f;
    
    MovingPlatform currentPlatform;

    public TextMeshProUGUI ui;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }   
             
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KillZone"))
        {
            Debug.Log("Player is Dead!");
            rb.linearVelocity = Vector3.zero;
            transform.position = startLocation;
        }
        // if (other.CompareTag("Hazard"))
        // {
        //     Debug.Log("Player taking damage");
        //     TakeDamage(25);
        // }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            currentHealth = currentHealth - (damagePerSecond * Time.deltaTime);
            if (currentHealth <= 0)
            {
                rb.linearVelocity = Vector3.zero;
                transform.position = startLocation;
                currentHealth = maxHealth;
            }
        }
    }

    public void AddScore(int amount)
    {
        score = score + amount;
        ui.text = "Score : " + score;
    }

    void TakeDamage(int amount)
    {
        currentHealth = currentHealth - amount;
        if (currentHealth <= 0)
        {
            rb.linearVelocity = Vector3.zero;
            transform.position = startLocation;
            currentHealth = maxHealth;
        }
    }

    void FixedUpdate()
    {
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
        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;
        }
        direction = direction.normalized;
        Vector3 platformMovement = Vector3.zero;
        if(currentPlatform != null)
        {
            platformMovement = currentPlatform.movement;
        }
        rb.MovePosition(transform.position + direction * walkSpeed * Time.fixedDeltaTime + platformMovement);
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("MovingPlatform"))
        {
            currentPlatform = other.gameObject.GetComponent<MovingPlatform>();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("MovingPlatform"))
        {
            currentPlatform = null;
        }
    }
}