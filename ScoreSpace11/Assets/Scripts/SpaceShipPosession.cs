using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SpaceShipPosession : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> inTeleport;
    public bool beaming;
    [SerializeField] private float beamingTimer;
    [SerializeField] private int pointsPerCow;
    private GameState gameState;
    public Health health;
    public TextMeshProUGUI bonusPtsTxt;
    public FadeCanvas pointsBox;
    private AudioManager manager;

    void Start()
    {
        inTeleport = new List<GameObject>();
        beaming = false;
        gameState = GameManager.instance.gameState;
        beamingTimer = gameState.timeToTeleport * gameState.multiplierTeleportSpeed;
        health = GetComponentInParent<Health>();
        pointsBox = (FadeCanvas) GameObject.Find("bonusPointBox").GetComponent<FadeCanvas>();
        bonusPtsTxt = GameObject.Find("bonusPointBox").GetComponent<TextMeshProUGUI>();
        manager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
            StartBeam();
        }
    }

    void StartBeam()
    {
        beaming = true;
        beamingTimer = gameState.timeToTeleport / gameState.multiplierTeleportSpeed;
        manager.StartBeamSound();
        foreach (GameObject obj in inTeleport)
        {
            if (obj.TryGetComponent(out CowController cowController))
            {
                cowController.Teleport();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.TryGetComponent(out CowController cowController))
        {

            if (beaming)
            {
                cowController.Teleport();   
            }
            
            inTeleport.Add(other.gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.TryGetComponent(out CowController cowController))
        {
            cowController.StopTeleport();
            inTeleport.Remove(other.gameObject);
        }
    }

    private void Beam()
    {

        int cowCount = 0;
        int points = 0;
        int milkEarned = 0;
        int damage = 0;
        for (int i = inTeleport.Count - 1; i >= 0; i --) 
        {
            GameObject obj = inTeleport[i];

            if (obj.TryGetComponent(out CowController cowController))
            {
                cowController.Teleport();
                points += cowController.pointValue;
                milkEarned += cowController.milkValue;
                damage += cowController.damage;
                
                if (cowController.regularCow)
                {
                    cowCount++;
                }
                
            }

            Destroy(obj);
        }

        if(cowCount > 1)
        {
            int bonus = (int)Math.Pow(cowCount, 2) * 3;
            StartCoroutine(DisplayBonusPoints(bonus));
            gameState.score += bonus;
        }
        gameState.score += points;
        gameState.money += milkEarned;
        health.LoseHealth(damage);

    }
    public IEnumerator DisplayBonusPoints(int pts)
    {
        pointsBox.FadePanel();
        bonusPtsTxt.text = "+ " + pts + " pts";
        yield return new WaitForSeconds(1);
        pointsBox.FadePanel();
        yield return null;
    }
    
}
