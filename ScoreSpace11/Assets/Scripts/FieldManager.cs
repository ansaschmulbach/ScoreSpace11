using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{

    //[SerializeField] private float nightLength;
    private float nightTimer;
    private int levelNum;
    private LevelGenerator.Level level;
    [SerializeField] private Canvas scoreUI;
    private UpgradeScreen upgradeScreen;
    private LevelGenerator levelGenerator;

    void Start()
    {
        levelNum = 0;
        upgradeScreen = FindObjectOfType<UpgradeScreen>();
        levelGenerator = FindObjectOfType<LevelGenerator>();
        StartLevel();
    }
    
    void Update()
    {
        nightTimer -= Time.deltaTime;
        if (nightTimer <= 0)
        {
            LaunchUpdatesScreen();
        }
    }

    void StartLevel()
    {
        level = levelGenerator.levels[levelNum];
        scoreUI.enabled = true;
        nightTimer = level.levelLength;
        for (int i = 0; i < level.cowCounts.Length; i++)
        {
            levelGenerator.Generate(level.cowPrototypes[i], level.cowCounts[i]);
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
