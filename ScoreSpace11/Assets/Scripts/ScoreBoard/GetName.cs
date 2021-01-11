using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class GetName : MonoBehaviour
{
    public ScoreBoard board;
    public TMP_InputField iField;
    [SerializeField] private TextMeshProUGUI scoreText;
    private string myName;

    void Start()
    {
        scoreText.SetText("Score: " + GameManager.instance.gameState.score);
    }
    
    public void storeString()
    {
       iField.text = Regex.Replace(iField.text, "[^\\w\\._]", "");
        myName = iField.text;
    }

    // Update is called once per frame
    void Update()
    {
        this.storeString();
    }

    public void uploadScores()
    {
        board.AddNewHighscore(this.myName, GameManager.instance.gameState.score);
        GameManager.instance.LoadToLeaderboard();
    }
}
