using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{
    public bool isFaded = true;
    public float timeOfFade = 0.6f;
    // Start is called before the first frame update
    
    /***
     * README: 
     * You must attach a CanvasGroup component to any canvas you want to fade with this script
     * then simply call FadePanel once to fade in, and then again to fade out. 
     * If it starts in the wrong config, change isFaded to the opposite bool
    ***/
    public void FadePanel()
    {
        var canv = this.gameObject.GetComponent<CanvasGroup>();
        StartCoroutine(exeFade(canv, canv.alpha, isFaded ? 1 : 0));
        isFaded = !isFaded;

    }
    public IEnumerator exeFade(CanvasGroup canv, float start, float end)
    {
        float counter = 0f;
        while(counter < timeOfFade)
        {
            counter += Time.deltaTime;
            canv.alpha = Mathf.Lerp(start, end, counter / timeOfFade);
            yield return null;
        }
        enabled = !isFaded;
        Debug.Log(enabled);
    }
}
