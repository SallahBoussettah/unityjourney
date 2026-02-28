using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    
    public Transform target;
    public float speed = 3f;
    public float damage = 10f;
    public EnemySpawner spawner;

    NavMeshAgent agent;

    public float playerDetection = 15f;
    public float patrolDetection = 25f;
    public float attackDetection = 1.5f;
    Vector3 pointA;
    Vector3 pointB;
    Vector3 pointTracker;

    public bool isLit = false;

    public PlayerController player;
    enum EnemyState
    {
        Idle,
        Chase,
        Patrol,
        Attack,
        Retreat
    }

    EnemyState currentState = EnemyState.Idle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        pointA = transform.position + Vector3.right * 5f;
        pointB = transform.position - Vector3.right * 5f;
        pointTracker = pointB;
        player = target.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, target.position);
        if (isLit)
        {
            currentState = EnemyState.Retreat;
        } else if(distance <= attackDetection)
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
                agent.ResetPath();
                break;
            case EnemyState.Chase:
                agent.SetDestination(target.position);
                break;
            case EnemyState.Patrol:
                agent.SetDestination(pointTracker);
                if(!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    pointTracker = pointTracker == pointA ? pointB : pointA;
                }
                break;
            case EnemyState.Attack:
                player.TakeDamage(damage * Time.deltaTime);
                agent.ResetPath();
                break;
            case EnemyState.Retreat:
                Vector3 retreatDirection = transform.position - target.position;
                Vector3 retreatPoint = transform.position + retreatDirection.normalized * 5f;
                agent.SetDestination(retreatPoint);
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
