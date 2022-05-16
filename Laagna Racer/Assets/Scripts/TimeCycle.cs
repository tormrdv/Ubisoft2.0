using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    [SerializeField] private float min_time;
    [SerializeField] private float max_time;
    [SerializeField] private Color colorDay;
    [SerializeField] private Color colorNight;
    [SerializeField] private float colorDelay;
    Light light;
    private bool IsDay;
    private bool inProgress;
    
    

    // Start is called before the first frame update
    void Start()
    {
        inProgress = false;
        
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        while (!inProgress)
        {
            inProgress = true;
            if (IsDay)
            {
                light.color = Color.Lerp(colorDay, colorNight, colorDelay);
                StartCoroutine(WaitBeforeChanging(Random.Range(min_time, max_time)));
                IsDay = false;
            }
            else
            {    
                light.color = Color.Lerp(colorNight, colorDay, colorDelay);
                StartCoroutine(WaitBeforeChanging(Random.Range(min_time, max_time)));
                IsDay = true;
            }
            inProgress=false;
        }
    }

    IEnumerator WaitBeforeChanging(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
   
}
