using UnityEngine;

namespace keenan.scripts_keenan
{
    [CreateAssetMenu(fileName = "NewWeapon.asset", menuName = "Gear/WeaponInfo", order = 0)]
    public class WeaponWeight : ScriptableObject
    {
        [Header("Weapon Type:")]
        public string type;

        [Header("Weapon Requirements:")]
        public bool unlocked;
        public int cost;

        [Header("Weapon Info:")]
        public int mass;
        public int bullPerClip;
    }
}
