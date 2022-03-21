using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorPicker : MonoBehaviour
{
    public TextMeshProUGUI DebugText;

    RectTransform Rect;
    Texture2D ColorTexture;

    void Start()
    {
        Rect = GetComponent<RectTransform>();   

        ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
    }

    void Update()
    {
        Vector2 delta; //Pretty much leiab Hiire asukoha (no clue kuidas töötab Telos)
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect,Input.mousePosition,null, out delta);

        string debug = "Pointerposition = " + Input.mousePosition;
        debug += "<br>delta = " + delta;

        //Color Pickeri suuruse leidmine

        float width = Rect.rect.width;
        float height = Rect.rect.height;

        delta += new Vector2 (width * .5f, height * .5f);
        debug += "<br>offset delta =" + delta;

        //Tõmbab ColorWheele suuruse ning seadistab min-max 0-1 vahel
        float x = Mathf.Clamp(delta.x / width, 0f, 1);
        float y = Mathf.Clamp(delta.y / width, 0f, 1);
        debug += "<br> x = " + x + "y =" + y;

        int texX = Mathf.RoundToInt(x * ColorTexture.width);
        int texY = Mathf.RoundToInt(y * ColorTexture.height);
        debug += "<br> x = " + texX + "y =" + texY;

        Color color = ColorTexture.GetPixel(texX, texY);
        PlayerPrefs.SetString("VehicleColor", color.ToString());

        DebugText.color = color;
        DebugText.text = debug;


    }
}
