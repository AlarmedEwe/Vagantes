using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private GameObject[] players;
    private Transform target;
    private NavMeshAgent agent;
    private readonly float lookDistance = 10f;
    private bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        isLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked)
            FindClosestPlayer();

        if (Vector3.Distance(transform.position, target.position) < lookDistance)
            isLocked = true;

        if (isLocked)
            agent.SetDestination(target.position);

        if (agent.remainingDistance != 0 && agent.remainingDistance <= agent.stoppingDistance)
        {
            HasCollided();
        }
    }

    private void HasCollided()
    {
        var health = target.GetComponent<PlayerHealth>();

        if (health is not null)
        {
            health.TakeDamage(10);
        }
    }

    private void FindClosestPlayer()
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;

        foreach (var player in players)
        {
            Vector3 diff = player.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }

        target = closest.transform;
    }
}
