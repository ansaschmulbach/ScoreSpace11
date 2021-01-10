using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelManager : MonoBehaviour
{

    [SerializeField] private float timeBetweenCows;
    private float cowSpawnTimer;
    private LevelGenerator levelGenerator;
    private float[] probabilities;
    
    void Start()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
        LevelGenerator.Level level = levelGenerator.levels[levelGenerator.levels.Length - 1];
        probabilities = new float[level.cowCounts.Length];
        for (int i = 0; i < probabilities.Length; i++)
        {
            probabilities[i] = level.cowCounts[i] / (float) level.totalCows;
        }
        cowSpawnTimer = timeBetweenCows;
    }

    
    void Update()
    {
        cowSpawnTimer -= Time.deltaTime;
        if (cowSpawnTimer <= 0)
        {
            SpawnCow();
            cowSpawnTimer = timeBetweenCows;
        }
    }

    void SpawnCow()
    {
        float nextCow = Random.Range(0f, 1f);
        for (int i = 0; i < probabilities.Length; i++)
        {
            float prob = probabilities[i];
            if (nextCow > prob)
            {
                nextCow -= prob;
            }
            else
            {
                levelGenerator.Generate(levelGenerator.cowPrototypes[i], 1);
                return;
            }
        }
    }
    
}
