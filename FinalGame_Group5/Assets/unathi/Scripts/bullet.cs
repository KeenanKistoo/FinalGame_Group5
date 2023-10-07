using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Target"))
        {
            Unit unit = other.GetComponent<Unit>();
            unit.TakeDamage(5);
            Destroy(gameObject);
        }

        if (other.CompareTag("Training"))
        {
            level.StartTraining();
        }
    }
}
