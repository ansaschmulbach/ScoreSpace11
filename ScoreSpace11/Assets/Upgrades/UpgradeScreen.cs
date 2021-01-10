using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionTitle;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image descriptionIcon;
    [SerializeField] private Upgrade shield;
    [SerializeField] private Upgrade speed;
    [SerializeField] private Upgrade teleportSpeed;
    [SerializeField] private Upgrade freeze;
    [SerializeField] private Upgrade blank;

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
        if (selected.name == "Freeze")
        {
            gameState.freezeBeam = true;
        }
        gameState.money -= selected.cost;
    }

    public void Quit()
    {
        canvas.enabled = false;
        fieldManager.NextLevel();
    }

    public void OpenUpgradeScreen()
    {
        canvas.enabled = true;
        SeeInfo(blank);
    }
    
}
