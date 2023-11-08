using unathi.Scripts;
using UnityEngine;

namespace unathi.Prefabs
{
    public class KeyScript : MonoBehaviour
    {
        LevelManager level;

        // Start is called before the first frame update
        void Start()
        {
            level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("Player"))
            {
                level.key = true;
                Destroy(gameObject);
            }
        
        }
    }
}
