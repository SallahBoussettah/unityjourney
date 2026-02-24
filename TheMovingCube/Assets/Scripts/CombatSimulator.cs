using UnityEngine;

public class CombatSimulator : MonoBehaviour
{
    public float moveSpeed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        } if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -(moveSpeed * Time.deltaTime));
        } if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-(moveSpeed * Time.deltaTime), 0, 0);
        } if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
    }

}
