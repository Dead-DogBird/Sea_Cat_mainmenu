using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int number;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.fishcnt[number - 1]++;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 130);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
