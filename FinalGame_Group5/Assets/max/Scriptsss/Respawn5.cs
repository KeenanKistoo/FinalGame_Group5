using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn5 : MonoBehaviour
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
            respawnManager.cc.enabled = false;
            respawnManager.playerTransform.transform.position = respawnManager.checkPoint5.transform.position;
            respawnManager.cc.enabled = true;
            respawnManager.currentCheckPoint = 5;
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
