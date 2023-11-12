using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light flashlight;

    private void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        flashlight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
