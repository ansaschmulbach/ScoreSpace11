using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    private GameState gameState;
    [SerializeField] private TextMeshProUGUI milkText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image dial;
    [SerializeField] private Button lastLevButton;
    [SerializeField] private GameObject pointer;

    [Header("Upgrades")] 
    [SerializeField] 
    private TextMeshProUGUI shieldStat;
    [SerializeField] private TextMeshProUGUI speedStat;
    [SerializeField] private TextMeshProUGUI teleSpeedStat;
    [SerializeField] private TextMeshProUGUI weaponStat;


    private bool lastLevel;
    private FieldManager fm;
    
    void Start()
    {
        gameState = GameManager.instance.gameState;
        fm = FindObjectOfType<FieldManager>();
        lastLevButton.enabled = false;
        lastLevButton.image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText)
        {
            scoreText.SetText(gameState.score.ToString());
        }

        if (milkText)
        {
            milkText.SetText("Milk: " + gameState.money);
        }
        
        shieldStat.text = "X" + gameState.healthMultiplier;
        speedStat.text = "X" + gameState.speedMultiplier;
        teleSpeedStat.text = "X" + gameState.multiplierTeleportSpeed;


    }

    public void RefreshTime(float timeLeft, float maxTime)
    {
        if (lastLevel)
        {
            return;
        }
        float ratioTimeElapsed = timeLeft / maxTime;
        float angle = ratioTimeElapsed * 180 - 90;
        pointer.transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void EnableLastLevel()
    {
        lastLevel = true;
        dial.enabled = false;
        pointer.GetComponentInChildren<Image>().enabled = false;
        lastLevButton.enabled = true;
        lastLevButton.image.enabled = true;
    }

    public void OpenUpgrade()
    {
        this.GetComponent<Canvas>().enabled = false;
        fm.upgradeScreen.OpenUpgradeScreen();
    }

    public void Open()
    {
        this.GetComponent<Canvas>().enabled = true;
    }
    
    
}
