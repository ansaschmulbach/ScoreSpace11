using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class SpaceShipMovement : MonoBehaviour {
    
    private bool colliding;
    private SpaceShipPosession posessionScript;
    private GameState gameState;
    
    void Start()
    {
        posessionScript = GetComponentInChildren<SpaceShipPosession>();
        gameState = GameManager.instance.gameState;
    }

    void Update()
    {
        if (posessionScript && !posessionScript.beaming)
        {
            float xSpeed = Input.GetAxis("Horizontal");
            float ySpeed = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(xSpeed, ySpeed, 0) ;
            float speed = gameState.baseSpeed * gameState.speedMultiplier;
            this.transform.position +=  speed * Time.deltaTime * direction;   
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        colliding = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        colliding = false;
    }
}
