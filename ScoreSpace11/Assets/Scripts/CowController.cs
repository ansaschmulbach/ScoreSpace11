using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{

    public int damage;
    public int pointValue;
    public bool inTeleport;
    private Animator cowAnimator;
    
    private void Start()
    {
        cowAnimator = GetComponent<Animator>();
    }

    public void Teleport()
    {
        inTeleport = true;
        cowAnimator.SetBool("teleporting", true);
    }

    public void StopTeleport()
    {
        inTeleport = false;
        cowAnimator.SetBool("teleporting", false);
    }

}
