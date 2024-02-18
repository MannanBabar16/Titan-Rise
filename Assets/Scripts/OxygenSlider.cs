using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenSlider : MonoBehaviour {
    public OxygenSystem oxygenSystem; // Reference to the OxygenSystem script
    public Slider oxygenSlider; // Reference to the UI Slider

    void Update() {
        // Update the slider value based on the current oxygen percentage
        oxygenSlider.value = oxygenSystem.CurrentOxygenPercentage();
    }
}

