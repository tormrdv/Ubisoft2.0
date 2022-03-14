using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool gamePaused = true;

    public GameObject pauseMenuUI;
    public GameObject PlayButton;
    public GameObject PauseButton;

    public void Awake(){
        gamePaused = true;
        Time.timeScale=0f;
        PlayButton.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused){
                Resume();
            } else {
                Pause();
            }
        }
    }
    /*void Update2()
    {
      if (Input.GetKeyDown("space"))
            {
                Debug.Log("space key was pressed");
                GO.SetActive(true);
                activateGO = false;
            }
    }*/

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        PauseButton.SetActive(false);
    }

    public void RestartGame(){
        Debug.Log("restarting game");
        SceneManager.LoadScene(0); // loads current scene
        Time.timeScale = 1f;
        gamePaused = false;
    }
    
}
