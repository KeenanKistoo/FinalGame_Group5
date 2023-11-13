using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDefuse : MonoBehaviour
{
   



    public bool canDefuse;

    private BombManager bombManager;
    // Start is called before the first frame update
    void Start()
    {
        bombManager = GameObject.Find("BombManager").GetComponent<BombManager>();
        if (bombManager == null)
        {
            Debug.LogError("HostageManager not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (canDefuse)
        {
            if (bombManager.fillImage.fillAmount > 0.95f)
            {


                bombManager.BombUI.SetActive(false);
                bombManager.fillImage.fillAmount = 0;
                gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                bombManager.animator.SetBool("Fill", true);
                /* if (fillImage.fillAmount > 0.1f)
                 {
                     Debug.Log(fillImage.fillAmount);
                     GameObject UI = GameObject.Find("HostageRescue");
                     UI.SetActive(false);
                     gameObject.SetActive(false);
                 }*/
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                bombManager.animator.SetBool("Fill", false);

            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            bombManager.BombUI.SetActive(true);
            canDefuse = true;
        }

    }

    public void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            bombManager.BombUI.SetActive(false);
            canDefuse = false;
        }

    }




}
