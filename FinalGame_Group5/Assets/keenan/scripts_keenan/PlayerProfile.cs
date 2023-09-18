using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerProfile.asset", menuName = "Player/PlayerProfile", order = 0)]
public class PlayerProfile : ScriptableObject
{
    [Header("Player Main Details:")]
    public string playerName;

    [Header("Player Health Elements:")]
    public float minHealth;
    public float maxHealth;
    [Range(0f, 10f)]
    public float health;

    [Header("Player Mass:")]
    [Range(45, 125)]
    public int mass;

}

