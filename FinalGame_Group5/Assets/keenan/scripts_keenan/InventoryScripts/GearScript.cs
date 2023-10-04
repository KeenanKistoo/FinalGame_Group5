using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : MonoBehaviour
{
    [Header("Weight Controller:")]
    [SerializeField]
    private PlayerGear _gear;
    
    public enum gearComponent
    {
        helmet, 
        armour,
        leg,
    }
    [Header("Gear Components:")]
    public gearComponent currComponent;
    public List<string> gearNames;
    public List<GameObject> gearGO;

    [Header("Gear Obj:")]
    public GameObject gearObj;

    private void Start()
    {
        _gear = GameObject.FindGameObjectWithTag("inventory").GetComponent<PlayerGear>();
        StateCheck();
        
    }
    public void AddElement(GearWeight gearWeight)
    {
        if (_gear != null)
        {
            if(_gear.currWeight >= gearWeight.weight)
            {
                _gear.currWeight -= gearWeight.weight;
                gearNames[0] = gearWeight.name;
                gearGO[0] = gearWeight.prefab;
            }
        }
    }

    public void StateCheck()
    {
        if (_gear != null)
        {
            if (currComponent == gearComponent.helmet)
            {
                gearNames = _gear.gearNameA;
                gearGO = _gear.gearArmourGO;
            }
            else if (currComponent == gearComponent.armour)
            {
                gearNames = _gear.gearNameA;
                gearGO = _gear.gearArmourGO;
            }
            else if (currComponent == gearComponent.leg)
            {
                gearNames = _gear.gearNameL;
                gearGO = _gear.gearLegGO;
            }
        }
    }
}
