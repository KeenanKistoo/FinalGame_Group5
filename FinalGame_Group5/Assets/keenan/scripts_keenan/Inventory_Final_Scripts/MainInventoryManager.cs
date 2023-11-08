using System;
using System.Collections.Generic;
using UnityEngine;

namespace keenan.scripts_keenan.Inventory_Final_Scripts
{
    public class MainInventoryManager : MonoBehaviour
    {
        [Header("Active Gear:")] 
        public List<GameObject> activeGear;

        [Header("Inactive Gear:")] 
        public List<GameObject> inactiveGear;

       public void SetUp()
        {
            activeGear.Clear();
            inactiveGear.Clear();
        }
    }
}
