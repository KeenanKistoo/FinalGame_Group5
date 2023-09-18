using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f; // Bullet speed
    public float lifespan = 2f; // Bullet lifespan in seconds
    Unit enemyUnit;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the bullet's lifespan has expired
        if (Time.time - startTime >= lifespan)
        {
            // Destroy the bullet when its lifespan is over
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collided with an object that has a "Health" component
        Unit unit = other.GetComponent<Unit>();

        if (unit != null)
        {
            // Inflict damage on the object if it has health
            unit.TakeDamage(5);
        }

        // Destroy the bullet on collision with any object
        Destroy(gameObject);
    }
}
