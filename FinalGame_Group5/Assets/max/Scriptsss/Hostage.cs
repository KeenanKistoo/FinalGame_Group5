using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hostage : MonoBehaviour
{
   
    public bool canRescue;

    private HostageManager hostageManager;
    // Start is called before the first frame update
    void Start()
    {
        hostageManager = FindObjectOfType<HostageManager>();
        if (hostageManager == null)
        {
            Debug.LogError("HostageManager not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
       

        if (canRescue)
        {
            if (hostageManager.fillImage.fillAmount > 0.95f)
            {
                
                
                hostageManager.HostageUI.SetActive(false);
                hostageManager.fillImage.fillAmount = 0;
                gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                hostageManager.animator.SetBool("Fill", true);
               /* if (fillImage.fillAmount > 0.1f)
                {
                    Debug.Log(fillImage.fillAmount);
                    GameObject UI = GameObject.Find("HostageRescue");
                    UI.SetActive(false);
                    gameObject.SetActive(false);
                }*/
            }

            if(Input.GetKeyUp(KeyCode.F))
            {
                hostageManager.animator.SetBool("Fill", false);
                
            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            hostageManager.HostageUI.SetActive(true);
            canRescue = true;
        }
        
    }

    public void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            hostageManager.HostageUI.SetActive(false);
            canRescue = false;
        }
        
    }


}
