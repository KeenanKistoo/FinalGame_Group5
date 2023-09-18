using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {

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
            if (!gameObject.CompareTag("Player"))
                Destroy(gameObject);

            if (gameObject.CompareTag("Player"))
            {
                //StartCoroutine(Die());
            }
        }
    }
}
