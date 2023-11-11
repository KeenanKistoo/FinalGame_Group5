using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hostage : MonoBehaviour
{
    public GameObject HostageText;
    public Animator animator;
    public Image fillImage;
    public bool canRescue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (fillImage.fillAmount > 0.95f)
        {
            Debug.Log(fillImage.fillAmount);
            GameObject UI = GameObject.Find("HostageRescue");
            UI.SetActive(false);
            gameObject.SetActive(false);
        }
        if (canRescue)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("Fill", true);
                if (fillImage.fillAmount > 0.1f)
                {
                    Debug.Log(fillImage.fillAmount);
                    GameObject UI = GameObject.Find("HostageRescue");
                    UI.SetActive(false);
                    gameObject.SetActive(false);
                }
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
            HostageText.SetActive(true);
            canRescue = true;
        }
        
    }

    public void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            HostageText.SetActive(false);
            canRescue = false;
        }
        
    }


}
