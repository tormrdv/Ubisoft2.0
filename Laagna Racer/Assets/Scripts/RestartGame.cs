using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public static event System.Action GameToBeReset;

    public void ButtonPressed()
    {
        GameToBeReset();
    }
}
