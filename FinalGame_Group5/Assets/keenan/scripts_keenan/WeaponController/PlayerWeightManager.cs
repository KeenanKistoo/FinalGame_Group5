using keenan.scripts_keenan.InventoryScripts;
using max.Scriptsss;
using UnityEngine;

namespace keenan.scripts_keenan.WeaponController
{
    public class PlayerWeightManager : MonoBehaviour
    {
        [Header("Player:")]
        /*[SerializeField]
    private PlayerWeight _playerWeight;*/
        [SerializeField]
        private PlayerGear _gear;
        [SerializeField]
        private PlayerMovement _player;
        public WeaponAttach attach;

        private void Start()
        {
            // _playerWeight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeight>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            _gear = GameObject.FindGameObjectWithTag("inventory").GetComponent<PlayerGear>();
        }

        public void WeightChange(float speed)
        {
            _player.normSpeed = speed;
        }

        public void WeightMaxChange(int max)
        {
        }

    }
}
