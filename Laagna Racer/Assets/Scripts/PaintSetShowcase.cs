using UnityEngine;

public class PaintSetShowcase : MonoBehaviour
{

    private Color newCol;


    void Start()
    {


        var cubeRenderer = gameObject.GetComponent<Renderer>();
        //Debug.Log(PlayerPrefs.GetString("VehicleColor"));
        string colorCode = ("#" + PlayerPrefs.GetString("VehicleColor"));
        if (ColorUtility.TryParseHtmlString(colorCode, out newCol))
        {
            cubeRenderer.material.SetColor("_Color", newCol);
        }
        else
        {
            //Debug.Log("Coloring Failed for sum reason idk");
        }

    }

    public void UpdateColor(Color color)
    {
        var cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", color);
    }

}
