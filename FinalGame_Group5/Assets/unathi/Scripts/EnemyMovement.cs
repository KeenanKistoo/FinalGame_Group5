using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public Transform nearestHidingSpot;
    
    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;
    public bool hidden = false;
    public bool isShooting = false;
    public bool retreating = false;
    LevelManager levelManager;
    NavMeshAgent agent;
    Animator anim;

    //Hiding
    public Vector3 hideSpot;
    bool hidePointSet;
    public float stopDistance = 1f;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    float minAngle;
    float maxAngle;

    //States
    public float attackRange = 30f;
    public float retreatRange = 10f;
    public bool playerInAttackRange;
    public bool playerInRetreatRange;

    // Use constants for clarity
    private const float ShootingDuration = 6f;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        agent = GetComponent<NavMeshAgent>();
        Hide();
    }

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        playerInRetreatRange = Physics.CheckSphere(transform.position, retreatRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        float distanceToTarget = Vector3.Distance(gameObject.transform.position, nearestHidingSpot.position);

        if(distanceToTarget <= stopDistance)
        {
            hidePointSet = true;
        }

        if (!playerInAttackRange && !playerInRetreatRange)
        {
            Hide();
        }

        if (playerInAttackRange && !playerInRetreatRange)
        {
            Shoot();
        }

        if (playerInRetreatRange)
        {
            Retreat();
        }
    }

    private void Shoot()
    {
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
            timeBetweenAttacks = Random.Range(0 f, 0.5f);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Hide()
    {
        if (!hidden && !hidePointSet)
        {
            FindNearestTarget();
            agent.SetDestination(nearestHidingSpot.position);
            nearestHidingSpot.gameObject.GetComponent<NodeScript>().active = false;
        }
    }

    private void FindNearestTarget()
    {
        float nearestDistance = Mathf.Infinity;
        foreach (Transform target in levelManager.hidingSpots)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestHidingSpot = target;
                Debug.Log(nearestHidingSpot);
            }
        }
        hidePointSet = true;
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

        foreach (Transform hidingSpot in levelManager.hidingSpots)
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