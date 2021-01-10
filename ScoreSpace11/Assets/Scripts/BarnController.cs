using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NormalBarnState();
    }

    public void MissileBarnState()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void NormalBarnState()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    
}
