using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] bool weightSelected;

    public GameObject playerSelectPanel;

    public PlayerWeightController weight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNeutralScene()
    {
        if (weightSelected)
        {
            playerSelectPanel.SetActive(false);
        }
    }

    public void LightWeight()
    {
        weightSelected = true;
        weight.ChangeWeightClass("lightweight");
    }

    public void MiddleWeight()
    {
        weightSelected = true;
        weight.ChangeWeightClass("middleweight");
    }

    public void HeavyWeight()
    {
        weightSelected = true;
        weight.ChangeWeightClass("heavyweight");
    }
}

