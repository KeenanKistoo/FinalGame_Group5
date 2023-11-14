using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn2 : MonoBehaviour
{

    public RespawnManager respawnManager;
    // Start is called before the first frame update
    void Start()
    {
        respawnManager = GameObject.Find("RespawnManager").GetComponent<RespawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (respawnManager == null)
        {
            respawnManager = GameObject.Find("RespawnManager").GetComponent<RespawnManager>();

        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            respawnManager.respawnText.SetActive(true);
            respawnManager.currentCheckPoint = 2;
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            respawnManager.respawnText.SetActive(false);
        }
    }
}

