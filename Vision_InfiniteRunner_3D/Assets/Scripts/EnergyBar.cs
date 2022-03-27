using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

    public Slider slider;
    public float energyPercentage;
    public Text energyText;
    

    void Start()
    {
        
    }

    void Update()
    {
        energyPercentage = slider.value;
        energyText.text = energyPercentage.ToString();
    }

    public void SetMaxEnergy(int energy)
    {
        slider.maxValue = energy;
        slider.value = energy;        
    }
    
    public void SetEnergy(int energy)
    {
        slider.value = energy;        
    }
   
}
