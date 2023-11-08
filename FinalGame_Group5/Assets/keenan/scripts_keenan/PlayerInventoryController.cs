using UnityEngine;

namespace keenan.scripts_keenan
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [Header("Player Inventory Scriptable Obj:")]
        public PlayerInventory inventory;

        [Header("Helmet Elements:")]
        [SerializeField]
        private GameObject helmetSlot;
        [SerializeField]
        private int helmetCount;

        [Header("Armour Elements:")]
        [SerializeField]
        private GameObject[] armourSlot;
        [SerializeField]
        private int armourCount;
        [SerializeField]
        private int maxArmour;
  
        [Header("Leg Elements:")]
        [SerializeField]
        private GameObject legSlot;
        [SerializeField]
        private int legCount;

        private void Start()
        {
            armourSlot = GameObject.FindGameObjectsWithTag("ArmourSlot");
            maxArmour = 6;
            ArmourSlotSetup();
        }

        private void Update()
        {
        
        }

        public void ArmourSlotSetup()
        {
            inventory.armourCount = inventory.armourLevel * 2;
            armourCount = inventory.armourCount;
            for (int i = 0; i < maxArmour; i++)
            {
                armourSlot[i].SetActive(false);
            }
            for (int i = 0;i < armourCount; i++)
            {
                armourSlot[i].SetActive(true);
            }

       
        
        }


    }
}
