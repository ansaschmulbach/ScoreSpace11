using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using Random = UnityEngine.Random;

public class CowMovement : MonoBehaviour
{

    [SerializeField] private float moveTimeAvg = 3;
    [SerializeField] private float speed = 5;
    private float movementTimer;
    private Vector3 destination;
    private Vector3[] directions = new[] {Vector3.left, Vector3.right, 
        Vector3.up, Vector3.down};

    void Start()
    {
        movementTimer = Random.Range(moveTimeAvg - 1, moveTimeAvg + 1);
    }

    
    void Update()
    {
        movementTimer -= Time.deltaTime;
        if (movementTimer <= 0 && this.destination == this.transform.position)
        {
            MoveRandom();
        }
        else
        {
            MoveDestination();
        }
    }

    void MoveRandom()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(x, y);
        destination = this.transform.position + direction;
        Debug.Log(direction);
    }

    void MoveDestination()
    {
        this.transform.position += (destination - this.transform.position) * this.speed * Time.deltaTime;
    }
    
}
