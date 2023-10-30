using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class HostageEnemyMovement : MonoBehaviour
{
    public float attackRange = 3.0f;   // Maximum distance for attacking the player
    public float chaseRange = 10.0f;   // Maximum distance for chasing the player

    private Transform player;           // Reference to the player's transform
    private UnityEngine.AI.NavMeshAgent navMeshAgent;  // Reference to the NavMeshAgent component

    public GameObject bulletPrefab;

    bool alreadyAttacked;
    public float timeBetweenAttacks;

    public Transform spawnPoint;

    private void Start()
    {
        player = GameObject.Find("FirstPersonPlayer").transform;
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
        else if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange)
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
        Shoot();
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

    private void Shoot()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // If there is no obstacle, proceed to shoot
        transform.LookAt(player.position);

        if (!alreadyAttacked)
        {
            // Create a spread angle (in degrees)
            float spreadAngle = Random.Range(-1.5f, 1.5f);

            // Apply the spread to the bullet's rotation
            Quaternion spreadRotation = Quaternion.Euler(0f, spreadAngle, 0f);

            // Calculate the rotated direction
            Vector3 bulletDirection = spreadRotation * transform.forward;

            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.LookRotation(bulletDirection));
            EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
            Destroy(bullet, bulletScript.lifespan);

            alreadyAttacked = true;
            timeBetweenAttacks = Random.Range(0f, 0.5f);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
