using System;
using System.Collections.Generic;
using keenan.scripts_keenan.InventoryScripts;
using UnityEngine;

namespace keenan.scripts_keenan.Inventory_Final_Scripts
{
    public class MainInventoryManager : MonoBehaviour
    {
        [Header("Active Gear:")] 
        public List<GameObject> activeGear;
        public int activeGearCount;

        [Header("Inactive Gear:")] 
        public List<GameObject> inactiveGear;
        public int inactiveGearCount;

        [Header("Active Btns:")] 
        public GameObject[] equipBtns;
        public GameObject[] removeBtns;

        private void Start()
        {
            SetUp();
        }

        public void SetUp()
        {
            activeGear.Clear();
            inactiveGear.Clear();
        }

       public void GearCount()
       {
           inactiveGearCount = inactiveGear.Count;
           for (int i = 0; i < equipBtns.Length; i++)
           {
               if (i < inactiveGearCount)
               {
                   equipBtns[i].SetActive(true);
                   InvBtnsManager _btnManager = equipBtns[i].GetComponent<InvBtnsManager>();
                   GearWeight _gearWeight = inactiveGear[i].GetComponent<GearWeight>();
                   _btnManager.weight = _gearWeight.weight;
                   _btnManager.weightTxt.text = _gearWeight.weight + "KG";
                   _btnManager.nameTxt.text = _gearWeight.gearName;

               }else if (i >= inactiveGearCount)
               {
                   equipBtns[i].SetActive(false);
               }
           }
       }
       public void GearActiveCount()
       {
           activeGearCount = activeGear.Count;
           for (int i = 0; i < removeBtns.Length; i++)
           {
               if (i < activeGearCount)
               {
                  removeBtns[i].SetActive(true);
                  InvBtnsManager _btnManager = removeBtns[i].GetComponent<InvBtnsManager>();
                  GearWeight _gearWeight = activeGear[i].GetComponent<GearWeight>();
                  _btnManager.weightTxt.text = _gearWeight.weight + "KG";
                  _btnManager.nameTxt.text = _gearWeight.gearName;
               }else if (i >= activeGearCount)
               {
                   removeBtns[i].SetActive(false);
               }
           }
       }
    }
}
