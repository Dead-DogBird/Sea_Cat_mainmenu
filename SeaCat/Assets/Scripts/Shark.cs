using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 temp = (collision.transform.position - transform.position).normalized;
            transform.parent.Translate(temp * 0.05f);
            transform.parent.localScale = new Vector3(0.8f * (temp.x > 0 ? -1 : 1), 0.8f, 1);
        }
    }

    private void FixedUpdate()
    {
        //transform.position += (Cat.me.transform.position - transform.position).normalized * 0.04f;
    }
}
