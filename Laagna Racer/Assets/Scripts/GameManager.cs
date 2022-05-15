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

        int controltype = PlayerPrefs.GetInt("ControlType");
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
        //ResetScore();
        
        

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
        Vector3 position = new Vector3(0f, 0f, 0f);
        Instantiate(SpawnBlock, position, Quaternion.identity);

        //EndScore();
        
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
        //ScoreField.GetComponent<UnityEngine.UI.Text>().text = "High Score: " + hideFlags.ToString();


    }
    /* private void ResetScore()
    {
        currentScore = 0;
        ScoreField.GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();
    }
    private void UpdateScore()
    {
        currentScore += 1;

        //ScoreField.GetComponent<UnityEngine.UI.Text>().text = currentScore.ToString();


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
    }*/
}
