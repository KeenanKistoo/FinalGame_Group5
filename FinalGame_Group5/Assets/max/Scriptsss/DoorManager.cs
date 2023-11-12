using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{

    public GameObject LockPickUI;
    public Animator fillAnimator;
    public Animator doorAnimator;
   
    public Image fillImage;
    public bool canLockPick;

    // Start is called before the first frame update
    void Start()
    {
        LockPickUI = GameObject.Find("LockPickDoorUI");
        fillAnimator = GameObject.Find("LockPickFill").GetComponent<Animator>();
        fillImage = GameObject.Find("LockPickFill").GetComponent<Image>();
        doorAnimator = GameObject.Find("Pivot").GetComponent<Animator>();
        

        LockPickUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
