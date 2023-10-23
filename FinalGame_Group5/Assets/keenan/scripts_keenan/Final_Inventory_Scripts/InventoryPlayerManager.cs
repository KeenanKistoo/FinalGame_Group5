using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryPlayerManager : MonoBehaviour
{
    public float maxWeight;
    public float currWeight;
    public GameObject[] activeGear;
    public bool gearCheck;
    public GameObject parent;

    public void GearCheck()
    {
        if (parent.transform.childCount > 0)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                Transform childTransform = parent.transform.GetChild(i);
                GameObject childObject = childTransform.gameObject;
                activeGear[i] = childObject;
            }
        }
    }
}
