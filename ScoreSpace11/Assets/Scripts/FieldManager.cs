using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{

    [SerializeField] private float nightLength;
    private float nightTimer;
    private int level;

    void Start()
    {
        level = 0;
        nightTimer = nightLength;
    }

    void Update()
    {
        nightTimer -= Time.deltaTime;
        if (nightTimer <= 0)
        {
            LaunchUpdatesScreen();
        }
    }

    public void NextLevel()
    {
        
    }
    
    void LaunchUpdatesScreen()
    {
        
    }
}
