using System.Collections;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    [SerializeField] private int min_time;
    [SerializeField] private int max_time;
    private int counterToChange;
    private int counter;
    [SerializeField] private Color colorDay;
    [SerializeField] private Color colorNight;
    [SerializeField] private float colorDelay;
    Light light;
    private bool IsDay;
    private bool inProgress;



    // Start is called before the first frame update
    void Start()
    {
        newRandomValue();
        //Debug.Log(counter);
        //Debug.Log(counterToChange);
        inProgress = false;
        IsDay = true;
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= counterToChange && !inProgress)
        {
            
            //When Counter is fufilled, new value is chosen.
            newRandomValue();


            if (IsDay)
            {
                StartCoroutine(DaytoNight(colorDelay));
                return;
            }
            else
            {
                StartCoroutine(NightToDay(colorDelay));
                return;
            }
        }

    }


    IEnumerator DaytoNight(float delay)
    {
        inProgress = true;
        while (light.color != colorNight)
        {
            float t = Mathf.PingPong(Time.time, delay) / delay;
            light.color = Color.Lerp(light.color, colorNight, t);   
        }
        
        IsDay = false;
        yield return null;
    }
    IEnumerator NightToDay(float delay)
    {
        inProgress = true;
        while (light.color != colorDay)
        {
            float t = Mathf.PingPong(Time.time, delay) / delay;
            light.color = Color.Lerp(light.color, colorDay, t);
            
        }
        IsDay = true;
        yield return null;
    }
    private void newRandomValue()
    {
        counterToChange = Random.Range(min_time, max_time);
        counter = 0;

    }
    private void CountValueUp()
    {
        counter++;
        Debug.Log(counter);
    }
    private void OnEnable()
    {
        TriggerExit.OnChunkExited += CountValueUp;
    }
    private void OnDisable()
    {
        TriggerExit.OnChunkExited -= CountValueUp;
    }



}
