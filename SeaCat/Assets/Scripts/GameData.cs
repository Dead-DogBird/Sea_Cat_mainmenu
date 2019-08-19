using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData : MonoBehaviour
{
    static public decimal speed;
    static public decimal maxhp;
    static public decimal hitDamage;
    static public decimal getDamage;
    static public decimal cooltime;
    static public int gold;

    private void Awake()
    {
        speed = (decimal)PlayerPrefs.GetFloat("state1", 0.08f);
        maxhp = (decimal)PlayerPrefs.GetFloat("state2", 100);
        hitDamage = (decimal)PlayerPrefs.GetFloat("state3", 15);
        getDamage = (decimal)PlayerPrefs.GetFloat("state4", 15);
        cooltime = (decimal)PlayerPrefs.GetFloat("state6", 0.7f);
        gold = PlayerPrefs.GetInt("state7", 0);
        DontDestroyOnLoad(gameObject);
    }

    static public void Save()
    {
        PlayerPrefs.SetFloat("state1", (float)speed);
        PlayerPrefs.SetFloat("state2", (float)maxhp);
        PlayerPrefs.SetFloat("state3", (float)hitDamage);
        PlayerPrefs.SetFloat("state4", (float)getDamage);
        PlayerPrefs.SetFloat("state5", (float)hitDamage);
        PlayerPrefs.SetFloat("state6", (float)cooltime);
        PlayerPrefs.SetInt("state7", gold);
    }

    static public void SaveReset()
    {
        PlayerPrefs.DeleteAll();
    }
}

