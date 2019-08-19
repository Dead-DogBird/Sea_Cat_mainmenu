using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class Canvas_select : MonoBehaviour
{
    public new AudioSource audio;

    public AudioClip audioClip;
    public GameObject Bg;
    Image BgImage;
    public Sprite burrBg;
    Sprite OriBg;
    public int CanvasCode;
    public int StageCode = 1, maxNum;
    public int money;
    public Text money_text;
    public static Canvas_select Instance = null;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void DataDelete()
    {
        PlayerPrefs.DeleteAll();
    }
    public void toCanvas(int num)
    {
        CanvasCode = num;
    }
    // Start is called before the first frame update
    void Start()
    {
        //saveStageInfo();
        //Load();
        BgImage=Bg.GetComponent<Image>();
        OriBg=BgImage.sprite;
        if(!PlayerPrefs.HasKey("money"))
        PlayerPrefs.SetInt("money",0);

        else
        {
            money=PlayerPrefs.GetInt("money");
        }
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.audioClip;
        audio.loop = true;
        audio.Play();
    }
  
    // Update is called once per frame
    void Update()
    {
        if(CanvasCode==0)
        {
            BgImage.sprite=OriBg;
        }
        else
        {
            BgImage.sprite=burrBg;
        }
        PlayerPrefs.SetInt("money",money);
        money_text.text=money+" 골드";
    }

    public void GoGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
