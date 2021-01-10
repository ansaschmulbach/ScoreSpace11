using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{

    //[SerializeField] private float nightLength;
    [SerializeField] private float nightTimer;
    [SerializeField] private int levelNum;
    private LevelGenerator.Level level;
    [SerializeField] private Canvas scoreUI;
    private UpgradeScreen upgradeScreen;
    private LevelGenerator levelGenerator;
    private ScoreDisplay scoreDisplay;
    private LastLevelManager lastLevelManager;
    private bool inNight;

    void Start()
    {
        levelNum = 0;
        inNight = true;
        upgradeScreen = FindObjectOfType<UpgradeScreen>();
        levelGenerator = FindObjectOfType<LevelGenerator>();
        scoreDisplay = scoreUI.GetComponent<ScoreDisplay>();
        lastLevelManager = GetComponent<LastLevelManager>();
        lastLevelManager.enabled = false;
        StartLevel();
    }
    
    void Update()
    {

        nightTimer -= Time.deltaTime;   
        if (inNight && nightTimer <= 0)
        {
            inNight = false;
            LaunchUpdatesScreen();
        } 
        else if (inNight)
        {
            scoreDisplay.RefreshTime(nightTimer, level.levelLength);
        }
    }
    
    
    void StartLevel()
    {
        inNight = true;
        level = levelGenerator.levels[levelNum];
        scoreUI.enabled = true;
        nightTimer = level.levelLength;
        for (int i = 0; i < level.cowCounts.Length; i++)
        {
            levelGenerator.Generate(levelGenerator.cowPrototypes[i], level.cowCounts[i]);
        }

        if (this.levelNum == levelGenerator.levels.Length - 2)
        {
            BarnController barnController = FindObjectOfType<BarnController>();
            barnController.MissileBarnState();
        } 
        else if (this.levelNum == levelGenerator.levels.Length - 1)
        {
            lastLevelManager.enabled = true;
        }
    }

    public void NextLevel()
    {
        levelNum++;
        levelGenerator.Clear();
        StartLevel();
    }
    
    void LaunchUpdatesScreen()
    {
        scoreUI.enabled = false;
        upgradeScreen.OpenUpgradeScreen();
    }
    
}
