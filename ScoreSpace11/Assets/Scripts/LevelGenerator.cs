using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] public Level[] levels;

   [Serializable]
    public class Level
    {
        public float levelLength;
        public int totalCows;
        public int[] cowCounts;
        public GameObject[] cowPrototypes;
        
        
        
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate(GameObject obj, int amount)
    {
        //TODO
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
