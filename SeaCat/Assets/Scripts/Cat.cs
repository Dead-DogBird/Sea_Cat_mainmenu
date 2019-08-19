using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    static public Cat me;

    public Gun gun;
    public Image Hp_Bar;
    public GameObject DeathCat;

    SpriteAnimation sprite_animation;
    Transform target;
    decimal max_speed = 0.1m;
    decimal vspeed = 0;
    decimal hspeed = 0;
    public decimal hp;
    decimal hitDamage;
    decimal getDamage;
    decimal o2delay;
    decimal cooltime;
    float t = 0;
    bool auto_aim;
    float shot_able_time;
    float mujuck_time;
    float red = 0;
    Renderer render;
    public AudioSource source;
    public AudioClip clip;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time > mujuck_time)
        {
            if (other.tag == "Monster")
            {
                hp -= getDamage;
                mujuck_time = Time.time + 1;
                red = 3;
            }
        }
    }
    private void Awake()
    {
        me = this;
        shot_able_time = Time.time;
        sprite_animation = GetComponent<SpriteAnimation>();
        hp = GameData.maxhp+200;
        max_speed = GameData.speed+0.2m;
        getDamage = GameData.getDamage;
        cooltime = GameData.cooltime+0.05m;
        render = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        InputCheck();
        SpeedDecrease();
        AnimationExecute();
        SpeedExecute();
        DongDong();
        TargetFind();
        AutoAim();
        SetHp();
        Death();
        RedDecrease();
        MapLimit();


        hp -= 0.02m;
    }

    /// <summary>
    /// 맵밖 못나가게하기
    /// </summary>
    void MapLimit()
    {
        if (transform.position.y > 7)
        {
            transform.position = new Vector3(transform.position.x, 7, transform.position.z);
        }
        if (transform.position.y < -54)
        {
            transform.position = new Vector3(transform.position.x, -54, transform.position.z);
        }
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
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

    public void AutoAim()
    {
        gun.transform.position = transform.position + new Vector3(0, 0, -3);
        Transform monster = TargetFind();

        target = monster;

        if (monster != null)
        {
            if (((Vector2)transform.position - (Vector2)monster.transform.position).magnitude <= 10f)
            {
                gun.dire = ((Vector2)monster.transform.position - (Vector2)transform.position).normalized.Direction();
                auto_aim = true;
            }
            else
            {
                auto_aim = false;
            }
        }
        else
        {
            auto_aim = false;
        }
    }

    /// <summary>
    /// 타겟을 정하기
    /// </summary>
    Transform TargetFind()
    {
        Transform minMonster = null;
        float minDistance = 0;

        foreach (Transform inst in GameSystem.me.enemy_list)
        {
            float distance = Vector2.Distance((Vector2)transform.position, (Vector2)inst.transform.position);

            //맨처음 몬스터 일단 넣어주기
            if (inst == GameSystem.me.enemy_list.First.Value)
            {
                minDistance = distance;
                minMonster = GameSystem.me.enemy_list.First.Value;
            }

            //제일 가까운애 찾기
            if (distance < minDistance)
            {
                minDistance = distance;
                minMonster = inst;
            }
        }

        return minMonster;
    }

    /// <summary>
    /// 동동 떠있는 느낌내기a
    /// </summary>
    void DongDong()
    {
        t += 0.06f;

        transform.position += new Vector3(0, Mathf.Sin(t) * 0.014f);
    }

    void SpeedExecute()
    {
        transform.position += new Vector3((float)hspeed, (float)vspeed);
    }

    /// <summary>
    /// 만약 속도가 0이 아닐시 애니메이션 재생a
    /// </summary>
    void AnimationExecute()
    {
        if (vspeed != 0 || hspeed != 0)
        {
            sprite_animation.ImageUpdate(sprite_animation.image_speed);
        }
    }

    /// <summary>
    /// 키입력받고 속도 증
    /// </summary>
	void InputCheck()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (vspeed < max_speed)
                vspeed += 0.02m;
            else
                vspeed = max_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (vspeed > -max_speed)
                vspeed -= 0.02m;
            else
                vspeed = -max_speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);

            if (hspeed < max_speed)
                hspeed += 0.03m;
            else
                hspeed = max_speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);

            if (hspeed > -max_speed)
                hspeed -= 0.03m;
            else
                hspeed = -max_speed;
        }

        if (Input.GetMouseButton(0))
        {
            if (Time.time > shot_able_time)
            {
                source.PlayOneShot(clip);
                gun.Shot();
                //hspeed = (decimal)gun.dire.DegreeToVector2().x * 0.15m;
                //vspeed = (decimal)gun.dire.DegreeToVector2().y * 0.15m;

                shot_able_time = Time.time + (float)cooltime;
            }

        }
    }

    /// <summary>
    /// 속도 감
    /// </summary>
    void SpeedDecrease()
    {
        if (vspeed > 0)
        {
            vspeed -= 0.005m;
            if (vspeed < 0)
                vspeed = 0;
        }
        if (vspeed < 0)
        {
            vspeed += 0.005m;
            if (vspeed > 0)
                vspeed = 0;
        }
        if (hspeed > 0)
        {
            hspeed -= 0.005m;
            if (hspeed < 0)
                hspeed = 0;
        }
        if (hspeed < 0)
        {
            hspeed += 0.005m;
            if (hspeed > 0)
                hspeed = 0;
        }
    }

    void SetHp()
    {
        Hp_Bar.fillAmount = (float)(hp / 100);
    }

    public void GetDamage()
    {
        hp -= getDamage;
    }

    public void Death()
    {
        if (hp <= 0)
        {
            Instantiate(DeathCat).transform.position = transform.position;
            Destroy(gun.gameObject);
            Destroy(gameObject);
        }
    }

    void Gomain()
    {

    }
}
