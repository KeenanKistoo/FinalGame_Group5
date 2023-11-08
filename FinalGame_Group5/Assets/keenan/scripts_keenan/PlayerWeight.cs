using UnityEngine;

namespace keenan.scripts_keenan
{
    [CreateAssetMenu(fileName = "NewPlayerWeight.asset", menuName = "Player/PlayerMass", order = 2)]
    public class PlayerWeight : ScriptableObject
    {
        public enum WeightClasses
        {
            lightweight,
            middleweight,
            heavyweight
        }
        [Header("Weight Class:")]
        public WeightClasses currentClass;

        [Header("Body Mass:")]
        [Range(45, 125)]
        public int bodyMass;

        [Header("Excess Weight Elements:")]
        public int exWeight;
    }
}
