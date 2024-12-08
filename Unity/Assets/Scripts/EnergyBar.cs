using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHEnergy(float energy)
    {
        slider.maxValue = energy;
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;
    }

    public void UseEnergy(float energy)
    {
        slider.value -= energy;
    }

    public void RestoreEnergy(float energy)
    {
        slider.value += energy;
    }
}
