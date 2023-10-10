using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Holster:")]
    public GameObject[] weapons;

    [Header("Weapon Panel:")]
    public GameObject weaponPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (weaponPanel.activeInHierarchy) { 
                weaponPanel.SetActive(false);
            }
            else
            {
                weaponPanel.SetActive(true);
            }
        }
    }


}
