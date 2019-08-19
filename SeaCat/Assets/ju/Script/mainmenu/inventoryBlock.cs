using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryBlock : MonoBehaviour
{
    public Text myText;
    public Image myItemSprite;
    public bool isinTem = false;
    public int itemCode = -1, itemamount = 0;
    public int id;
    public Sprite select;
    Sprite orisprite;
    // Start is called before the first frame update
    void Start()
    {
        myItemSprite.gameObject.SetActive(false);
        myText.gameObject.SetActive(false);
        orisprite=transform.GetComponent<Image>().sprite;
    }
    void SetPrefs(int i)
    {
        if (i != -1)
        {
            PlayerPrefs.SetInt("monster" + i, itemamount);
        }
    }
    public void getselect()
    {
        if(itemCode!=-1)
        inventoryManager.Instant.selectBlock=id;
    }
    public void setCodeMount(int code, int mount)
    {
        itemCode = code;
        itemamount = mount;
    }
    // Update is called once per frame
    void Update()
    {
        if(inventoryManager.Instant.selectBlock==id)
        {
            transform.GetComponent<Image>().sprite=select;

        }
        else
        {
            transform.GetComponent<Image>().sprite=orisprite;
        }
        inventoryBlock inst;
        if (itemCode != -1)
        {
            if ((inventoryManager.Instant.aredyGetNode(itemCode)) != null)//아이템 코드가 같으면 더함
            {
                inst = inventoryManager.Instant.aredyGetNode(itemCode);
                if (inst.id < id)
                {
                    inst.itemamount += itemamount;
                    //itemamount = 0;
                    itemCode = -1;
                    Debug.Log("첫번째로 죽음!");
                }
            }
        }


        isinTem = (itemamount <= 0 || itemCode == -1) ? false : true;

        myText.text = "" + itemamount;

        if (!isinTem)
        {
            myItemSprite.gameObject.SetActive(false);
            myText.gameObject.SetActive(false);
            itemCode = -1;
        }
        else
        {
            myItemSprite.gameObject.SetActive(true);
            myText.gameObject.SetActive(true);
            myItemSprite.sprite = inventoryManager.Instant.itemSprite[itemCode];
            if (id - 1 >= 0)
            {
                if (inventoryManager.Instant.GetNode(id - 1).itemCode == -1)///내 앞에 비인 곳이 있으면 채움
                {
                    inventoryManager.Instant.GetNode(id - 1).setCodeMount(itemCode, itemamount);
                    itemCode = -1;
                    itemamount = 0;
                    isinTem = false;
                    Debug.Log("체인지한 블럭의 코드:" + inventoryManager.Instant.GetNullNode().itemCode);
                    Debug.Log("체인지한 블럭의 아이템 갯수" + inventoryManager.Instant.GetNullNode().itemamount);
                    Debug.Log("체인지한 블럭의 아이템 유무" + inventoryManager.Instant.GetNullNode().isinTem);
                    Debug.Log("체인지한 블럭의 아이디" + inventoryManager.Instant.GetNullNode().id);
                }
            }
        }

    }
}
