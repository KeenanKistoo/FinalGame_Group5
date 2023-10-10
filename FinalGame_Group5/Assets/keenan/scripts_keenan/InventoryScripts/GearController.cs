using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearController : MonoBehaviour
{
    [Header("Slot Info:")]
    public string type;
    public int level;
    public int maxSlot;
    public int slot;
    public int multiplier;

    [Header("Inventory System:")]
    public string[] gearNames = new string[3];
    public GameObject[] gear = new GameObject[3];
    public Text weightCount;
    [SerializeField]
    private int index;

    [Header("Gear Prefab:")]
    public GameObject[] prefabs;
    [SerializeField]
    private GameObject _parent;
    [SerializeField]
    private GameObject _storage;

    private void Start()
    {
        _parent = GameObject.FindGameObjectWithTag(type);
        _storage = GameObject.FindGameObjectWithTag("storage");
        SetSlots();
    }

    public void SetSlots()
    {
        slot = level * multiplier;
        index = 0;
        for(int i = 0; i < prefabs.Length; i++)
        {
            prefabs[i].transform.SetParent(_storage.transform, false);
        }
    }

    public void SelectGear()
    {
        prefabs[index].transform.SetParent(_parent.transform, false);
        index++;
    }
}
