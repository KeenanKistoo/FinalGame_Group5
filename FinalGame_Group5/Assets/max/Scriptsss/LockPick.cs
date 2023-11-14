using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPick : MonoBehaviour
{
    private DoorManager doorManager;
    public bool canLockPick;
    public KeyManager keyManager;
    // Start is called before the first frame update
    void Start()
    {
        doorManager = FindObjectOfType<DoorManager>();
        keyManager = GameObject.Find("KeyManager").GetComponent<KeyManager>();
        if (doorManager == null)
        {
            Debug.LogError("HostageManager not found!");
        }

    }

    // Update is called once per frame
    void Update()
    {

        
        if (canLockPick)
        {

            if (doorManager.fillImage.fillAmount > 0.95f)
            {


                doorManager.LockPickUI.SetActive(false);
                doorManager.doorAnimator.SetBool("Open", true);
                doorManager.fillImage.fillAmount = 0;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                keyManager.keys--;
                doorManager.fillAnimator.SetBool("Fill", true);
               /* if (fillImage.fillAmount > 0.1f)
                {
                    
                    
                    LockPickUI.SetActive(false);
                    doorAnimator.SetBool("Open", true);
                }*/
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                doorManager.fillAnimator.SetBool("Fill", false);

            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            doorManager.doorAnimator = GetComponentInParent<Animator>();
            

            if (GameObject.Find("LockPick") != null)
            {
                canLockPick = true;
                doorManager.LockPickUI.SetActive(true);
            } else if (keyManager.keys > 0)
            {
                canLockPick = true;
                doorManager.LockPickUI.SetActive(true);
            }
            else
            {
                return;
            }
            
        }

    }

    public void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            doorManager.LockPickUI.SetActive(false);

            
            canLockPick = false;
        }

    }
}
