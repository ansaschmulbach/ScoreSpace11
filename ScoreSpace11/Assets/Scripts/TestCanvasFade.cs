using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCanvasFade : MonoBehaviour
{
    public FadeCanvas fadecanvas;
    // Start is called before the first frame update
    void Start()
    {
        print("Test Canvas Fade is for testing use only, make sure you remove it in final versions!");
    }

    // Update is called once per frame
    void Update()
    {
        //Comment this out if you dont want space to toggle all canvases

        if(Input.GetKeyDown("space"))
        {
            fadecanvas.FadePanel();
        }
        
    }
}
