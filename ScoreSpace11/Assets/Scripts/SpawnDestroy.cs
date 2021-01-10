﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject template;
    public int num;
    private static float leftBound = -36f;
    private static float rightBound = 30.3f;
    private static float upperBound = -1.1f;
    private static float lowerBound = -5.7f;

    public void SpawnAll()
    {
        for(int i = 0; i < num; i++)
        {
            float randY = Random.Range(lowerBound, upperBound);
            float randX = Random.Range(leftBound, rightBound);
            Instantiate(template, new Vector3(randX, randY, randY), Quaternion.identity);
        }
    }

}
