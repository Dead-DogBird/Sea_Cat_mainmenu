using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dire;
    float des_time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
	{
        des_time = Time.time + 5;
	}

	private void FixedUpdate()
	{
        transform.position += transform.right * 0.6f;

        if (Time.time > des_time)
        {
            Destroy(gameObject);
        }
	}
}
