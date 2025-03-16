using UnityEngine;
using UnityEngine.AI;

public class KeosRunAway : MonoBehaviour
{
    [Header("This script was made by Keo.cs")]
    [Header("You do not have to give credits")]
    public GameObject target;
    public float safeDistance = 10f;
    public string movementParameterName = "isMoving";
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        Vector3 direction = transform.position - target.transform.position;
        Vector3 runTo = transform.position + direction.normalized * safeDistance;

        if (NavMesh.SamplePosition(runTo, out NavMeshHit hit, safeDistance, NavMesh.AllAreas))
        {
            runTo = hit.position;
        }

        agent.speed = Mathf.Lerp(1f, 10f, 1 - (distance / safeDistance));
        agent.SetDestination(runTo);

        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            animator.SetBool(movementParameterName, true);
        }
        else
        {
            animator.SetBool(movementParameterName, false);
        }
    }
}
