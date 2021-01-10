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


    public void Generate(GameObject template, int num)
    {
        for(int i = 0; i < num; i++)
        {
            float randY = Random.Range(Globals.lowerBound, Globals.upperBound);
            float randX = Random.Range(Globals.leftBound, Globals.rightBound);
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
