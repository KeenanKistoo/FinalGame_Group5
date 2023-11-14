using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unathi.Scripts;

public class RespawnManager : MonoBehaviour
{
    public Transform checkPoint1;
    public Transform checkPoint2;
    public Transform checkPoint3;
    public Transform checkPoint4;
    public Transform checkPoint5;

    public int currentCheckPoint = 0;

    public GameObject respawnText;

    public Unit unit;
    //public Transform playerTransform;
    public CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        checkPoint1 = GameObject.Find("Checkpoint1").GetComponent<Transform>();
        checkPoint2 = GameObject.Find("Checkpoint2").GetComponent<Transform>();
        checkPoint3 = GameObject.Find("Checkpoint3").GetComponent<Transform>();
        checkPoint4 = GameObject.Find("Checkpoint4").GetComponent<Transform>();
        checkPoint5 = GameObject.Find("Checkpoint5").GetComponent<Transform>();

        respawnText = GameObject.Find("RespawnText");

        unit = GameObject.Find("FirstPersonPlayer").GetComponent<Unit>();

       Transform playerTransform = GameObject.Find("FirstPersonPlayer").GetComponent<Transform>();
        cc = GameObject.Find("FirstPersonPlayer").GetComponent<CharacterController>();

        respawnText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (respawnText == null)
        {
            respawnText = GameObject.Find("RespawnText");
            respawnText.SetActive(false);
        }

        /*if(playerTransform == null)
        {
            Transform playerTransform = GameObject.Find("FirstPersonPlayer").GetComponent<Transform>();
        }*/

        if (cc == null)
        {
            cc = GameObject.Find("FirstPersonPlayer").GetComponent<CharacterController>();
        }
        
        
        if (unit.currentHP < 1)
        {
            
            if (currentCheckPoint == 1)
            {
                cc.enabled = false;
                Transform playerTransform = GameObject.Find("FirstPersonPlayer").GetComponent<Transform>();
                playerTransform.transform.position = checkPoint1.transform.position;
                Debug.Log("Respawning");
                Debug.Log("CheckPoint: " + checkPoint1.transform.position);
                Debug.Log("Player: " + playerTransform.transform.position);
                cc.enabled = true; 

                if (GameObject.Find("KevlarVest"))
                {
                    unit.currentHP = 75;
                }
                else
                {
                    unit.currentHP = 50;
                }
                
            }else if(currentCheckPoint == 2)
            {
                cc.enabled = false;
                Transform playerTransform = GameObject.Find("FirstPersonPlayer").GetComponent<Transform>();
                playerTransform.transform.position = checkPoint2.transform.position;
                Debug.Log("Respawning");
                Debug.Log("CheckPoint: " + checkPoint1.transform.position);
                Debug.Log("Player: " + playerTransform.transform.position);
                cc.enabled = true;

                if (GameObject.Find("KevlarVest"))
                {
                    unit.currentHP = 75;
                }
                else
                {
                    unit.currentHP = 50;
                }
            } else if(currentCheckPoint == 3)
            {
                cc.enabled = false;
                Transform playerTransform = GameObject.Find("FirstPersonPlayer").GetComponent<Transform>();
                playerTransform.transform.position = checkPoint3.transform.position;
                Debug.Log("Respawning");
                Debug.Log("CheckPoint: " + checkPoint1.transform.position);
                Debug.Log("Player: " + playerTransform.transform.position);
                cc.enabled = true;

                if (GameObject.Find("KevlarVest"))
                {
                    unit.currentHP = 75;
                }
                else
                {
                    unit.currentHP = 50;
                }
            } else if(currentCheckPoint == 4)
            {
                cc.enabled = false;
                Transform playerTransform = GameObject.Find("FirstPersonPlayer").GetComponent<Transform>();
                playerTransform.transform.position = checkPoint4.transform.position;
                Debug.Log("Respawning");
                Debug.Log("CheckPoint: " + checkPoint1.transform.position);
                Debug.Log("Player: " + playerTransform.transform.position);
                cc.enabled = true;

                if (GameObject.Find("KevlarVest"))
                {
                    unit.currentHP = 75;
                }
                else
                {
                    unit.currentHP = 50;
                }
            } else if(currentCheckPoint == 5)
            {
                cc.enabled = false;
                Transform playerTransform = GameObject.Find("FirstPersonPlayer").GetComponent<Transform>();
                playerTransform.transform.position = checkPoint5.transform.position;
                Debug.Log("Respawning");
                Debug.Log("CheckPoint: " + checkPoint1.transform.position);
                Debug.Log("Player: " + playerTransform.transform.position);
                cc.enabled = true;

                if (GameObject.Find("KevlarVest"))
                {
                    unit.currentHP = 75;
                }
                else
                {
                    unit.currentHP = 50;
                }
            }
        }
    }
}
