using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsSlider : MonoBehaviour
{
    public Slider ControlSlider;
    public int currentSliderValue;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("controlType"))
        {
            SetSliderValue(PlayerPrefs.GetInt("controlType"));
            Debug.Log("Controls Found, Mode - "+PlayerPrefs.GetInt("controlType"));
        }
        else
        {
            PlayerPrefs.SetInt("controlType", 0);
            SetSliderValue(PlayerPrefs.GetInt("controlType"));
            Debug.Log("Controls NOT Found, Default - " + PlayerPrefs.GetInt("controlType"));
        }
    }
    public void SetSliderValue(int value)
    {
        ControlSlider.value = value;
    }
    public void OnValueChanged()
    {
        PlayerPrefs.SetInt("controlType", (int)ControlSlider.value);
        Debug.Log("Value Set to " + (int)ControlSlider.value);
    }
}

