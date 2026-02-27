using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    
    public Transform target;
    public float speed = 3f;
    public float damage = 10f;
    public EnemySpawner spawner;

    public float playerDetection = 15f;
    public float patrolDetection = 25f;
    public float attackDetection = 1.5f;
    Vector3 pointA;
    Vector3 pointB;
    Vector3 pointTracker;

    public PlayerController player;
    enum EnemyState
    {
        Idle,
        Chase,
        Patrol,
        Attack
    }

    EnemyState currentState = EnemyState.Idle;

    void Start()
    {
        pointA = transform.position + Vector3.right * 5f;
        pointB = transform.position - Vector3.right * 5f;
        pointTracker = pointB;
        player = target.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= attackDetection)
        {
          currentState = EnemyState.Attack;
        } else if (distance <= playerDetection)
        {
            currentState = EnemyState.Chase;   
        } else if(distance <= patrolDetection)
        {
            currentState = EnemyState.Patrol;    
        } else
        {
            currentState = EnemyState.Idle;
        }

        switch (currentState)
        {
            case EnemyState.Idle:
                // Idle logic still gonna come here.
                break;
            case EnemyState.Chase:
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                break;
            case EnemyState.Patrol:
                transform.position = Vector3.MoveTowards(transform.position, pointTracker, speed * Time.deltaTime);
                if(Vector3.Distance(transform.position, pointTracker) < 0.1f)
                {
                    pointTracker = pointTracker == pointA ? pointB : pointA;
                }
                break;
            case EnemyState.Attack:
                player.TakeDamage(damage * Time.deltaTime);
                break;
        }
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         PlayerController player = collision.gameObject.GetComponent<PlayerController>();
    //         player.TakeDamage(damage);
    //         spawner.destroyEnemy(gameObject);
    //         Destroy(gameObject);
    //     }
    // }
}
