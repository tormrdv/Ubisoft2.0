using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testSwipe : MonoBehaviour
{
    public GameObject settingsUI;
    public GameObject pauseMenuUI;

    public void settings(){
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void back(){
        pauseMenuUI.SetActive(true);
        settingsUI.SetActive(false);
    }
}