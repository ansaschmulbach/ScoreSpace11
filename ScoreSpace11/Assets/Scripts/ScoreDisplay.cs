using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    private GameState gameState;
    [SerializeField] private TextMeshProUGUI milkText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject pointer;

    [Header("Upgrades")] 
    [SerializeField] 
    private TextMeshProUGUI shieldStat;
    [SerializeField] private TextMeshProUGUI speedStat;
    [SerializeField] private TextMeshProUGUI teleSpeedStat;
    [SerializeField] private TextMeshProUGUI weaponStat;

    void Start()
    {
        gameState = GameManager.instance.gameState;
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
        float ratioTimeElapsed = timeLeft / maxTime;
        float angle = ratioTimeElapsed * 180 - 90;
        pointer.transform.eulerAngles = new Vector3(0, 0, angle);
    }
    
}
