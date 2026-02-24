using UnityEngine;

public class CombatSimulator : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 50f;
    public int speedMultiplier = 2;
    void Start()
    {
        
    }

    void Update()
    {
        float currentSpeed = moveSpeed; 
        float currentRotation = rotateSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = moveSpeed * speedMultiplier;
            currentRotation = rotateSpeed * speedMultiplier;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("LeftShift Pressed");
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        } if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -(currentSpeed * Time.deltaTime));
        } if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-(currentSpeed * Time.deltaTime), 0, 0);
        } if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
        }

        // Improvising and adding rotate on E and Q, with Left Shift Boost
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, currentRotation * Time.deltaTime, 0);
        } else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -(currentRotation * Time.deltaTime), 0);
        }
    }

}
