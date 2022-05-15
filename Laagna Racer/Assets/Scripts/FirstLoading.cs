using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstLoading : MonoBehaviour
{
    public GameObject Title;
    [SerializeField] private string sceneName;
    private bool faded = true;
    private bool inProgress = false;
    [SerializeField] private float fadeDelay;
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
        SceneManager.LoadScene(sceneName);
    }
}
   
