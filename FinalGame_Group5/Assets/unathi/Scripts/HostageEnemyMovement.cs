using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class HostageEnemyMovement : MonoBehaviour
{
    public float attackRange = 3.0f;   // Maximum distance for attacking the player
    public float chaseRange = 10.0f;   // Maximum distance for chasing the player

    private Transform player;           // Reference to the player's transform
    private UnityEngine.AI.NavMeshAgent navMeshAgent;  // Reference to the NavMeshAgent component

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("FirstPersonPlayer").transform;  // Assumes player has the "Player" tag
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the attack range
        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
        // Check if the player is within the chase range
        else if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasing();
        }
    }

    private void AttackPlayer()
    {
        // Implement the attack logic here (e.g., reduce player's health)
        // You can also add attack animations, particle effects, or other actions
    }

    private void ChasePlayer()
    {
        // Set the NavMeshAgent's destination to the player's position for chasing
        navMeshAgent.SetDestination(player.position);
    }

    private void StopChasing()
    {
        // Stop the NavMeshAgent to remain in the current position
        navMeshAgent.ResetPath();
    }
}
