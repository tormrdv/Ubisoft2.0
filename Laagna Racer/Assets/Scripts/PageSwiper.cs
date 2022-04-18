using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float swipeDistance;
    //
    public string rightScene;
    public string leftScene;


    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }
    public void OnDrag(PointerEventData data)
    {
        float difference = (data.pressPosition.x - data.position.x);
        transform.position = panelLocation - new Vector3(difference, 0, 0);
        Debug.Log(difference);
       
    }
    public void OnEndDrag(PointerEventData data)
    {
        float difference = (data.pressPosition.x - data.position.x);
        switch (difference)
        {
            case var expression when (difference > swipeDistance) && !string.IsNullOrEmpty(rightScene):
                SceneManager.LoadScene(rightScene);
                Debug.Log("loaded Right");
                break;
            //Checks for difference, AND whether scene name string is defined
            case var expression when (difference < (-1*swipeDistance)) && !string.IsNullOrEmpty(leftScene):
                SceneManager.LoadScene(leftScene);
                Debug.Log("loaded Left");
                break;
            default:
                transform.position = panelLocation;
                break;
        }

    }
}
