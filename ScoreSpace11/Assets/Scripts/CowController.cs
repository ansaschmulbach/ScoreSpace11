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
    private GameState gameState;

    private void Start()
    {
        cowAnimator = GetComponent<Animator>();
        gameState = GameManager.instance.gameState;
    }

    public void Teleport()
    {
        inTeleport = true;
        cowAnimator.SetBool("teleporting", true);
        cowAnimator.speed = gameState.teleportAnimationSpeed * 
                            gameState.multiplierTeleportSpeed;
    }

    public void StopTeleport()
    {
        inTeleport = false;
        cowAnimator.SetBool("teleporting", false);
    }

}
