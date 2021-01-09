using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceShipPosession : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> inTeleport;
    public bool beaming;
    [SerializeField] private float beamingTimer;
    [SerializeField] private int pointsPerCow;
    private GameState gameState;
    public Health health;

    void Start()
    {
        inTeleport = new List<GameObject>();
        beaming = false;
        gameState = GameManager.instance.gameState;
        beamingTimer = gameState.timeToTeleport * gameState.multiplierTeleportSpeed;
        health = GetComponentInParent<Health>();
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
            beamingTimer = gameState.timeToTeleport * gameState.multiplierTeleportSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.TryGetComponent(out CowController cowController))
        {
            cowController.inTeleport = true;
            inTeleport.Add(other.gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.TryGetComponent(out CowController cowController))
        {
            cowController.inTeleport = false;
            inTeleport.Remove(other.gameObject);
        }
    }

    private void Beam()
    {

        int cowCount = 0;
        int points = 0;
        for (int i = inTeleport.Count - 1; i >= 0; i --) 
        {
            GameObject obj = inTeleport[i];

            if (obj.TryGetComponent(out CowController cowController))
            {
                cowController.Teleport();
                points += cowController.pointValue;
                health.LoseHealth(cowController.damage);
            }

            if (obj.CompareTag("Cow"))
            {
                cowCount++;
            }
            
            Destroy(obj);
        }

        gameState.score += points;

    }

}
