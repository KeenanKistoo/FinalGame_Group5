using UnityEngine;
using UnityEngine.AI;

namespace unathi.Scripts
{
    public class HostageEnemyMovement : MonoBehaviour
    {
        Transform player;
        public GameObject bulletPrefab;
        public Transform spawnPoint;

        public LayerMask whatIsPlayer;
        public bool isShooting = false;
        LevelManager levelManager;
        NavMeshAgent agent;
        Animator anim;

        //Attacking
        public float timeBetweenAttacks;
        bool alreadyAttacked;

        float minAngle;
        float maxAngle;

        //States
        public float attackRange = 30f;
        public float chaseRange = 50;
        public bool playerInAttackRange;
        public bool playerInChaseRange;

        // Use constants for clarity
        private const float ShootingDuration = 6f;


        private void Start()
        {
            player = GameObject.Find("FirstPersonPlayer").transform;
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
        }

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            playerInChaseRange = Physics.CheckSphere(transform.position, chaseRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (playerInAttackRange)
            {
                Shoot();
                StopChasing();
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }

            if (playerInChaseRange)
            {
                Chase();
            } else 
            {
                StopChasing();
            }

            if (playerInChaseRange && !playerInAttackRange)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
            }
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", true);
            }

            if (isShooting)
            {
                anim.SetBool("isShooting", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", false);
            }
            else
            {
                anim.SetBool("isShooting", false);
                anim.SetBool("isIdle", true);
            }
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

        private void Chase()
        {
            // Set the NavMeshAgent's destination to the player's position for chasing
            agent.SetDestination(player.position);
        }

        private void StopChasing()
        {
            // Stop the NavMeshAgent to remain in the current position
            agent.ResetPath();

            // Set the NavMeshAgent's velocity to zero
            agent.velocity = Vector3.zero;
        }
    }
}
