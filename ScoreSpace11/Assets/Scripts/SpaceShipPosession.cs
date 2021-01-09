using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceShipPosession : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float timeToTeleport;
    private ArrayList inTeleport;
    public bool beaming;
    private float beamingTimer;
    [SerializeField] private int pointsPerCow;
    private GameState gameState;
    public Health health;

    void Start()
    {
        inTeleport = new ArrayList();
        beamingTimer = timeToTeleport;
        beaming = false;
        if (GameManager.instance)
        {
            gameState = GameManager.instance.gameState;
        }
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beaming && beamingTimer <= 0)
        {
            Beam();
            beaming = false;
        } 
        else if (beaming) 
        {
            beamingTimer -= Time.deltaTime;
        } 
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            beaming = true;
            beamingTimer = timeToTeleport;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cow") || other.CompareTag("Bomb Cow"))
        {
            inTeleport.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cow") || other.CompareTag("Bomb Cow"))
        {
            inTeleport.Remove(other.gameObject);
        }
    }

    private void Beam()
    {

        int cowCount = 0;
        for (int i = inTeleport.Count - 1; i >= 0; i --) 
        {
            GameObject obj = (GameObject) inTeleport[i];

            if (obj.TryGetComponent(out CowController cowController))
            {
                cowController.Teleport();
            }

            if (obj.CompareTag("Cow"))
            {
                cowCount++;
            } 
            else if (obj.CompareTag("Bomb Cow"))
            {
                if (health)
                {
                    health.LoseHealth(1);
                }
            }

            Destroy(obj);
        }

        if (gameState != null)
        {
            gameState.score += cowCount * pointsPerCow;
        }
        
    }

}
