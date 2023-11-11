using UnityEngine;
using UnityEngine.AI;

namespace unathi.Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;
        public GameObject bulletPrefab;
        public Transform spawnPoint;
        public Transform nearestHidingSpot;
    
        public LayerMask whatIsPlayer;
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
        public Unit playerHealth;

        // Use constants for clarity
        private const float ShootingDuration = 6f;

        [SerializeField]
        private LayerMask obstacleLayer;


        private void Start()
        {
            player = GameObject.Find("FirstPersonPlayer").transform;
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
            Hide();
        }

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
        }

        private float shootCooldown = 0f;
        private bool canShoot = true;


        private void Update()
        {
            playerInRetreatRange = Physics.CheckSphere(transform.position, retreatRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            float distanceToTarget = Vector3.Distance(gameObject.transform.position, nearestHidingSpot.position);

            if (distanceToTarget <= stopDistance)
            {
                hidePointSet = true;
            }

            if (!playerInAttackRange && !playerInRetreatRange)
            {
                Hide();
            }

            if (playerInAttackRange && !playerInRetreatRange)
            {
                if (canShoot)
                {
                    Shoot();
                }
            }

            if (playerInRetreatRange)
            {
                Retreat();
            }

            // ... (remaining code)

            if (isShooting)
            {
                anim.SetBool("isShooting", true);
            }
            else
            {
                anim.SetBool("isShooting", false);
                anim.SetBool("isIdle", true);
            }

            // Update shootCooldown
            shootCooldown -= Time.deltaTime;
        }

        private void Shoot()
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Perform a raycast to check for obstacles
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer, out hit, attackRange, obstacleLayer))
            {
                // There is an obstacle between the enemy and the player, don't shoot
                return;
            }

            // If there is no obstacle and the cooldown has elapsed, proceed to shoot
            if (shootCooldown <= 0f)
            {
                // Calculate the direction to the player
                directionToPlayer = (player.position - transform.position).normalized;


                // Add a random offset to the shooting direction
                float spreadAngle = Random.Range(-4f, 4f); // Adjust the spread angle as needed
                Quaternion spreadRotation = Quaternion.Euler(0f, spreadAngle, 0f);
                Vector3 spreadDirection = spreadRotation * directionToPlayer;

                

                RaycastHit hitt;

                if (Physics.Raycast(transform.position + Vector3.up, spreadDirection, out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transform.position, spreadDirection * 20f, Color.red);
                    // Check if the ray hit the player or another target
                    if (hit.collider.CompareTag("Player"))
                    {
                        // Handle the hit on the player (damage, effects, etc.)
                        Debug.Log("Enemy hit player!");
                        playerHealth = GameObject.Find("FirstPersonPlayer").GetComponent<Unit>();
                        playerHealth.currentHP -= 2;

                    }
                }

                // Set the cooldown before the next shot
                shootCooldown = timeBetweenAttacks;

                // Set canShoot to false to prevent shooting during cooldown
                canShoot = false;

                // Invoke ResetCanShoot after the cooldown to allow shooting again
                Invoke(nameof(ResetCanShoot), timeBetweenAttacks);
            }
        }

        private void ResetCanShoot()
        {
            canShoot = true;
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
                if(levelManager.hidingSpots == null)
                {
                    //Debug.Log("Fuck");
                }

                float distance = Vector3.Distance(transform.position, target.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestHidingSpot = target;
                    //Debug.Log(nearestHidingSpot);
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
}