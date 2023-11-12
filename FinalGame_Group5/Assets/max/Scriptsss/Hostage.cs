using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hostage : MonoBehaviour
{
    public GameObject HostageUI;
    public Animator animator;
    public Image fillImage;
    public bool canRescue;
    // Start is called before the first frame update
    void Start()
    {
        HostageUI = GameObject.Find("HostageRescue");
        animator = GameObject.Find("HostageFill").GetComponent<Animator>();
        fillImage = GameObject.Find("HostageFill").GetComponent<Image>();
        
        HostageUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (canRescue)
        {
            if (fillImage.fillAmount > 0.95f)
            {
                Debug.Log(fillImage.fillAmount);
                
                HostageUI.SetActive(false);
                gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("Fill", true);
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
                animator.SetBool("Fill", false);
                
            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            HostageUI.SetActive(true);
            canRescue = true;
        }
        
    }

    public void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            HostageUI.SetActive(false);
            canRescue = false;
        }
        
    }


}
