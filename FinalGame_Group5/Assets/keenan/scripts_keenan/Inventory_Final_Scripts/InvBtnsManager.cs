using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace keenan.scripts_keenan.Inventory_Final_Scripts
{
    public class InvBtnsManager : MonoBehaviour
    {
        public Image btnImg;
        public Text weightTxt;
        public Text nameTxt;

        public float weight;
        
        public GameObject weightObj;

        [SerializeField] 
        private MainWeightController _mainWeightController;

        private void Start()
        {
            _mainWeightController = GameObject.FindWithTag("weightMan").GetComponent<MainWeightController>();

        }

        public void Purchase()
        {
            float currWeight = _mainWeightController.currWeight;

            if (weight <= currWeight)
            {
                currWeight -= weight;
                _mainWeightController.currWeight = currWeight;
                MainInventoryController _mainInventoryController = weightObj.GetComponent<MainInventoryController>();
                _mainInventoryController.currInvState = MainInventoryController.GearState.active;
                _mainInventoryController.GearStateCheck();
            }
            else
            {
                StartCoroutine(ColorChange());
            }
        }

        IEnumerator ColorChange()
        {
            weightTxt.color = Color.red;
            _mainWeightController.weightTxt.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            weightTxt.color = Color.white;
            _mainWeightController.weightTxt.color = Color.white;

        }
        public void Refund()
        {
            _mainWeightController.currWeight += weight;
            MainInventoryController _mainInventoryController = weightObj.GetComponent<MainInventoryController>();
            _mainInventoryController.currInvState = MainInventoryController.GearState.inactive;
            _mainInventoryController.GearStateCheck();
        }
    }
}
