using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioClip soundAffectMenu;
    public AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        print("Menu Audio is Deprecated, Functionality is now included in audio manager");
        manager.StartMenuSound();
    }

}
