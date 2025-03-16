using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class KeosHorrorAI : MonoBehaviourPunCallbacks
{
    [Header("This script was made by Keo.cs")]
    [Header("You do not have to give credits")]
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float wanderSpeed = 2f;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Color chaseRangeColor = Color.red;
    [Header("Do not edit this")]
    public Transform targetPlayer;
    public NavMeshAgent agent;
    public PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = wanderSpeed;
        StartCoroutine(UpdateTarget());
        Wander();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (targetPlayer != null)
            {
                float distance = Vector3.Distance(transform.position, targetPlayer.position);
                if (distance <= chaseRange)
                {
                    ChasePlayer();
                }
                else
                {
                    targetPlayer = null;
                    Wander();
                }
            }
            else
            {
                Wander();
            }
        }
    }

    IEnumerator UpdateTarget()
    {
        while (true)
        {
            float closestDistance = Mathf.Infinity;
            GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < closestDistance && distance <= chaseRange)
                {
                    closestDistance = distance;
                    targetPlayer = player.transform;
                }
            }
            if (closestDistance == Mathf.Infinity)
            {
                targetPlayer = null;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void ChasePlayer()
    {
        agent.speed = moveSpeed;
        if (NavMesh.SamplePosition(targetPlayer.position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
        {
            agent.SetDestination(targetPlayer.position);
        }
        else
        {
            targetPlayer = null;
        }
    }

    void Wander()
    {
        if (!agent.hasPath || agent.remainingDistance < 1f)
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10f;
            randomDirection += transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
            {
                Vector3 finalPosition = hit.position;
                agent.speed = wanderSpeed;
                agent.SetDestination(finalPosition);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = chaseRangeColor;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
