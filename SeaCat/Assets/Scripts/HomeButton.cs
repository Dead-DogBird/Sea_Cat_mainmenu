using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Cat.me == null)
        {
            GetComponent<Image>().enabled = true;
        }
        else
        if (Cat.me.transform.position.y >= 6)
        {
            GetComponent<Image>().enabled = true;
        }
        else
        {
            GetComponent<Image>().enabled = false;
        }
    }

    public void GoHome()
    {
        for (int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt("monster" + i, PlayerPrefs.GetInt("monster" + i, 0) + GameManager.fishcnt[i]);
        }
        SceneManager.LoadScene("Main_Menu");
    }
}
