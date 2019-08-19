using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBubble : MonoBehaviour
{
    public Vector3 dire;
    float speed = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Cat>().hp -= GameData.getDamage;
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * 0.08f);
    }
}
