using UnityEngine;

namespace unathi.Scripts
{
    public class Bullet : MonoBehaviour
    {
        LevelManager level;
    
        private Unit unit;
    

        // Start is called before the first frame update
        void Start()
        {
            level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        
        }

        // Update is called once per frame
   

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Target" || collision.gameObject.tag == "Enemy_h")
            {
                Debug.Log("Owi");
                Unit unit = collision.gameObject.GetComponent<Unit>();
                unit.TakeDamage(5);
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Training")
            {
                level.StartTraining();
            }

            if (collision.gameObject.tag == "Rescue")
            {
                level.StartRescue();
            }

            if (collision.gameObject.tag == "Battle")
            {
                level.StartBattle();
            }

            Destroy(gameObject);
        }
    }
}
