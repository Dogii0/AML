using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarBoss : MonoBehaviour
{
    public Slider Slider;
    public Image fill;
    public Gradient gradient;

    public void SetHealthmax(double health)
    {
        Slider.value = (float)health;
        Slider.maxValue = (float)health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealthboss(double health)
    {
        Slider.value = (float)health;
        fill.color = gradient.Evaluate(Slider.normalizedValue);
    }
    
    

    // Update is called once per frame
}
