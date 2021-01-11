using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelManager : MonoBehaviour
{

    [SerializeField] private float timeBetweenCows;
    [SerializeField] private float[] probabilities;
    [SerializeField] private GameObject[] realCows;
    private float cowSpawnTimer;
    private LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
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
                levelGenerator.Generate(realCows[i], 1);
                return;
            }
        }
    }
    
}
