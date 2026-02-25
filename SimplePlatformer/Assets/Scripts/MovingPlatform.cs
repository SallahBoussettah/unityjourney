using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    Vector3 startingLocation;
    public Vector3 offset;
    public float platformerSpeed = 2f;
    Vector3 previousPosition;
    public Vector3 movement;

    void Start()
    {
        startingLocation = transform.position;
        previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        float pingPongValue = Mathf.PingPong(Time.time * platformerSpeed, offset.magnitude);
        transform.position = startingLocation + offset.normalized * pingPongValue;

        movement = transform.position - previousPosition;
        previousPosition = transform.position;
    }
}
