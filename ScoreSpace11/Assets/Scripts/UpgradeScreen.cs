using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    [Header("Purchasing")]
    [SerializeField] private TextMeshProUGUI descriptionTitle;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image descriptionIcon;
    [SerializeField] private Upgrade shield;
    [SerializeField] private Upgrade speed;
    [SerializeField] private Upgrade teleportSpeed;
    [SerializeField] private Upgrade freeze;
    [SerializeField] private Upgrade blank;
    [SerializeField] private TextMeshProUGUI milk;
    [SerializeField] private Button purchaseButton;

    [Header("Current Levels")] 
    [SerializeField]
    private TextMeshProUGUI shieldStatus;
    [SerializeField]
    private TextMeshProUGUI speedStatus;
    [SerializeField]
    private TextMeshProUGUI teleportSpeedStatus;
    [SerializeField]
    private TextMeshProUGUI freezeStatus;

    private Upgrade selected;
    private FieldManager fieldManager;
    private Canvas canvas;
    private Canvas darkness;
    private GameObject player;
    private FadeCanvas fade;

    [Serializable]
    public struct Upgrade
    {
        public string name;
        public Sprite icon;
        public string description;
        public int cost;
        public float maxMult;

        public override bool Equals(object obj)
        {
            return name.Equals(((Upgrade) obj).name);
        }
    }
    
    private GameState gameState;
    void Start()
    {
        gameState = GameManager.instance.gameState;
        fieldManager = FindObjectOfType<FieldManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GetComponent<Canvas>();
        canvas.GetComponent<CanvasGroup>().alpha = 0;
        canvas.enabled = false;
        darkness = GameObject.FindGameObjectWithTag("darkness").GetComponent<Canvas>();
        darkness.enabled = false;
        fade = GetComponent<FadeCanvas>();
    }

    private void SetStatus()
    {
        teleportSpeedStatus.text = "X" + gameState.multiplierTeleportSpeed;
        speedStatus.text = "X" + gameState.speedMultiplier;
        shieldStatus.text = "X" + gameState.healthMultiplier;
        milk.text = gameState.money.ToString();
    }
    
    public void SeeShieldInfo()
    {
        SeeInfo(shield);
    }

    public void SeeSpeedInfo()
    {
        SeeInfo(speed);
    }

    public void SeeTeleportSpeedInfo()
    {
        SeeInfo(teleportSpeed);
    }

    public void SeeFreezeInfo()
    {
        SeeInfo(freeze);
    }

    void SeeInfo(Upgrade upgrade)
    {
        descriptionTitle.SetText(upgrade.name);
        descriptionIcon.sprite = upgrade.icon;
        descriptionText.SetText(upgrade.description);
        selected = upgrade;
        CheckDisable();
    }

    void CheckDisable()
    {
        
        
        if (GetCurrMult() > selected.maxMult)
        {
            purchaseButton.image.color = Color.gray;
            purchaseButton.interactable = false;
            descriptionText.text = "Max Multiplier reached!";
        }
        else if (selected.cost > gameState.money)
        {
            purchaseButton.image.color = Color.gray;
            purchaseButton.interactable = false;
            descriptionText.text = "Not enough milk!";
        } 
        else
        {
            purchaseButton.image.color = Color.white;
            purchaseButton.interactable = true;
        }
    }

    public void Purchase()
    {
            
        if (selected.Equals(shield))
        {
            gameState.healthMultiplier =
                ApplyMultiplier(gameState.healthMultiplier);
            Health health = player.GetComponent<Health>();
            health.Multiply(gameState.healthMultiplier);
        } 
        else if (selected.Equals(teleportSpeed))
        {
            gameState.multiplierTeleportSpeed = 
                ApplyMultiplier(gameState.multiplierTeleportSpeed);
        } 
        else if (selected.Equals(speed))
        {
            gameState.speedMultiplier = 
                ApplyMultiplier(gameState.speedMultiplier);
        }

        gameState.money -= selected.cost;
        SetStatus();
        CheckDisable();
    }

    float GetCurrMult()
    {
        if (selected.Equals(shield))
        {
            return gameState.healthMultiplier;
        } 
        else if (selected.Equals(teleportSpeed))
        {
            return gameState.multiplierTeleportSpeed;
        } 
        else if (selected.Equals(speed))
        {
            return gameState.speedMultiplier;
        }

        return 0.0f;
        
    }

    float ApplyMultiplier(float oldMult)
    {
        float newMult = oldMult * 1.5f;
        return ((int) (newMult * 100)) / 100f;
    }

    public void Quit()
    {
        darkness.enabled = false;
        if (fade)
        {
            fade.FadePanel();   
        }
        else
        {
            canvas.enabled = false;
        }
        fieldManager.NextLevel();
    }

    public void OpenUpgradeScreen()
    {
        darkness.enabled = true;
        canvas.enabled = true;
        if (fade)
        {
            fade.FadePanel();  
        }
        
        SetStatus();
        SeeInfo(blank);
    }
    
}
