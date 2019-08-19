using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFish : MonoBehaviour
{
    Vector2 temp;
    float randompos;
    // Start is called before the first frame update
    void Start()
    {
        randompos = Random.Range(0, 360f);
        temp = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(temp.x + Mathf.Sin(Time.time + randompos) * 5, temp.y);
        if (Mathf.Sin(Time.time + randompos) > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
