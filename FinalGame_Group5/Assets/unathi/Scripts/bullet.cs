using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   

    private void OnCollisionEnter(Collision collision)
    {
       /*if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Target")
        {
            Debug.Log("Owi");
            Unit unit = collision.gameObject.GetComponent<Unit>();
            unit.TakeDamage(5);
            Destroy(gameObject);
        }*/

        if (collision.gameObject.tag == "Training")
        {
            level.StartTraining();
        }

        if (collision.gameObject.tag == "Battle")
        {
            level.StartBattle();
        }

        Destroy(gameObject);
    }
}
