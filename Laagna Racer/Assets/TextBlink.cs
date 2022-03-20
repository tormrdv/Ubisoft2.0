
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBlink : MonoBehaviour
{
    private bool faded = false;
    private bool inProgress = false;
    [SerializeField] private float fadeDelay;
    // can ignore the update, it's just to make the coroutines get called for example

    private void OnEnable()
    {
        StartCoroutine(FadeTextToZeroAlpha(fadeDelay, GetComponent<Text>()));
    }

    private void Update()
    {
        while (!inProgress)
        {
            if (!faded)
            {
                StartCoroutine(FadeTextToFullAlpha(fadeDelay, GetComponent<Text>()));
            }
            else if (faded)
            {
                StartCoroutine(FadeTextToZeroAlpha(fadeDelay, GetComponent<Text>()));
            }
        }
    }



    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {   
        inProgress = true;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        faded = true;
        inProgress = false;
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        inProgress = true;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        faded = false;
        inProgress = false;
    }
}