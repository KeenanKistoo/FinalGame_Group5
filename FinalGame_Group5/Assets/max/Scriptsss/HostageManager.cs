using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostageManager : MonoBehaviour
{
    public GameObject HostageUI;
    public Animator animator;
    public Image fillImage;
    
    // Start is called before the first frame update
    void Start()
    {
        HostageUI = GameObject.Find("HostageRescue");
        animator = GameObject.Find("HostageFill").GetComponent<Animator>();
        fillImage = GameObject.Find("HostageFill").GetComponent<Image>();

        HostageUI.SetActive(false);
    }
}

   

