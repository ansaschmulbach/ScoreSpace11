using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{
    private bool isFaded = false;
    public float timeOfFade = 0.6f;
    // Start is called before the first frame update
    void Update()
    {
        /**
        if(Input.GetKeyDown("space"))
        {
            FadePanel();
        }
        **/
    }
    public void FadePanel()
    {
        var canv = GetComponent<CanvasGroup>();
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
    }
}
