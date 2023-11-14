using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unathi.Scripts;
using UnityEngine.UI;

public class GasManager : MonoBehaviour
{
    public Unit _unit;
    public GameObject gasUI;
    public GameObject gasTut;
    public Image gasImage;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("FirstPersonPlayer");

        gasUI = GameObject.Find("GasImageUI");
        gasTut = GameObject.Find("GasTutorial");
        gasImage = GameObject.Find("GasFill").GetComponent<Image>();
        gasTut.SetActive(false);
        gasUI.SetActive(false);
        if (playerObject != null)
        {
            _unit = playerObject.GetComponent<Unit>();

            if (_unit == null)
            {
                Debug.LogError("Unit script not found on FirstPersonPlayer.");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
