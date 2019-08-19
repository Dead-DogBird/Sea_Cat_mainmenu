using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public Sprite[] ggg;
    SpriteRenderer sr;
    bool chk;
    float t;
    Collider2D coll;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        t = Time.time + Random.Range(0, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > t)
        {
            if(chk)
            {
                sr.sprite = ggg[0];
                coll.isTrigger = false;
                chk = false;
            }
            else
            {
                sr.sprite = ggg[1];
                coll.isTrigger = true;
                chk = true;
            }
            t = Time.time + 3;
        }
    }
}
