using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeightManager : MonoBehaviour
{
    [Header("Player:")]
    /*[SerializeField]
    private PlayerWeight _playerWeight;*/
    [SerializeField]
    private PlayerGear _gear;
    [SerializeField]
    private PlayerMovement _player;

    private void Start()
    {
       // _playerWeight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeight>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void WeightChange(float speed)
    {
        _player.normSpeed = speed;
    }

}
