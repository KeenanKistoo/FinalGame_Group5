using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    LevelManager levelManager;
    public bool active;
    private bool addedToHidingSpots = false; // Flag to track if added to the list

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.hidingSpots.Add(gameObject.transform);
        addedToHidingSpots = true;
    }

    private void Awake()
    {
        active = true;
    }

    void Update()
    {
        if (active && !addedToHidingSpots)
        {
            levelManager.hidingSpots.Add(gameObject.transform);
            addedToHidingSpots = true; // Set the flag to true once added
        }
        else if (!active && addedToHidingSpots)
        {
            levelManager.hidingSpots.Remove(gameObject.transform);
            addedToHidingSpots = false; // Set the flag to false once removed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            active = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            active = true;
        }
    }

}
