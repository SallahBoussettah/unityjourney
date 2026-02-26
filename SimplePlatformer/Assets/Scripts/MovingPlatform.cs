using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Using parent prevents WASD from working when on the platform.

    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector3 target;

    Vector3 previousPosition;
    public Vector3 movement;

    void Start()
    {
        target = pointB.position;
        previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        movement = transform.position - previousPosition;
        previousPosition = transform.position;

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }

}
