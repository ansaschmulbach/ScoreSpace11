using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTestScript : MonoBehaviour
{
    public AudioClip soundAffect;
    public AudioManager manager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            print("P KEYPRESS REGISTERED");
            manager.StartBgSound(soundAffect, new Vector3(0, 0, 0));
        }
        else if (Input.GetKeyDown("space")) 
        {
            print("KEYPRESS REGISTERED");
            manager.PauseBgSound();
        }
        else if (Input.GetKeyDown("o"))
        {
            print("KEYPRESS REGISTERED");
            manager.ResumeBgSound();
        }
    }
}
