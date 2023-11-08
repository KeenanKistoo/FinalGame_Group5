using UnityEngine;
using UnityEngine.UI;

namespace keenan.scripts_keenan.InventoryScripts
{
    public class GearAttach : MonoBehaviour
    {
        [Header("Parent:")]
        public GameObject parent;
        public Image[] imgContainer;
        [SerializeField]
        private PlayerGear _gear;
        [SerializeField]
        private int index;

        [Header("Gear Object Elements:")]
        public GameObject gear;
        public Image gearImage;

        private void Start()
        {
            index = 0;
        }
        public void SetGear()
        {
            gear.transform.SetParent(parent.transform, false);
            gearImage = imgContainer[index];
            index++;
        }
    }
}
