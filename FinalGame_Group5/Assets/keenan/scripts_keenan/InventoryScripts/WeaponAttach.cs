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
    

    [Header("UI Elements:")]
    public Text weightText;

    [Header("Weapon Holster Elements:")]
    [SerializeField]
    private GameObject _primary;
    [SerializeField]
    private GameObject _secondary;

    [Header("Weapon UI Elements:")]
    public Image primaryImg;
    public Image secondaryImg;

    [Header("Weapon Prefabs:")]
    public GameObject weapon;
    
    private void Start()
    {
        _playerGear = GameObject.FindGameObjectWithTag("inventory").GetComponent<PlayerGear>();
        _primary = GameObject.FindGameObjectWithTag("primary");
        _secondary = GameObject.FindGameObjectWithTag("secondary");
        StartCoroutine(WeightCheck());
    }

    IEnumerator WeightCheck()
    {
        yield return new WaitForEndOfFrame();
        weightText.text = _playerGear.currWeight.ToString() + "KG";
    }

    public void SetWeapon(Sprite weaponImg)
    {
        if(_primary.transform.childCount == 0)
        {
            primaryImg.sprite = weaponImg;
            primaryImg.color = Color.white;
            weapon.transform.SetParent(_primary.transform, false);
        }else if(_primary.transform.childCount > 0 && _secondary.transform.childCount == 0)
        {
            secondaryImg.sprite = weaponImg;
            secondaryImg.color = Color.white;
            weapon.transform.SetParent(_secondary.transform, false);
        }

    }
}
