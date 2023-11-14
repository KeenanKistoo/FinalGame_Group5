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

        [SerializeField] private GameObject _weightMan;
        
        public GameObject cam;
        

        private void Start()
        {
            _mainWeightController = GameObject.FindWithTag("weightMan").GetComponent<MainWeightController>();
            _weightMan = GameObject.FindWithTag("weightMan");
            
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
                if (_mainInventoryController.secondaryObj != null)
                {
                    _mainInventoryController.secondaryObj.transform.SetParent(cam.transform, false);
                }
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
            if (_mainInventoryController.secondaryObj != null)
            {
                _mainInventoryController.secondaryObj.transform.SetParent(_weightMan.transform, false);
            }
            _mainInventoryController.GearStateCheck();
        }
    }
}
