using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SpaceShipPosession : MonoBehaviour
{
    
    [SerializeField] private float beamingTimer;
    [SerializeField] private int pointsPerCow;
    [SerializeField] public Image teleportFill;
    
    private GameState gameState;
    public Health health;
    public TextMeshProUGUI bonusPtsTxt;
    public FadeCanvas pointsBox;
    private AudioManager manager;
    private FieldManager fm;
    
    public List<GameObject> inTeleport;
    public bool beaming;
    public bool previousSpace;

    void Start()
    {
        inTeleport = new List<GameObject>();
        teleportFill.fillAmount = 0;
        previousSpace = false;
        beaming = false;
        gameState = GameManager.instance.gameState;
        beamingTimer = gameState.timeToTeleport * gameState.multiplierTeleportSpeed;
        
        health = GetComponentInParent<Health>();
        pointsBox = (FadeCanvas) GameObject.Find("bonusPointBox").GetComponent<FadeCanvas>();
        bonusPtsTxt = GameObject.Find("bonusPointBox").GetComponent<TextMeshProUGUI>();
        manager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        fm = FindObjectOfType<FieldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && previousSpace)
        {
            previousSpace = false;
            CancelBeam();
        }
        else if (beaming && beamingTimer <= 0)
        {
            Beam();
            beaming = false;
        } 
        else if (beaming) 
        {
            beamingTimer -= Time.deltaTime;
            UpdateTeleportFill();
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && !previousSpace)
        {
            previousSpace = true;
            StartBeam();
        }
    }
    public void CancelBeam()
    {
        beaming = false;
        teleportFill.fillAmount = 0;
        for (int i = inTeleport.Count - 1; i >= 0; i--)
        {
            GameObject obj = inTeleport[i];

            if (obj.TryGetComponent(out CowController cowController))
            {
                cowController.StopTeleport();
                //inTeleport.Remove(obj);

            }
        }

    }

    public void StartBeam()
    {
        beaming = true;
        beamingTimer = gameState.timeToTeleport / gameState.multiplierTeleportSpeed;
        UpdateTeleportFill();
        manager.StartBeamSound();
        foreach (GameObject obj in inTeleport)
        {
            if (obj.TryGetComponent(out CowController cowController))
            {
                cowController.Teleport();
            }
        }
    }

    void UpdateTeleportFill()
    {
        float timeLeft = beamingTimer / (gameState.timeToTeleport / gameState.multiplierTeleportSpeed);
        teleportFill.fillAmount = 1 - timeLeft;
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

            if (obj.TryGetComponent(out CowController cowController) && beaming)
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
        gameState.cow += cowCount;
        fm.cowsThisLevel += cowCount;
        health.LoseHealth(damage);

    }
    public IEnumerator DisplayBonusPoints(int pts)
    {
        pointsBox.FadePanel();
        bonusPtsTxt.text = "+ " + pts + " Combo Bonus!";
        yield return new WaitForSeconds(1);
        pointsBox.FadePanel();
        yield return null;
    }
    
}
