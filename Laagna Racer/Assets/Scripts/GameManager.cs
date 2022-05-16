using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public static event Action GameToBeStarted;

    public GameObject PlayerVehicle;
    public GameObject levelGen;
    public GameObject VehicleControls;
    public GameObject ResetButton;
    public GameObject StartScreen;
    public GameObject SpawnBlock;



    // Start is called before the first frame update
    void Start()
    {
        ResetGame();    
    }
    private int ControlCheckup()
    {
        int controltype = PlayerPrefs.GetInt("ControlType");
        Debug.Log("ControlSet to " + controltype);
        PlayerVehicle.GetComponent<CarControlImproved>().SetControlType(controltype);
        return controltype;
        

    }
    public void StartGame()
    {
    
        PlayerVehicle.SetActive(true);
        ResetButton.SetActive(true);
        StartScreen.SetActive(false);

        GameToBeStarted();
        
        

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
        PlayerVehicle.GetComponent<CarControlImproved>().SetCarToStart();
        VehicleControls.SetActive(false);
        ResetButton.SetActive(false);
        StartScreen.SetActive(true);
        
        
        RemoveLevel();
        Vector3 position = new Vector3(0f, 0f, 0f);
        levelGen.GetComponent<LevelLayoutGenerator>().ResetOrigin();
        levelGen.GetComponent<LevelLayoutGenerator>().Setup();
        Instantiate(SpawnBlock, position, Quaternion.identity);


    }
    private void RemoveLevel()
    {
        for (int z = 0; z < SceneManager.sceneCount; z++)
        {
            foreach (GameObject g in SceneManager.GetSceneAt(z).GetRootGameObjects())
            {
                if(g.tag == "TrackPiece")
                {
                    Destroy(g);
                }
            }
        }
    }

    private void OnEnable()
    {
        IsOnRoad.GameOver += ResetGame;
    }
    private void OnDisable()
    {
        IsOnRoad.GameOver -= ResetGame;
    }



}   

