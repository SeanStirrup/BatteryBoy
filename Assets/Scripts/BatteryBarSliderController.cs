using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBarSliderController : MonoBehaviour
{

    public Slider playerBatterySlider;
    public static float batterySliderCurrent = 5f;
    public float batterySliderFull = 5f;

    public Image sliderFull;

    public Color fullSlider;
    public Color lowSlider;
    // Start is called before the first frame update
    void Start()
    {
        batterySliderCurrent = 5f;
        batterySliderFull = 5f;
        playerBatterySlider.maxValue = batterySliderFull;
    }

    // Update is called once per frame
    // Sorry I know how to do this with lerp but for some reason it hated me so we get jank version sorry
    void Update()
    {
        //sets the value of the slider to the current value of the battery charge
        playerBatterySlider.value = batterySliderCurrent;
        //sliderFull.color = Color.Lerp(lowSlider, fullSlider, batterySliderCurrent / batterySliderFull);

        //sets the color of the slider based on it's value
        //adjust the numbers in the if statements to get different colors
        if(batterySliderCurrent == 5)
        {
            sliderFull.color = new Color(0, 1, 0);
        } else if (batterySliderCurrent == 4)
        {
            sliderFull.color = new Color(0.25f, 0.75f, 0);
        }
        else if (batterySliderCurrent == 3)
        {
            sliderFull.color = new Color(0.4f, 0.6f, 0);
        }
        else if (batterySliderCurrent == 2)
        {
            sliderFull.color = new Color(0.6f, 0.4f, 0);
        }
        else if (batterySliderCurrent == 1)
        {
            sliderFull.color = new Color(0.75f, 0.25f, 0);
        }
        else if (batterySliderCurrent == 0)
        {
            sliderFull.color = new Color(1, 0, 0);
        }
    }
}
