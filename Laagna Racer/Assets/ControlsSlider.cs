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
        SetSliderValue(PlayerPrefs.GetInt("ControlType"));
        Debug.Log("Controls Found, Mode - "+PlayerPrefs.GetInt("ControlType"));
    }
    public void SetSliderValue(int value)
    {
        ControlSlider.value = value;
    }
    public void OnValueChanged()
    {
        PlayerPrefs.SetInt("ControlType", (int)ControlSlider.value);
        Debug.Log("Value Set to " + (int)ControlSlider.value);
    }
}

