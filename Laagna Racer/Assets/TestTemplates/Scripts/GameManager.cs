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
    public void StartGame()
    {
        PlayerVehicle.SetActive(true);
        VehicleControls.SetActive(true);
        ResetButton.SetActive(true);
        StartScreen.SetActive(false);

    }
    public void ResetGame()
    {
        PlayerVehicle.GetComponent<CarContoller>().SetCarToStart();
        VehicleControls.SetActive(false);
        ResetButton.SetActive(false);
        StartScreen.SetActive(true);
    }

}
