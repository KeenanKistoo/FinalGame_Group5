using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject pickupUI;
    public bool canPickup;
    public KeyManager keyManager;

    void Start()
    {
        //pickupUI = keyManager.pickupUI;
        keyManager = GameObject.Find("KeyManager").GetComponent<KeyManager>();

        pickupUI.SetActive(false);
    }

    void Update()
    {
        if (canPickup)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                keyManager.keys++;
                pickupUI.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickupUI = keyManager.pickupUI;
            canPickup = true;
            pickupUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canPickup = false;
            pickupUI.SetActive(false);
        }
    }
}
