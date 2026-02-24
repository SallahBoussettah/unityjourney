using UnityEngine;

public class PrisonEscape : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float sprintSpeed = 25f;
    public float stamina = 100f;
    public float staminaDrain = 10f;
    public bool isExhausted;
    public bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if LeftShift Is pressed
        float currentSpeed = moveSpeed;
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
        Movement(currentSpeed);
    }

    void Movement(float speed)
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        } if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-(speed * Time.deltaTime), 0, 0);
        } if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -(speed * Time.deltaTime));
        } if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
