using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    [SerializeField] public float changeSmoothenss;


    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }
    public void OnDrag(PointerEventData data)
    {
        float difference = (data.pressPosition.x - data.position.x);
        //Debug.Log(difference);
        transform.position = panelLocation - new Vector3(difference, 0, 0);
       
    }
    public void OnEndDrag(PointerEventData data)
    {
        float difference = (data.pressPosition.x - data.position.x);
        switch (difference)
        {
            case var expression when difference > 550f:
                SceneManager.LoadScene("UserSettings");
                break;
            case var expression when difference < -550f:
                SceneManager.LoadScene("GameSettings");
                break;
            default:
                transform.position = Vector3.Lerp(data.pressPosition, panelLocation, 1);
                break;
        }

    }
}
