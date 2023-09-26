using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int damage;

    LevelManager levelManager;

    public GameObject targetParticle;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int dmg)
    {
        Debug.Log(gameObject.name);

        if (gameObject.CompareTag("Player") || gameObject.CompareTag("Enemy") || gameObject.CompareTag("Target"))
        {
            currentHP -= dmg;
        }

        if (currentHP <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                levelManager.SpawnEnemy();
                Destroy(gameObject);
                EnemyMovement enemy = GetComponent<EnemyMovement>();
                enemy.nearestHidingSpot.gameObject.GetComponent<NodeScript>().active = true;
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
