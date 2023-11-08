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

        [Header("Parent Elements")]
        [SerializeField]
        private GameObject _storage;
        [SerializeField]
        private GameObject _active;

        public void SetUp()
        {
            activeGear.Clear();
            inactiveGear.Clear();
            _storage = GameObject.FindWithTag("storage");
            _active = GameObject.FindWithTag("gear");

            if (_storage != null)
            {
                foreach (Transform child in _storage.transform)
                {
                    // Access the GameObject component of the child's Transform
                    GameObject childObject = child.gameObject;

                    inactiveGear.Add(childObject);
                }
            }
        }
    }
}
