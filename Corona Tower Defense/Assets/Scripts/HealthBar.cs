using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    
    public void SetHealth(float health){
        slider.value = health;

    }

    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }
}
