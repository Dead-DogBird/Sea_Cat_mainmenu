using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text[] Fish_text_list = new Text[6];
    static public int[] fishcnt = new int[6];
    bool[] fishchk = new bool[6];
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            fishcnt[i] = 0;
            Fish_text_list[i].transform.parent.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 6; i++)
        {
            Fish_text_list[i].text = "x" + fishcnt[i];
            if (fishcnt[i] > 0 && !fishchk[i])
            {
                fishchk[i] = true;
                Fish_text_list[i].transform.parent.gameObject.SetActive(true);
            }
        }
    }
}
