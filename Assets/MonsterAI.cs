using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [Header("Кого переслідувати")]
    public Transform playerTarget; 

    [Header("Налаштування монстра")]
    public float chaseSpeed = 5f;
    public float visionRange = 25f; 

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

      
        if (agent != null)
        {
            agent.speed = chaseSpeed;
        }

      
        if (playerTarget == null)
        {
            GameObject p = GameObject.Find("Player");
            if (p != null) playerTarget = p.transform;
        }
    }

    void Update()
    {
        if (playerTarget == null || agent == null) return;

       
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

      
        if (distanceToPlayer <= visionRange)
        {
            agent.SetDestination(playerTarget.position);
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
