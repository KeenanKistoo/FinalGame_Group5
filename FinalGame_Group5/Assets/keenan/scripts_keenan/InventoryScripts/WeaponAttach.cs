using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponAttach : MonoBehaviour
{
    [Header("Player Gear Script:")]
    [SerializeField]
    private PlayerGear _playerGear;

    [Header("Weapon Controller:")]
    [SerializeField]
    private WeaponController _weaponController;
    [SerializeField]
    private GameObject[] _weapons;
    [SerializeField]
    private GameObject _storage;

    [Header("UI Elements:")]
    public Text weightText;

    [Header("Weapon Holster Elements CORRECT:")]
    [SerializeField]
    private GameObject _weaponHolster;
    [SerializeField]
    private int _weaponCount;

    [Header("Weapon UI Elements:")]
    public Image primaryImg;
    public Image secondaryImg;
    public Image[] weaponImgs;

    [Header("Weapon Prefabs:")]
    public GameObject weapon;
    [SerializeField]
    public WeaponInfo _weaponInfo;
    

    [Header("Weapon Purchase Panel:")]
    public GameObject weaponPanel;
    public Button[] weaponBtns;
    
    private void Start()
    {
        _playerGear = GameObject.FindGameObjectWithTag("inventory").GetComponent<PlayerGear>();
        _weaponInfo = weapon.GetComponent<WeaponInfo>();
        _weaponHolster = GameObject.FindGameObjectWithTag("holster");
        _weaponCount = _weaponHolster.transform.childCount;
        _storage = GameObject.FindGameObjectWithTag("storage");
        print(_weaponCount);
        StartCoroutine(WeightCheck());
    }
    private void Update()
    {
        _weaponCount = _weaponHolster.transform.childCount;    
        print(_weaponCount);
    }
    IEnumerator WeightCheck()
    {
        yield return new WaitForEndOfFrame();
        weightText.text = _playerGear.currWeight.ToString() + "KG";
    }

    public void SetWeapon(Sprite weaponImg)
    {
        if (_weaponCount < 3 && _playerGear.currWeight >= _weaponInfo.weight)
        {
            weaponImgs[_weaponCount - 1].sprite = weaponImg;
            weaponImgs[_weaponCount - 1].color = Color.white;
            weapon.SetActive(true);
            weapon.transform.SetParent(_weaponHolster.transform, false);
            _weaponController.weapons[_weaponCount - 1] = weapon;
            _playerGear.currWeight -= _weaponInfo.weight;
            this.gameObject.GetComponent<Button>().interactable = false;
            StartCoroutine(WeightCheck());
        }
    }

    public void ClearWeapon()
    {
        for (int i = 0;i < _weaponController.weapons.Length;i++)
        {
            _weaponController.weapons[i].transform.SetParent(_storage.transform, false);
            _playerGear.currWeight += _weaponController.weapons[i].GetComponent<WeaponInfo>().weight;
            for (int j = 0; j < weaponBtns.Length;j++)
            {
                weaponBtns[j].interactable = true;
            }
            StartCoroutine(WeightCheck());
            weaponImgs[i].sprite = null;
            weaponImgs[i].color = new Color32(0,0,0,0);
        }
    }
}
