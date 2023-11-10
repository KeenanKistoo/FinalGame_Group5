using System;
using keenan.scripts_keenan.InventoryScripts;
using Unity.VisualScripting;
using UnityEngine;

namespace keenan.scripts_keenan.Inventory_Final_Scripts
{
    public class MainInventoryController : MonoBehaviour
    { 
        /*-----------------------------------------------Variables----------------------------------------------------*/
        [Header("Storage Parent Component:")]
        [SerializeField]
        private GameObject _storageParent;

        [Header("Active Parent Component:")] 
        [SerializeField]
        private GameObject _activeParent;

        [Header("Gear Information:")] 
        [SerializeField]
        private GearWeight _gearWeight;

        [Header(("Inventory Manager:"))] 
        [SerializeField]
        private MainInventoryManager _inventoryManager;
        public enum GearState
        {
            active,
            inactive
        }

        public GearState currInvState;
/*------------------------------------------------Functions Begin-----------------------------------------------------*/

         private void Start()
        {
        currInvState = GearState.inactive;
        SetUp();
        GearStateCheck();
        }

        private void SetUp()
        {
        _gearWeight = this.gameObject.GetComponent<GearWeight>();
        _inventoryManager = GameObject.FindWithTag("inventory").
        GetComponent<MainInventoryManager>();
        //_inventoryManager.SetUp();
    
        }

        public void GearStateCheck()
        {
            GameObject obj = this.gameObject;
            switch (currInvState)
            {
            case GearState.active:
                obj.transform.SetParent(_activeParent.transform, false);
                _inventoryManager.inactiveGear.Remove(obj);
                _inventoryManager.activeGear.Add(obj);
                break;
            case GearState.inactive:
                obj.transform.SetParent(_storageParent.transform, false);
                _inventoryManager.inactiveGear.Add(obj);
                _inventoryManager.activeGear.Remove(obj);
                break;
            }
        
            _inventoryManager.GearCount();
            _inventoryManager.GearActiveCount();
        }
        
    }
    
}
