using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] public Level[] levels;
   [SerializeField] public GameObject[] cowPrototypes;
   
   [Serializable]
    public class Level
    {
        public float levelLength;
        public int totalCows;
        public int[] cowCounts;

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static float leftBound = -36f;
    private static float rightBound = 30.3f;
    private static float upperBound = -1.1f;
    private static float lowerBound = -5.7f;

    public void Generate(GameObject template, int num)
    {
        for(int i = 0; i < num; i++)
        {
            float randY = Random.Range(lowerBound, upperBound);
            float randX = Random.Range(leftBound, rightBound);
            Instantiate(template, new Vector3(randX, randY, randY), Quaternion.identity);
        }
    }

    public void Clear()
    {
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        for (int i = 0; i < cows.Length; i++)
        {
            Destroy(cows[i]);
        }
    }
    
}
