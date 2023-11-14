using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombManager : MonoBehaviour
{

    public GameObject BombUI;
    public Animator animator;
    public Image fillImage;
    // Start is called before the first frame update
    void Start()
    {
        BombUI = GameObject.Find("BombDefuseUI");
        animator = GameObject.Find("DefuseFill").GetComponent<Animator>();
        fillImage = GameObject.Find("DefuseFill").GetComponent<Image>();

        BombUI.SetActive(false);
    }

   
}
