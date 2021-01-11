using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState
{
    // Start is called before the first frame update
    
    public int score = 0;
    public int money = 0;
    public int cow = 0;

    /** Upgrades **/
    /** Teleportation **/
    public float timeToTeleport = 3.8f;
    public float teleportAnimationSpeed = 1f;
    public float multiplierTeleportSpeed = 1f;

    /** Speed **/
    public float baseSpeed = 3.5f;
    public float speedMultiplier = 1f;

    /** Player Health **/
    public float healthMultiplier = 1f;
    
    public bool freezeBeam;

}
