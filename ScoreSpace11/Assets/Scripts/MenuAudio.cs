using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioClip soundAffect;
    public AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.StartBgSound(soundAffect, new Vector3(0, 0, 0));
    }

}
