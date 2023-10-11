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
    public int indexA;
    public List<string> gearNameA;
    public List<GameObject> gearArmourGO;
    
    [Header("Leg")]
    public int legLevel;
    public int indexL;
    public List<string> gearNameL;
    public List<GameObject> gearLegGO;

    [Header("Variables:")]
    public int helmetCount;
    public int armourCount;
    public int legCount;

    private void Start()
    {
        currWeight = maxWeight;
    }
}
