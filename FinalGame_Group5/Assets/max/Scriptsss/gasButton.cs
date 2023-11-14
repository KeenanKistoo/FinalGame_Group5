using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasButton : MonoBehaviour
{

    public GameObject gasToTurnOff;
    public GameObject turnOffText;
    public Animator buttonAnimator;

    public bool canPressButton = false;

    void Start()
    {
        turnOffText = GameObject.Find("GasTurnOffText");
        buttonAnimator = GetComponent<Animator>();

        turnOffText.SetActive(false);
    }

    void Update()
    {

        if (canPressButton)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                turnOffText.SetActive(false);
                gasToTurnOff.SetActive(false);
                buttonAnimator.SetBool("Push", true);
            }
        }
        
    }


    void OnTriggerEnter(Collider collision)
    {
        turnOffText.SetActive(true);
        canPressButton = true;
    }

    void OnTriggerExit(Collider collision)
    {
        turnOffText.SetActive(false);
        canPressButton = false;
    }
}
