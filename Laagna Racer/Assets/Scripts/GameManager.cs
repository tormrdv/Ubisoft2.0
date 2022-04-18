using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public GameObject PlayerVehicle;
    public GameObject levelGen;
    public GameObject VehicleControls;
    public GameObject ResetButton;
    public GameObject StartScreen;
    public GameObject SpawnBlock;
    public GameObject ScoreField;

    private int highScore;
    private int currentScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        CheckForHS();
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
        levelGen.GetComponent<LevelLayoutGenerator>().ResetOrigin();
        levelGen.GetComponent<LevelLayoutGenerator>().Setup();
        ResetScore();
        
        

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
        
        RemoveLevel();
        Vector3 position = new Vector3(5.02502441f, 19.0245361f, 3.90490723f);
        Instantiate(SpawnBlock, position, Quaternion.identity);

        EndScore();
        
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
    private void CheckForHS()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        highScore = PlayerPrefs.GetInt("HighScore");
        ScoreField.GetComponent<UnityEngine.UI.Text>().text = "High Score: " + hideFlags.ToString();


    }
    private void ResetScore()
    {
        currentScore = 0;
        ScoreField.GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();
    }
    private void UpdateScore()
    {
        currentScore += 1;
        ScoreField.GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();


    }
    private void EndScore()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore",highScore);
            Debug.Log("New Highscore Achieved");
        }
        ScoreField.GetComponent<UnityEngine.UI.Text>().text = "High Score: " + highScore.ToString();
        
    }
    private void OnEnable()
    {
        TriggerExit.OnChunkExited += UpdateScore;
    }
}
