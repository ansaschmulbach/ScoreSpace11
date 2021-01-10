using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    private GameState gameState;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        gameState = GameManager.instance.gameState;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText)
        {
            
            scoreText.SetText("Score: " + gameState.score);
        }
    }
}
