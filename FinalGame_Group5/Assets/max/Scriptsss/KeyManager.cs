using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public int keys = 0;
    public GameObject pickupUI;

    void Start()
    {
        //pickupUI = GameObject.Find("PickupUI");
        pickupUI.SetActive(false);
    }

    
}
