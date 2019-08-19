using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public GameObject bubble;

    float t;
    float shot_able_time;

    private void Awake()
    {
        shot_able_time = Time.time + 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && t < Time.time)
        {
            Vector3 temp = collision.transform.position - transform.position;
            float degree = Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg;
            GameObject ob = Instantiate(bubble);
            ob.transform.position = transform.position;
            ob.transform.rotation = Quaternion.Euler(0,0,degree);
            t = Time.time + 3;
        }
    }

    private void FixedUpdate()
    {
        /*if (Time.time > shot_able_time)
        {
            var inst = Instantiate(bubble, transform.position, Quaternion.identity).GetComponent<CrabBubble>();
            inst.dire = ((Vector2)(Cat.me.transform.position) - (Vector2)transform.position).normalized;

            shot_able_time = Time.time + 1;
        }*/
        //t = 0;
    }
}
