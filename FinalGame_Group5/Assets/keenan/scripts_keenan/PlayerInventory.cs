using UnityEngine;

namespace keenan.scripts_keenan
{
    [CreateAssetMenu(fileName = "NewPlayerInventory.asset", menuName = "Player/PlayerInventory", order = 1)]
    public class PlayerInventory : ScriptableObject
    {
        [Header("Helmet Elements:")]
        public bool helmetUnlocked;
        public int helmetLevel;
        public bool flashEnabled;

        [Header("Armour Elements:")]
        public int armourLevel;
        [Range(2, 6)]
        public int armourCount;

        [Header("Gear Elements:")]
        public bool primary;
        public string primaryName;
        public bool secondary;
        public string secondaryName;
        public bool melee;
        public string meleeName;

        [Header("Pants Elements:")]
        public int pantsLevel;
        [Range(1, 3)]
        public int legPouchCount;
        public enum AmmoOptionsPrimary
        {
            light,
            assault,
            sniper,
            shotgun
        }
        public enum AmmoOptionsSecondary
        {
            light,
            assault,
            sniper
        }
        [Header("Ammuntion Elements:")]
        public AmmoOptionsPrimary primaryAmmo;
        public AmmoOptionsSecondary secondaryAmmo;
        [Range(1, 10)]
        public int lightCount;
        [Range(1, 10)]
        public int assaultCount;
        [Range(1, 10)]
        public int sniperCount;
    }
}
