using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeightController : MonoBehaviour
{
    [Header("Player Weight Scriptable Object:")]
    [Tooltip("Drag the player obj here.")]
    public PlayerWeight playerWeight;

    

    [Header("Player Movement:")]
    [SerializeField]
    private PlayerMovement playerMovement;


    private void Start()
    {
        playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        //ChangeWeightClass("lightweight");
    }

    private void Update()
    {
        if (playerMovement != null) 
        { 
            if (playerWeight.currentClass == PlayerWeight.WeightClasses.lightweight)
            {
                playerMovement.speed = playerMovement.normSpeed;
                playerWeight.exWeight = 15;
            }
            else if (playerWeight.currentClass == PlayerWeight.WeightClasses.middleweight)
            {
                playerMovement.speed = playerMovement.normSpeed * 0.9f;
                playerWeight.exWeight = 20;
            }
            else if (playerWeight.currentClass == PlayerWeight.WeightClasses.heavyweight)
            {
                playerMovement.speed = playerMovement.normSpeed * 0.8f;
                playerWeight.exWeight = 30;
            }
        }
    }

    public void ChangeWeightClass(string weightClass)
    {
        PlayerWeight.WeightClasses[] weightClasses = PlayerWeight.WeightClasses.GetValues(typeof(PlayerWeight.WeightClasses)) as PlayerWeight.WeightClasses[];
        for (int i = 0; i < weightClasses.Length; i++)
        {

            if (weightClass.Equals(weightClasses[i].ToString()))
            {
                //playerWeight.currentClass = PlayerWeight.WeightClasses.weightClass;
            }


        }

    }

}
