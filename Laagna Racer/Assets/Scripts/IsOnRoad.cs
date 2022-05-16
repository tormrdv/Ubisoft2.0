using UnityEngine;

public class IsOnRoad : MonoBehaviour
{
    public delegate void GameOverDelegate();
    public static event GameOverDelegate GameOver;

    private float timer;
    public float endTimer;

    //Here to calculate Velocity
    private Vector3 previous;
    private float velocity;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Road" && velocity > 0.3f)
        {
            timer = 0f;
            Debug.Log("Everythign is good");
        }
        else
        {
            //Debug.Log("NOT ON ROAD");
            if(timer > endTimer)
            {
                DoThis();
                timer = 0f;
            }
            else
            {
                timer = timer + (1* Time.deltaTime);
            }
        }
    }

    private void DoThis()
    {
        GameOver();
    }
    private void OnEnable()
    {
        RestartGame.GameToBeReset += DoThis;
    }
    private void OnDisable()
    {
        RestartGame.GameToBeReset -= DoThis;
    }
    private void Update()
    {
        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;

        
    }
}
