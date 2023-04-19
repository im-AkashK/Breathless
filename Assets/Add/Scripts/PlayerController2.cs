using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    public float maxOxygen = 30f; // Maximum oxygen level
    public float currentOxygen = 30f; // Current oxygen level
    

    private void Update()
    {
        // Decrease the oxygen level over time
        currentOxygen -= Time.deltaTime;

        // Update the oxygen bar UI
        //oxygenLvl.SetOxygenLevel(currentOxygen);
    }
}
