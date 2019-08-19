using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector2 dire_vec;
    public float dire;
    public GameObject bullet;

    public void Shot()
    {
        int l=3;
        for (int i = 0; i < l; i++)
        {
            Bullet inst = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
            inst.transform.localRotation = Quaternion.Euler(0, 0, dire +(i-(l/2))*(50/l)+Random.Range(-2,2));
        }//inst.transform.Rotate(0, 180, 0);
    }

    void FixedUpdate()
    {
        dire_vec = dire.DegreeToVector2();

        int plus = 0;
        if (dire_vec.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
            plus = 180;
        }
        else
        {
            transform.localScale = new Vector3(1f, 1, 1);
            plus = 0;
        }

        //.position += new Vector3(Mathf.Cos(dire * Mathf.Deg2Rad) * 0.6f, Mathf.Sin(dire * Mathf.Deg2Rad) * 0.4f + 0.2f, -3);
        transform.localRotation = Quaternion.Euler(0, 0, dire + plus);
    }
}
