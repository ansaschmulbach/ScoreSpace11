using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleTarget : MonoBehaviour
{
    public float countdown;
    private FieldManager fm;
    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FieldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0 || fm.nightTimer <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
