using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDeath : MonoBehaviour
{
    public float Deathtime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Deathtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
