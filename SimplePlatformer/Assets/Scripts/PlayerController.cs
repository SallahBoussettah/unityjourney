using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    public float jumpForce = 10f;
    public float walkSpeed = 5f;

    // Health and other player stats can be added here as needed
    public float currentHealth = 100f;
    public float maxHealth = 100f;

    // We can store the player's starting position to respawn them there when they die
    Vector3 startingPosition;

    // Ui elements for health can be added here, such as a health bar or text display
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    // Audio Source for player sounds (Jumping, Damage, Collectible for score later)
    AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip collectibleSound;

    // Score variable to keep track of the player's score, can be displayed on UI later
    public int score;

    // Damage Variable
    public float damage = 10f;

    MovingPlatform currentPlatform; // Reference to the moving platform the player is currently on, if any

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        healthCheck();

        // Storing the player's starting position for respawn purposes
        startingPosition = transform.position;
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthCheck();
    }

    void healthCheck()
    {
        if (healthText != null)
        {
            healthText.text = $"Health : {currentHealth}/{maxHealth}";
        }

        // Check if the player's health has dropped to zero or bellow, if so respawn.
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // We handle position store in Start() and respawn to reset the player's position to the starting point when they die.
        rb.linearVelocity = Vector3.zero; // Reset velocity to prevent carryover of momentum on respawn
        transform.position = startingPosition;

        // Reset health to max when respawning
        currentHealth = maxHealth;
        healthCheck();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            // If the player enters a kill zone, we can immediately respawn them without needing to wait for health to drop to zero
            Respawn();
        }
        if (other.CompareTag("Goal"))
        {
            // Load Win Screen
            SceneManager.LoadScene("WinScreen");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            // If the player is in contact with a hazard, we can apply damage over time here
            TakeDamage(damage * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                PlaySoundEffect(damageSound);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            currentPlatform = collision.gameObject.GetComponent<MovingPlatform>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            currentPlatform = null;
        }
    }

    // Adding Score
    public void AddScore(int amount)
    {
        score += amount;
        // Here we can also update the score display on the UI if we have one set up
        if (scoreText != null)        {
            scoreText.text = $"Score: {score}";
        }
    }

    // Function for sound effect to reduce repetitive code
    public void PlaySoundEffect(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Input handling is done in FixedUpdate for better physics performance
        // Adding Jump functionality on Space key press but we need to check if the player is grounded before allowing them to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // Play jump sound effect if assigned
            PlaySoundEffect(jumpSound);
        }

    }
    
    bool isGrounded()
    {
        // Check if the player is grounded by casting a ray downwards from the player's position.
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
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
        if (currentPlatform != null)
        {
            platformMovement = currentPlatform.movement;
        }
        rb.MovePosition(transform.position + direction * walkSpeed * Time.fixedDeltaTime + platformMovement);
    }
}
