using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPick : MonoBehaviour
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
        fillAnimator = GameObject.Find("Fill").GetComponent<Animator>();
        fillImage = GameObject.Find("Fill").GetComponent<Image>();

        LockPickUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (fillImage.fillAmount > 0.95f)
        {
           
            
            LockPickUI.SetActive(false);
            doorAnimator.SetBool("Open", true);
        }
        if (canLockPick)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fillAnimator.SetBool("Fill", true);
                if (fillImage.fillAmount > 0.1f)
                {
                    
                    
                    LockPickUI.SetActive(false);
                    doorAnimator.SetBool("Open", true);
                }
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                fillAnimator.SetBool("Fill", false);

            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            LockPickUI.SetActive(true);
            canLockPick = true;
        }

    }

    public void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            LockPickUI.SetActive(false);
            canLockPick = false;
        }

    }
}
