using UnityEngine;
using UnityEngine.AI;

public class RandomRoamingAI : MonoBehaviour
{
    [Header("made by goofybrain with the help of his friniesdss")]

    private NavMeshAgent agent;
    [Header("how long it keeps roaming till it like roams somehwere else")]
    public float roamingDelay = 2f;
    [Header("the ditsance it roams")]
    public float roamingDsitance = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("SetRandomDestination", 0f, roamingDelay);
    }

    void SetRandomDestination()
    {
        agent.SetDestination(RandomNavmeshLocation());
    }

    Vector3 RandomNavmeshLocation()
    {
        NavMeshHit hit;
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * roamingDsitance;
        return NavMesh.SamplePosition(randomPoint, out hit, roamingDsitance, NavMesh.AllAreas) ? hit.position : transform.position;
    }
}
