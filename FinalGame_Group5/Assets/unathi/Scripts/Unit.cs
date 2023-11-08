using UnityEngine;
using UnityEngine.UI;

namespace unathi.Scripts
{
    public class Unit : MonoBehaviour
    {
        public int maxHP;
        public int currentHP;
        public int damage;

        public GameObject key;

        public int bulletsFired = 0;

        LevelManager levelManager;

        public GameObject targetParticle;

        public Slider playerSlider;

        // Start is called before the first frame update
        void Start()
        {
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            if (gameObject.name == "FirstPersonPlayer")
            {
                playerSlider.maxValue = maxHP;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (gameObject.name == "FirstPersonPlayer")
            {
                playerSlider.value = currentHP;
            }
        }
        public void TakeDamage(int dmg)
        {
            //Debug.Log(gameObject.name);

            if (gameObject.CompareTag("Player") || gameObject.CompareTag("Enemy") || bulletsFired >= 4)
            {
                currentHP -= dmg;
                //Debug.Log("Ouch!");
                bulletsFired = 0;
            }

            if (gameObject.CompareTag("Target"))
            {
                currentHP -= dmg;
                levelManager.numberOfTargets--;
            }

            if (currentHP <= 0)
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    if (levelManager.enemyCount < 10 && levelManager.state == State.Training2)
                    {
                        levelManager.SpawnEnemy();
                        levelManager.enemyCount++;
                    }
                    EnemyMovement enemy = GetComponent<EnemyMovement>();
                    enemy.nearestHidingSpot.gameObject.GetComponent<NodeScript>().active = true;
                    Destroy(gameObject);
                }

                //Hostage situation enemy type
                if (gameObject.CompareTag("Enemy_h"))
                {
                    if (levelManager.enemyCount_h < 10 && levelManager.state == State.Hostage)
                    {
                        levelManager.SpawnEnemy_H();
                        levelManager.enemyCount_h++;
                    }

                    //If player has obtained key to hostages
                    if (levelManager.enemyCount_h == 10)
                        Instantiate(key, gameObject.transform.position, Quaternion.identity);

                    Destroy(gameObject);
                }


                if (gameObject.CompareTag("Player"))
                {
                    //StartCoroutine(Die());
                }

                if (gameObject.CompareTag("Target"))
                {
                    TargetDestroy();
                }
            }


            if (bulletsFired < 4)
                bulletsFired++;
        }

        void Die()
        {
            // What happens when the player dies
        }

        void TargetDestroy()
        {
            GameObject particle = Instantiate(targetParticle, gameObject.transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
