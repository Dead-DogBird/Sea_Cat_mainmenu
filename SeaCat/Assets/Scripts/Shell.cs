using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public Sprite open;
    public GameObject bubble;

    bool openchk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!openchk && collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = open;
            collision.gameObject.GetComponent<Cat>().hp += 10;
            openchk = true;
            Instantiate(bubble).transform.position = transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
