using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    public void TeleportPressed()
    {
        Debug.Log(player);
        player.GetComponentInChildren<SpaceShipPosession>().StartBeam();
    }

    public void TeleportUnPressed()
    {
        Debug.Log("hi2");
        player.GetComponentInChildren<SpaceShipPosession>().CancelBeam();
    }
}
