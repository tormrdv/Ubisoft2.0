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
        if (PlayerPrefs.HasKey("controls"))
        {
            SetSliderValue(PlayerPrefs.GetInt("controls"));
            Debug.Log("Controls Found, Mode - "+PlayerPrefs.GetInt("controls"));
        }
        else
        {
            PlayerPrefs.SetInt("controls", 0);
            SetSliderValue(PlayerPrefs.GetInt("controls"));
            Debug.Log("Controls NOT Found, Default - " + PlayerPrefs.GetInt("controls"));
        }
    }
    public void SetSliderValue(int value)
    {
        ControlSlider.value = value;
    }
    public void OnValueChanged()
    {
        PlayerPrefs.SetInt("controls", (int)ControlSlider.value);
        Debug.Log("Value Set to " + (int)ControlSlider.value);
    }
}

