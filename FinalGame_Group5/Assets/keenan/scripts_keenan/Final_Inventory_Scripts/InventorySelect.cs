using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelect : MonoBehaviour
{
    [Header("Inventory Object:")]
    public GameObject inventoryObj;
    [SerializeField]
    private InventoryProfile inventoryProfile;
    [SerializeField]
    private InventoryPlayerManager inventoryPM;

    [Header("Button Elements:")]
    public Text nameTxt;
    public Text weightTxt;
    public Image btnImg;

    [Header("Parent Objs:")]
    public GameObject equipParent;
    public GameObject storage;

    [Header("Button:")]
    [SerializeField]
    private Button invBtn;
    public bool load;

    private void Start()
    {
        SetupButton();
    }

    private void Update()
    {
        AffordCheck();
    }

    public void SetupButton()
    {
        inventoryPM = GameObject.FindGameObjectWithTag("inventory").GetComponent<InventoryPlayerManager>();
        invBtn = this.gameObject.GetComponentInChildren<Button>();
        inventoryProfile = inventoryObj.GetComponent<InventoryProfile>();
        nameTxt.text = inventoryProfile.objName;
        weightTxt.text = inventoryProfile.weight.ToString() + "KG";
        //btnImg = inventoryProfile.img;
        load = true;
    }

    public void AffordCheck()
    {
        if (load)
        {
            if (inventoryPM.currWeight >= inventoryProfile.weight)
            {
                invBtn.interactable = true;
            }
            else
            {
                invBtn.interactable = false;
            }
        }
    }

    public void AssignGear()
    {
        inventoryObj.transform.SetParent(equipParent.transform, false);
        inventoryPM.currWeight -= inventoryProfile.weight;
        load = false;
        invBtn.interactable = false;
        inventoryPM.GearCheck();
    }

}
