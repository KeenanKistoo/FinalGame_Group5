using UnityEngine;

namespace unathi.Scripts
{
    public class NodeScript : MonoBehaviour
    {
        LevelManager levelManager;
        Battle battle;
        public bool active;
        private bool addedToHidingSpots = false; // Flag to track if added to the list

        void Start()
        {
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            battle = GameObject.Find("BattleManager").GetComponent<Battle>();

            if(gameObject.tag == "Level1")
            {
                levelManager.hidingSpots_b1.Add(gameObject.transform);
                addedToHidingSpots = true;
            }
            else
            {
                levelManager.hidingSpots.Add(gameObject.transform);
                addedToHidingSpots = true;
            }
                

        }

        private void Awake()
        {
            active = true;
        }

        void Update()
        {
            if (active && !addedToHidingSpots)
            {
                if (gameObject.tag == "Level1")
                {
                    levelManager.hidingSpots_b1.Add(gameObject.transform);
                    addedToHidingSpots = true; // Set the flag to true once added
                }
                
            }
            else if (!active && addedToHidingSpots)
            {
                if (gameObject.tag == "Level1")
                {
                    levelManager.hidingSpots_b1.Remove(gameObject.transform);
                    addedToHidingSpots = false; // Set the flag to true once added
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                active = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                active = true;
            }
        }

    }
}
