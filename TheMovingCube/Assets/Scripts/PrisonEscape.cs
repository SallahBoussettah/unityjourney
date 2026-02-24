using UnityEngine;

public class PrisonEscape : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float sprintSpeed = 25f;
    public float stamina = 100f;
    public float staminaDrain = 10f;
    public bool isExhausted;
    public bool isMoving;

    public float currentSpeed;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if LeftShift Is pressed
        currentSpeed = moveSpeed;
        // Movement Check
        isMoving = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.LeftShift ) && !isExhausted && isMoving)
        {
            currentSpeed = sprintSpeed;
            stamina = stamina - (staminaDrain * Time.deltaTime);
            if (stamina <= 0)
            {
                isExhausted = true;
            }
        } else
        {
            if (stamina < 100)
            {
                if (!isMoving)
                {
                    stamina = stamina + (2 * (staminaDrain * Time.deltaTime));
                }
                stamina = stamina + (staminaDrain * Time.deltaTime); // we will gain this time for testing no need to add new variable.
            }
            if (stamina >= 50)
            {
                isExhausted = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;
        
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
        rb.MovePosition(transform.position + direction * currentSpeed * Time.fixedDeltaTime);

    }
}
