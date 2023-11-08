using UnityEngine;

namespace keenan.scripts_keenan
{
    public class TestScript : MonoBehaviour
    {
        public PlayerInventory player;
        public PlayerWeight playerW;
        // Start is called before the first frame update
        void Start()
        {
            player.helmetUnlocked = true;
        }

   
    }
}
