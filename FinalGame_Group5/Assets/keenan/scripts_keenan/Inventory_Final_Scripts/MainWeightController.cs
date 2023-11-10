using System;
using UnityEngine;
using UnityEngine.UI;

namespace keenan.scripts_keenan.Inventory_Final_Scripts
{
    public class MainWeightController : MonoBehaviour
    {
        public int maxWeight;
        public int currWeight;

        public Text weightTxt;

        private void Update()
        {
            weightTxt.text = currWeight + "KG";
        }
    }
}
