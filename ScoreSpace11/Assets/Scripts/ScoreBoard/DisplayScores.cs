using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScores : MonoBehaviour
{
    public TextMeshProUGUI[] highscoreText;
    public TextMeshProUGUI personal_best;
    ScoreBoard highscoreManager;
    // Start is called before the first frame update
    void Start()
    {
        personal_best.text = "Personal Best - " + GameManager.instance.sm.savePB.personal_best.ToString();
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". Fetching...";
        }
        highscoreManager = GetComponent<ScoreBoard>();
        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if(highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }

        }
    }
    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}
