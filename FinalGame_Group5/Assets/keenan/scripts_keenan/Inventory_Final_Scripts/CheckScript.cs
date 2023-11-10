using UnityEngine;

namespace keenan.scripts_keenan.Inventory_Final_Scripts
{
    public class CheckScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            print(GameObject.FindWithTag("test").name);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
