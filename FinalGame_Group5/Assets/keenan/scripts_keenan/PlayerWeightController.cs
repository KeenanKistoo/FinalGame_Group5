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
    }

    private void Update()
    {
        if(playerWeight.currentClass == PlayerWeight.WeightClasses.lightweight)
        {
            playerMovement.speed = playerMovement.normSpeed;
        }
        else if (playerWeight.currentClass == PlayerWeight.WeightClasses.middleweight)
        {
            playerMovement.speed = playerMovement.normSpeed * 0.9f;
        }
        else if(playerWeight.currentClass == PlayerWeight.WeightClasses.heavyweight)
        {
            playerMovement.speed = playerMovement.normSpeed * 0.8f;
        }
    }
}
