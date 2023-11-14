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
    
    public Animator gasAnimator;
    public bool maskOn;
    

    public GasManager gasManager;
   void Start()
    {
        unit = GameObject.Find("FirstPersonPlayer").GetComponent<Unit>();
        gasManager = GameObject.Find("GasManager").GetComponent<GasManager>();

        gasAnimator = GameObject.Find("GasFill").GetComponent<Animator>();

        
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
                gasManager.gasUI.SetActive(true);
                maskOn = true;
                gasAnimator.SetBool("GasMask", true);
                gasManager.gasTut.SetActive(false);
            }
        }
        else
        {
            return;
        }

        if (gasManager.gasImage.fillAmount == 0f)
        {
            gasManager.gasUI.SetActive(false);
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
                gasManager.gasTut.SetActive(true);
                

            }
            

        }
    
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inGas = false;
            gasManager.gasTut.SetActive(false);
        }

    }

}
