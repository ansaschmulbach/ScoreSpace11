using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreBoard : MonoBehaviour
{
    const string publicCode = "5ff7d3190af26924d02fc9c6";
    const string webURL = "http://www.dreamlo.com/lb/";
    private string privateCode = "Test";
    public Highscore[] highscoresList;
    DisplayScores highscoresDisplay;
    void Awake() {
        privateCode = secretCode.secret;
        highscoresDisplay = GetComponent<DisplayScores>();
        //AddNewHighscore("oliver", 200);
        //AddNewHighscore("ansa", 500);
        DownloadHighscores();
    }
    public void AddNewHighscore(string username, int score) {
        StartCoroutine(UploadNewHighscore(username, score));
    }
    IEnumerator UploadNewHighscore(string username, int score) {
        UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.Send();
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
        UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/0/10");
        yield return www.Send();
        if (string.IsNullOrEmpty(www.error)) {
            FormatHighscores(www.downloadHandler.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else {
            print("Download Failed: " + www.error);
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
            print(highscoresList[i].username + " : " + highscoresList[i].score);
        }
    }
    public void returnToMainMenu()
    {
        GameManager.instance.LoadToMain();
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
