using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGear : MonoBehaviour
{
    [Header("Weight")]
    public int currWeight;
    public int maxWeight;

    [Header("Helmet:")]
    public int helmetLevel;
    public string gearNameH;
    public GameObject gearHelmetGO;

    [Header("Armour")]
    public int armourLevel;
    public List<string> gearNameA;
    public List<GameObject> gearArmourGO;
    
    [Header("Leg")]
    public int legLevel;
    public List<string> gearNameL;
    public List<GameObject> gearLegGO;

    private void Start()
    {
        currWeight = maxWeight;
    }
}
