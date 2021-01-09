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
    
    
    void Start()
    {
        inTeleport = new ArrayList();
        beamingTimer = timeToTeleport;
        beaming = false;
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
        if (other.CompareTag("Cow"))
        {
            inTeleport.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cow"))
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
            if (obj.CompareTag("Cow"))
            {
                cowCount++;
            }
            Destroy(obj);
        }
        GameManager.instance.gameState.score += cowCount * pointsPerCow;
        Debug.Log(GameManager.instance.gameState.score);
    }

}
