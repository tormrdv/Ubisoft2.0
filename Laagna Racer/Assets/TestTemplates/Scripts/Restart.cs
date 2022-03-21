using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject PlayerVehicle;
    public GameObject StartObject;
    public GameObject MenuUI;
    public GameObject CarControls;
    public void ResetGame()
    {
        StartObject.SetActive(true);
        PlayerVehicle.GetComponent<CarContoller>().SetCarToStart();
        PlayerVehicle.SetActive(false);
        CarControls.SetActive(false);
        this.gameObject.SetActive(false);
        
    } //Restardi vajutusel viib elemendid sinna kus nad olid ning lülitab kontrollid välja.
}
