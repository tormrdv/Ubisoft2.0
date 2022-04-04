using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager: MonoBehaviour
{
    public GameObject PlayerVehicle;
    public GameObject VehicleControls;
    public GameObject ResetButton;
    public GameObject StartScreen;


    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
        
    }
    private int ControlCheckup()
    {
        if (!PlayerPrefs.HasKey("controlType"))
        {
            PlayerPrefs.SetInt("controlType", 0);
            Debug.Log("Controls missing, setting to default 0");
        }
        int controltype = PlayerPrefs.GetInt("controlType");
        Debug.Log("ControlSet to " + controltype);
        PlayerVehicle.GetComponent<CarContoller>().SetControlType(controltype);
        return controltype;
        

    }
    public void StartGame()
    {
        PlayerVehicle.SetActive(true);
        ResetButton.SetActive(true);
        StartScreen.SetActive(false);
        switch (ControlCheckup())
        {
            case 0:
                VehicleControls.SetActive(true);
                break;
            case 1:
                VehicleControls.SetActive(false);
                break;
        }

    }
    public void ResetGame()
    {
        PlayerVehicle.GetComponent<CarContoller>().SetCarToStart();
        VehicleControls.SetActive(false);
        ResetButton.SetActive(false);
        StartScreen.SetActive(true);
    }
    public void PlayerPrefCheck()
    {
        if (PlayerPrefs.HasKey("controls"))
        {
            Debug.Log("Controls Found, Mode - " + PlayerPrefs.GetInt("controls"));
        }
        else
        {
            PlayerPrefs.SetInt("controls", 0);
        }
    }
}
