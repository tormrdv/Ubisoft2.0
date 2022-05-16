using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{   
    private int currentScore;

    private void Start()
    {
        ResetScore();
        CollectScore();
    }

    private void OnEnable()
    {
        GameManager.GameToBeStarted += ResetScore;
        TriggerExit.OnChunkExited += IncreaseScore;
        IsOnRoad.GameOver += CollectScore;
    }
    private void OnDisable()
    {
        GameManager.GameToBeStarted -= ResetScore;
        TriggerExit.OnChunkExited -= IncreaseScore;
        IsOnRoad.GameOver -= CollectScore;
    }

    private void CollectScore()
    {   
        if(currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",currentScore);
        }
        gameObject.GetComponent<Text>().text = string.Format("HighScore {0}", PlayerPrefs.GetInt("HighScore"));
    }
    private void ResetScore()
    {
        currentScore = 0;
        gameObject.GetComponent<Text>().text = currentScore.ToString();
    }
    private void IncreaseScore()
    {
        currentScore++;
        gameObject.GetComponent<Text>().text = currentScore.ToString();
    }
 
}
