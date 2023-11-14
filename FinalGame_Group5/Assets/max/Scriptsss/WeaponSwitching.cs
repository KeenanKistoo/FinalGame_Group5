using keenan.scripts_keenan.InventoryScripts;
using UnityEngine;
using UnityEngine.UI;

namespace max.Scriptsss
{
    public class WeaponSwitching : MonoBehaviour
    {
        public int selectedWeapon = 0;
        public Text weaponName;
        //public WeaponAttach weaponAttach;

        private Animator previousWeaponAnimator; // Store the previous weapon's animator
        private Animator currentWeaponAnimator; // Store the current weapon's animator
        public float weaponSwitchDelay = 0f;

        void Start()
        {
            SelectWeapon();
            //weaponAttach = GameObject.Find("M4A1_purchase_btn").GetComponent<WeaponAttach>();
        }

        void Update()
        {
            int previousSelectedWeapon = selectedWeapon;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedWeapon = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedWeapon = 2;
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
            }
        }

    

        public void SelectWeapon()
        {
            int i = 0;

            foreach (Transform child in transform)
            {
                Transform weapon = child; // Access the child transform.

                if (i == selectedWeapon)
                {
                    // Activate the selected weapon.
                    weapon.gameObject.SetActive(true);
                    weaponName.text = weapon.name;

                    // Reset animation state to idle.
                    // You can trigger the idle animation here.
                    currentWeaponAnimator = weapon.GetComponent<Animator>();
                    currentWeaponAnimator.Play("TakeOut");
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                    previousWeaponAnimator = currentWeaponAnimator; // Store the previous weapon's animator.
                }

                i++;
            }
        }
    }
}
