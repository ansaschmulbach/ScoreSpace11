﻿using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.UIElements;
#endif
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using Random = UnityEngine.Random;

public class CowMovement : MonoBehaviour
{

    [SerializeField] private float moveTimeAvg = 3;
    [SerializeField] private float speed = 5;
    private Animator cowAnimator;
    private CowController cowController;
    [SerializeField] private float movementTimer;
    private Vector3 destination;
    private Vector3[] directions = new[] {Vector3.left, Vector3.right, 
        Vector3.up, Vector3.down};

    private GameState gameState;

    void Start()
    {
        UpdateZ();
        gameState = GameManager.instance.gameState;
        movementTimer = Random.Range(moveTimeAvg - 1, moveTimeAvg + 1);
        destination = this.transform.position;
        cowAnimator = GetComponent<Animator>();
        cowController = GetComponent<CowController>();
    }

    
    void Update()
    {
        movementTimer -= Time.deltaTime;
        if (!(gameState.freezeBeam && cowController.inTeleport))
        {
            Move();
        }
    }

    void Move()
    {
        if (movementTimer <= 0 && this.destination == this.transform.position)
        {
            MoveRandom();
            movementTimer = Random.Range(moveTimeAvg - 1, moveTimeAvg + 1);
        }
        else
        {
            MoveDestination();
        }
        
        UpdateZ();
    }
    
    void UpdateZ()
    {
        Vector3 pos = this.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y, pos.y);
    }

    void MoveRandom()
    {
        float xLow = -2f;
        float xHigh = 2f;
        float yLow = -1f;
        float yHigh = 1f;

        Vector3 pos = transform.position;
        if(pos.x <= Globals.leftBound + 2.5)
        {
            xLow = 0f;
        }
        if (pos.x >= Globals.rightBound - 2.5)
        {
            xHigh = 0f;
        }
        if (pos.y <= Globals.lowerBound + 1.5)
        {
            yLow = 0f;
        }
        if (pos.y >= Globals.lowerBound - 1.5)
        {
            yHigh = 0f;
        }

        float x = Random.Range(xLow, xHigh);
        float y = Random.Range(yLow, yHigh);
        Vector3 direction = new Vector3(x, y, y);
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1);
        }
        destination = this.transform.position + direction;
        
        SetCowAnimator(direction);
    }

    void MoveDestination()
    {
        Vector3 movement = (destination - this.transform.position) * this.speed * Time.deltaTime;
        this.transform.position += movement;
        SetCowAnimator(movement);
    }

    void SetCowAnimator(Vector3 dir)
    {
        if (cowAnimator && cowAnimator.parameterCount > 1)
        {
            cowAnimator.SetFloat("speed", dir.magnitude);
        }
    }
    
}
