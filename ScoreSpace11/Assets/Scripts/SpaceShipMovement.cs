using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class SpaceShipMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool colliding;
    private SpaceShipPosession posessionScript;

    void Start()
    {
        posessionScript = GetComponentInChildren<SpaceShipPosession>();
    }

    void Update()
    {
        if (posessionScript && !posessionScript.beaming)
        {
            float xSpeed = Input.GetAxis("Horizontal");
            float ySpeed = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(xSpeed, ySpeed, 0) ;
            this.transform.position += direction * speed * Time.deltaTime;   
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
