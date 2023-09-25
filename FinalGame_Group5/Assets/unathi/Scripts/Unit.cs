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
        if (gameObject.CompareTag("Player"))
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
                StartCoroutine(TargetDestroy());
            }
        }
    }

    void Die()
    {
        // What happens when the player dies
    }

    IEnumerator TargetDestroy()
    {
        GameObject particle = Instantiate(targetParticle, gameObject.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1);

        Destroy(particle);
    }
}
