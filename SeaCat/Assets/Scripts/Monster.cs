using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float red = 0;
    public float hp = 100;
    public GameObject DeathFish;
    Renderer render;
    float t = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shot")
        {
            hp -= (float)GameData.hitDamage+0.5f;
            red = 3;
        }
    }
    private void Start()
	{
        render = GetComponent<Renderer>();

        GameSystem.me.enemy_list.AddLast(transform);
	}

    private void FixedUpdate()
    {
        Death();
        RedDecrease();
    }

    public void DongDong()
    {
        t += 0.02f;
        transform.position += new Vector3(0, Mathf.Sin(t) * 0.02f);
        //transform.position
    }

    void Death()
    {
        if(hp <= 0)
        {
            GameSystem.me.enemy_list.Remove(transform);
            Instantiate(DeathFish).transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    ///붉은 효과 내기
    void RedDecrease()
    {
        if (red > 0)
        {
            red -= red / 5;
            render.material.color = Color.Lerp(new Color(1, 1, 1), new Color(20, 0, 0), red);
        }
    }
}
