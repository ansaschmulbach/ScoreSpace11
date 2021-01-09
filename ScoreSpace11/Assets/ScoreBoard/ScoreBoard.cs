using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    const string publicCode = "5ff7d3190af26924d02fc9c6";
    const string webURL = "http://dreamlo.com/lb/";
    private string privateCode = "Test";
    public Highscore[] highscoresList;
    DisplayScores highscoresDisplay;
    void Awake() {
        privateCode = secretCode.secret;
        highscoresDisplay = GetComponent<DisplayScores>();
        //AddNewHighscore("oliver", 200);
        //AddNewHighscore("ansa", 500);
        //DownloadHighscores();
    }
    public void AddNewHighscore(string username, int score) {
        StartCoroutine(UploadNewHighscore(username, score));
    }
    IEnumerator UploadNewHighscore(string username, int score) {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;
        if (string.IsNullOrEmpty(www.error)) {
            print("Upload Successful!");
        } else {
            print("Upload Failed: " + www.error);
        }
    }
    public void DownloadHighscores() {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }
    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error)) {
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else {
            print("Upload Failed: " + www.error);
        }
    }
    void FormatHighscores(string textInput) {
        string[] entries = textInput.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for(int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(username + " : " + score);
        }
    }
}
public struct Highscore
{
    public string username;
    public int score;
    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }

}
