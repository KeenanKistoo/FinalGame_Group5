using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unathi.Scripts;

public class GasManager : MonoBehaviour
{
    public Unit _unit;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("FirstPersonPlayer");
        if (playerObject != null)
        {
            _unit = playerObject.GetComponent<Unit>();

            if (_unit == null)
            {
                Debug.LogError("Unit script not found on FirstPersonPlayer.");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
