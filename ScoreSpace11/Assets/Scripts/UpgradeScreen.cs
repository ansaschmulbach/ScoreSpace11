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

    [Serializable]
    public struct Upgrade
    {
        public string name;
        public Sprite icon;
        public string description;
        public int cost;
    }
    
    private GameState gameState;
    void Start()
    {
        gameState = GameManager.instance.gameState;
        fieldManager = FindObjectOfType<FieldManager>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    private void SetStatus()
    {
        teleportSpeedStatus.text = "X" + gameState.multiplierTeleportSpeed;
        speedStatus.text = "X" + gameState.speedMultiplier;
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
    }

    public void Purchase()
    {
        if (selected.Equals(freeze))
        {
            gameState.freezeBeam = true;
        } 
        else if (selected.Equals(teleportSpeed))
        {
            float newSpeed = gameState.multiplierTeleportSpeed * 1.5f;
            gameState.multiplierTeleportSpeed = ((int)(newSpeed * 100))/ 100f;
        } 
        else if (selected.Equals(speed))
        {
            float newSpeed = gameState.speedMultiplier * 1.5f;
            gameState.speedMultiplier = ((int)(newSpeed * 100))/ 100f;
        }
        gameState.money -= selected.cost;
        SetStatus();
    }

    public void Quit()
    {
        canvas.enabled = false;
        fieldManager.NextLevel();
    }

    public void OpenUpgradeScreen()
    {
        canvas.enabled = true;
        SetStatus();
        SeeInfo(blank);
    }
    
}
