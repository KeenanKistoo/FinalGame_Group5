using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int damage;

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
                if (levelManager.enemyCount < 10 && levelManager.state == State.Battle)
                {
                    levelManager.SpawnEnemy();
                    levelManager.enemyCount++;
                }
                
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
