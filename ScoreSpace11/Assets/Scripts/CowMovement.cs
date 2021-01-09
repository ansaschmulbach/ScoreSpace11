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
    private Animator cowAnimator;
    [SerializeField] private float movementTimer;
    private Vector3 destination;
    private Vector3[] directions = new[] {Vector3.left, Vector3.right, 
        Vector3.up, Vector3.down};

    void Start()
    {
        movementTimer = Random.Range(moveTimeAvg - 1, moveTimeAvg + 1);
        destination = this.transform.position;
        cowAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        movementTimer -= Time.deltaTime;
        if (movementTimer <= 0 && this.destination == this.transform.position)
        {
            MoveRandom();
            movementTimer = Random.Range(moveTimeAvg - 1, moveTimeAvg + 1);
        }
        else
        {
            MoveDestination();
        }

        Vector3 pos = this.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y, pos.y);
    }

    void MoveRandom()
    {
        float x = Random.Range(-2f, 2f);
        float y = Random.Range(-1f, 1f);
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
        if (cowAnimator)
        {
            cowAnimator.SetFloat("speed", dir.magnitude);
        }
    }
    
}
