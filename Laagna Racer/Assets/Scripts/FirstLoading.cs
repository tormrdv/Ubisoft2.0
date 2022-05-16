using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstLoading : MonoBehaviour
{
    public GameObject Title;
    [SerializeField] private string sceneName;
    float counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Checks if local Preference values have been set.
        if (!PlayerPrefs.HasKey("ControlType"))
        {
            PlayerPrefs.SetInt("ControlType", 0);
            Debug.Log("Controls missing, setting to default 0");
        }
        if (!PlayerPrefs.HasKey("VehicleColor"))
        {
            PlayerPrefs.SetString("VehicleColor", "FFFFFF");
        }
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }
    private void Update()
    {

        if (counter < 3)
        {
            counter += counter*Time.deltaTime;  
        }
        else
        {
            SceneManager.LoadScene(sceneName);

        }
       
        
    }
}
   
