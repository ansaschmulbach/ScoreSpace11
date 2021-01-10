using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour
{
    public float min_cooldown;
    public float max_cooldown;
    public bool active;
    private float cooldown;
    [SerializeField] MissleStart missleStart;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(min_cooldown, max_cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            if(cooldown <= 0)
            {
                //fire the missle
                MissleStart newMissle = Instantiate(missleStart);
                newMissle.transform.position = new Vector3(this.transform.position.x - 0.7f, this.transform.position.y + 1.3f, -1);
                cooldown = Random.Range(min_cooldown, max_cooldown);
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }
}
