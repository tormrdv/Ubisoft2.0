using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SettingsToGame : MonoBehaviour, IDragHandler, IEndDragHandler
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
        Debug.Log(difference);
        transform.position = panelLocation - new Vector3(difference, 0, 0);

    }
    public void OnEndDrag(PointerEventData data)
    {
        if (data.pressPosition.x - data.position.x > 550)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            transform.position = Vector3.Lerp(data.pressPosition, panelLocation, 1);
        }
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
