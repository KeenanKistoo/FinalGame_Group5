using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer.asset", menuName = "Player/PlayerInventory", order = 1)]
public class PlayerInventory : ScriptableObject
{
    [Header("Helmet Elements:")]
    public bool helmetUnlocked;
    public int helmetLevel;
    public bool flashEnabled;

}
