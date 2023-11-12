using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField]
    
    public bool hasFirstAid;
    public GameObject heal;
    public GameObject weaponHolder;
    public bool healMe = false;
    

    // Start is called before the first frame update
    void Start()
    {
        heal = GameObject.Find("Heal");
        weaponHolder = GameObject.Find("WeaponHolder");
        heal.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFirstAid && Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponHolder.SetActive(false);
            heal.SetActive(true);
            StartCoroutine(Wait());

        }
    }

    IEnumerator Wait()
    {
        
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5.15f);
        healMe = true;
        heal.SetActive(false);
        weaponHolder.SetActive(true);
    }
}
