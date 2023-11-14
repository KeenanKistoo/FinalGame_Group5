using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unathi.Scripts
{
    public class Battle : MonoBehaviour
    {
        public int level;
        [SerializeField] private int hostageCount;
        public int checkPoint;

        int spawnIndex = 0;

        [SerializeField] private GameObject[] hostages;

        public Transform[] spawnPoints;

        public GameObject enemyPrefab;

        public LevelManager levelManager;

        // Start is called before the first frame update
        void Start()
        {
            DeactivateHostages();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Level1()
        {
            level = 1;
            ActivateHostages();
            StartCoroutine(SpawnEnemies());
        }

        void ActivateHostages()
        {
            foreach (GameObject hostage in hostages)
            {
                hostage.SetActive(true);
            }
        }

        void DeactivateHostages()
        {
            foreach (GameObject hostage in hostages)
            {
                hostage.SetActive(false);
            }
        }

        IEnumerator SpawnEnemies()
        {
            Debug.Log("Fuck");

            while (spawnIndex < 4)
            {
                // Instantiate the enemy at the current spawn point
                Instantiate(enemyPrefab, spawnPoints[level].position, spawnPoints[level].rotation);

                // Wait for the specified spawnDelay
                yield return new WaitForSeconds(5);

                // Move to the next spawn point
                spawnIndex++;

                Debug.Log("Fuck Man");
            }
        }
    }
}
