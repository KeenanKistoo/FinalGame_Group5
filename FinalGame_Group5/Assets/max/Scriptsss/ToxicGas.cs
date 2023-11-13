using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unathi.Scripts;
using UnityEngine.UI;

public class ToxicGas : MonoBehaviour
{
    //public Unit unit;
    public bool inGas;
    public Unit unit;
    public GameObject gasUI;
    public GameObject gasTut;
    public Animator gasAnimator;
    public bool maskOn;
    public Image gasImage;
   void Start()
    {
        unit = GameObject.Find("FirstPersonPlayer").GetComponent<Unit>();

        gasUI = GameObject.Find("GasImageUI");
        gasTut = GameObject.Find("GasTutorial");
        gasImage = GameObject.Find("GasFill").GetComponent<Image>();
        gasAnimator = GameObject.Find("GasFill").GetComponent<Animator>();

        gasTut.SetActive(false);
        gasUI.SetActive(false);
    }

    void Update()
    {
        if (inGas)
        {
            if (!maskOn)
            {
                unit.currentHP -= 2 * Time.deltaTime;
            }
            

            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("Gas Mask On!");
                gasUI.SetActive(true);
                maskOn = true;
                gasAnimator.SetBool("GasMask", true);
                gasTut.SetActive(false);
            }
        }
        else
        {
            return;
        }

        if (gasImage.fillAmount == 0f)
        {
           gasUI.SetActive(false);
            GameObject gasMask = GameObject.Find("GasMask");
            maskOn = false;
            gasMask.SetActive(false);
        }

    }


    void OnTriggerEnter(Collider collision) 
    { 
        if (collision.gameObject.tag == "Player")
        {
            inGas = true;
            if (GameObject.Find("GasMask") != null)
            {
                gasTut.SetActive(true);
                

            }
            

        }
    
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inGas = false;
            gasTut.SetActive(false);
        }

    }

}
