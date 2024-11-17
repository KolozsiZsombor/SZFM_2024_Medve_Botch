using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHEnergy(int energy)
    {
        slider.maxValue = energy;
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;
    }

    public void UseEnergy(int energy)
    {
        slider.value -= energy;
    }

    public void RestoreEnergy(int energy)
    {
        slider.value += energy;
    }
}
