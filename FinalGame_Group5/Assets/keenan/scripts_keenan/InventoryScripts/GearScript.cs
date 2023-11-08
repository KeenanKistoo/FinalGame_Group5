using System.Collections.Generic;
using UnityEngine;

namespace keenan.scripts_keenan.InventoryScripts
{
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
        public int index;

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
                    gearNames[index] = gearWeight.gearName;
                    //gearGO[index] = gearWeight.prefab;
                    index++;
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
                    index = _gear.indexA;
                }
                else if (currComponent == gearComponent.leg)
                {
                    gearNames = _gear.gearNameL;
                    gearGO = _gear.gearLegGO;
                    index = _gear.indexL;
                }
            }
        }
    }
}
