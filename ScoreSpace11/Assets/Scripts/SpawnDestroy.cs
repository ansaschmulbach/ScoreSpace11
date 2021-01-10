using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject template;
    public int num;
    public static float leftBound = -19.8f;
    public static float rightBound = 30.2f;
    public static float upperBound = -1.0f;
    public static float lowerBound = -2.8f;

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
