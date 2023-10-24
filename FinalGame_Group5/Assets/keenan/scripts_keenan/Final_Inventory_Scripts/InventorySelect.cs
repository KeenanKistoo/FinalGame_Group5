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
    public GameObject btnImg;

    [Header("Parent Objs:")]
    public GameObject equipParent;
    public GameObject storage;

    [Header("Button:")]
    [SerializeField]
    private Button invBtn;
    public bool load;

    [Header("Equipped Elements:")]
    public GameObject equippedImg;

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
        btnImg.GetComponent<Image>().sprite = inventoryProfile.img;
        load = true;
        SlotCheck();
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
        equippedImg.GetComponent<Image>().sprite = inventoryProfile.img;
        load = false;
        invBtn.interactable = false;
        inventoryPM.GearCheck();
        SlotCheck();
    }

    public void SlotCheck()
    {
        if(equippedImg.GetComponent<Image>().sprite != null)
        {
            equippedImg.GetComponentInChildren<Button>().interactable = true;
        }
        else
        {
            equippedImg.GetComponentInChildren<Button>().interactable = false;

        }
    }

    public void Unequip()
    {
        inventoryObj.transform.SetParent(storage.transform, false);
        inventoryPM.currWeight += inventoryProfile.weight;
        equippedImg.GetComponent<Image>().sprite = null;
        load = true;
        invBtn.interactable = true;
        inventoryPM.GearCheck();
        SlotCheck();
    }

}
