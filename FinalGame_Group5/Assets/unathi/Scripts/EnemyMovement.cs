using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] hidingSpots;
    public Transform player;
    public Transform spawnPoint;
    public NavMeshAgent agent;
    public LayerMask whatIsPlayer;

    public float retreatRange;
    public float attackRange;
    public float stopDistance = 1f;
    public float hideTime = 3f; // Adjust the time the enemy hides

    [SerializeField] private float shootingTimer = 0f;
    [SerializeField] private bool isShooting = false;
    [SerializeField] private bool retreating = false;
    [SerializeField] private bool hidden = false;
    [SerializeField] private Transform nearestHidingSpot;

    public GameObject bulletPrefab;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        Hide();
        isShooting = false;
    }

    private void Update()
    {
        bool playerInRetreatRange = Physics.CheckSphere(transform.position, retreatRange, whatIsPlayer);
        bool playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        Debug.Log(playerInAttackRange);

        if (playerInAttackRange)
        {
            if (hidden && shootingTimer==0)
            {
                shootingTimer = 0;
                isShooting = true;
            }
        }

            if (isShooting)
            {
                shootingTimer += Time.deltaTime;

                if (shootingTimer <= 6f)
                {
                Shoot();
                }
                else if (shootingTimer > 6f && shootingTimer <= 6f + hideTime)
                {
                    Hide();
            }
                else
                {
                    shootingTimer = 0f;
                    isShooting = false;
                }
            }
       

        float distanceToSpot = Vector3.Distance(transform.position, nearestHidingSpot.position);

        // Checks if enemy should hide or not
        if (distanceToSpot <= stopDistance && !isShooting || shootingTimer > 6f && shootingTimer <= 6f + hideTime)
        {
            hidden = true;
        } else
        {
            hidden = false;
        }

        //Checks if enemy is hidden
       if (hidden)
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1f, 1);
        }
    }

    private void Shoot()
    {
        // Check if the player is in attack range (just to be safe)
        if (Physics.CheckSphere(transform.position, attackRange, whatIsPlayer))
        {
            // Rotate to face the player
            transform.LookAt(player.position);

            // Instantiate a bullet prefab and set its position and rotation
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

            // Access the Bullet script attached to the bullet GameObject
            EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();

            // Destroy the bullet after a certain time (in case it doesn't hit anything)
            Destroy(bullet, bulletScript.lifespan);
        }
    }

    private void Hide()
    {
        if (!hidden)
        {
            FindNearestTarget();
            agent.SetDestination(nearestHidingSpot.position);
        }
    }

    private void FindNearestTarget()
    {
        float nearestDistance = Mathf.Infinity;

        foreach (Transform target in hidingSpots)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestHidingSpot = target;
            }
        }
    }

    void Retreat()
    {
        if (!retreating)
        {
            Transform furthestSpot = GetFurthestHidingSpot();
            agent.SetDestination(furthestSpot.position);
            retreating = true;
        }
       
    }

    private Transform GetFurthestHidingSpot()
    {
        Transform furthestSpot = null;
        float furthestDistance = 0f;

        foreach (Transform hidingSpot in hidingSpots)
        {
            float distance = Vector3.Distance(transform.position, hidingSpot.position);

            if (distance > furthestDistance)
            {
                furthestDistance = distance;
                furthestSpot = hidingSpot;
            }
        }

        return furthestSpot;
    }
}