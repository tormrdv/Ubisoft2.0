using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonSteeringHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{   
    //Sets the steering direction that the Script would be using
    public int steeringDirection;
    public GameObject PlayerCar;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerCar.GetComponent<CarControlImproved>().SetTurningDirection(steeringDirection);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerCar.GetComponent<CarControlImproved>().SetTurningDirection(0);
    }
}
