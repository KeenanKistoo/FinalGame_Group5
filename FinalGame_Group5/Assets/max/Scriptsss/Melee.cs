using UnityEngine;

namespace max.Scriptsss
{
    public class Melee : MonoBehaviour
    {

        public Animator animator;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetBool("melee", true);
            }
            else
            {
                animator.SetBool("melee", false);
            }
        }
    }
}
