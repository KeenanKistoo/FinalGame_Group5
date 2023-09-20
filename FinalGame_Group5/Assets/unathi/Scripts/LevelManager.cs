using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Transform> hidingSpots;

    // Start is called before the first frame update
    void Awake()
    {
        hidingSpots = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
