using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public float speed;
    private float countdown; //Target thingy shows up as this counts down
    private bool buildup; //Is the missle in the background, or about to come crashing?
    private Vector3 target; //Whatever the player's position is when phases shift
    private FieldManager fm;
    private SpriteRenderer sr;
    [SerializeField] int dmg;
    [SerializeField] Sprite missle2;
    [SerializeField] MissleTarget mt; //purely for looks
    [SerializeField] MissleExplosion me; //ditto
    private MissleTarget thisMt;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(-30,4,-3);
        countdown = 100;
        buildup = false;
        sr = gameObject.GetComponent<SpriteRenderer>();
        fm = FindObjectOfType<FieldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fm.nightTimer <= 0)
        {
            Destroy(this.gameObject);
        }
        if(!buildup)
        {
            this.transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
            if(this.transform.position.x > 20) //Missle exits to right
            {
                buildup = true;
                target = GameObject.FindGameObjectWithTag("Player").transform.position;
                this.transform.position = new Vector3(target.x, target.y + 20, -3);
                sr.sprite = missle2;
                MissleTarget icon = Instantiate(mt);
                icon.transform.position = target;
                thisMt = icon;
            }
        }
        else
        {
            if(thisMt.countdown > 0)
            {
                thisMt.countdown -= speed*Time.deltaTime;
                Debug.Log(thisMt.countdown);
            }
            else{
                if(this.transform.position.y > target.y)
                {
                    this.transform.position += new Vector3(0, -speed*Time.deltaTime*2, 0);
                }
                else
                {
                    MissleExplosion explosion = Instantiate(me);
                    explosion.transform.position = target;
                    explosion.dmg = dmg;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
