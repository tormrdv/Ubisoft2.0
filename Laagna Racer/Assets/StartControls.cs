using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartControls : MonoBehaviour
{
    public GameObject PlayerVehicle;
    public GameObject VehicleControls;
    public GameObject ResetButton;


    // Start is called before the first frame update
    void Start()
    {
        PlayerVehicle.SetActive(false);
        VehicleControls.SetActive(false);
        ResetButton.SetActive(false);
    }
    public void StartGame()
    {
        PlayerVehicle.SetActive(true);
        VehicleControls.SetActive(true);
        ResetButton.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
