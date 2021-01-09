using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class SpaceShipMovement : MonoBehaviour
{
    private Rigidbody2D shipRB;
    [SerializeField] private float speed;
    
    void Start()
    {
        shipRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xSpeed, ySpeed, 0) ;
        this.transform.position += direction * speed * Time.deltaTime;
    }
}
