using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instant = null;//싱글톤 인스턴스
    public GameObject inventoryBlock;//인벤토리 블록들
    public List<inventoryBlock> BlockList = new List<inventoryBlock>();//인벤토리 블럭 List 
    decimal firstX = -750, firstY = 300;//맨처음 맨들 블럭 좌표

    public Sprite[] itemSprite = new Sprite[8];//아이템 코드 순서대로 이미지를 넣어줌..

    public Text priceT;//해산물의 가격
    public Image bicItem;//선택 됐을경우 크게 보이는 이미지
    // Start is called before the first frame update
    public inventoryBlock GetNullNode()//현재 빈노드중 가장 앞에 있는걸 리턴해줌.
    {
        foreach (inventoryBlock i in BlockList)
        {
            if (i.itemCode == -1)
                return i;
        }
        return null;
    }
    public inventoryBlock GetNode(int j)//n번째 블럭을 불러와줌
    {
        return BlockList[j];
    }
    public int selectBlock = -1;//선택한 블럭
    void startSetFile()//블럭이 받아올 PlayerPrefs들
    {
        for (int i = 0; i < 6; i++)
        {
            if (!PlayerPrefs.HasKey("monster" + i))
                PlayerPrefs.SetInt("monster" + i++, 0);
        }

    }
    void InitInventory()//실행 될 때 인벤토리에 아이템을 넣어줌
    {
        for (int i = 0; i < 6; i++)
        {
            if (PlayerPrefs.GetInt("monster" + i) != 0)//n번째 해산물이 있으면 블록에 넣어줌
            {
                if (GetNullNode() != null)//(그럴리는 없지만)블럭에 공간이 없으면 null리턴함
                {
                    GetNullNode().itemamount = PlayerPrefs.GetInt("monster" + i);//코드와 갯수를 넣어줌.....setselect 함수를 왜 안쓴 것이지?
                    GetNullNode().itemCode = i;
                }
                else
                {
                    Debug.Log("ㅎㅎ..ㅈㅅ;ㅋㅋ!");
                }

            }
        }
    }
    public inventoryBlock aredyGetNode(int i)//특정 아이템 코드를 이미 소유하고 있는 블럭을 리턴.
    {
        foreach (inventoryBlock l in BlockList)
        {
            if (l.itemCode == i)
                return l;
        }
        return null;
    }
    void Awake()
    {
        if (Instant == null) Instant = this;//(유사 싱글톤,와아!)
    }
    void Start()
    {
        int l = 0;
        for (int j = 0; j < 3; j++)//아름다운 이중for문으로 생성해줌
        {
            for (int i = 0; i < 3; i++)
            {
                inventoryBlock inst = Instantiate(inventoryBlock, new Vector3(0, 0), Quaternion.identity).GetComponent<inventoryBlock>();
                inst.transform.SetParent(this.gameObject.transform);//매니저를 부모로 설정함.
                inst.transform.localPosition = new Vector3((float)firstX + (float)(250 * i), (float)firstY + ((float)-250 * j));//아름다운 배치
                inst.transform.localScale = new Vector3(1, 1);//아름다운 크기
                inst.id = l++;//생성될때 순서대로 id를 부여함
                inst.itemCode = -1;//물론 아이템 코드는 -1로
                BlockList.Add(inst);//그리고... List에 넣어줌!

            }
        }
        //test();
        InitInventory();//인벤토리에 아이템도 살짜쿵 넣어줍시다.
        /* {
             int i = 0;
             foreach (inventoryBlock temp in BlockList)
             {
                 temp.itemamount = i + 1;
                 i++;
             }
         }
         */
    }
    public void sell()//판매 함수
    {
        if(selectBlock!=-1)//이쯤 되면 알죠? 비어있지 않을경우
        {
            int price=0;
            //아이템 코드를 받아와 가격에 맞춰줌.
            switch(GetNode(selectBlock).itemCode)
            {
                case 0:
                    price=30;
                    break;
                case 1:
                    price=40;
                    break;
                case 2:
                    price=100;
                    break;
                case 3:
                    price=200;
                    break;
                case 4:
                    price=300;
                    break;
                case 5:
                    price=1000;
                    break;
                default:
                break;
            }
            Canvas_select.Instance.money+=price;//플레이어 money에 더해줌
            GetNode(selectBlock).itemamount--;
        }
    }
    public void cook()
    {
        if (selectBlock != -1 && GetNode(selectBlock).itemamount >= 20)//20개 이상일때 요리가 가능
        {
            int price = 0;
            switch (GetNode(selectBlock).itemCode)
            {
                case 0:
                    price = 1;
                    break;
                case 1:
                    price = 2;
                    break;
                case 2:
                    price = 3;
                    break;
                case 3:
                    price = 4;
                    break;
                case 4:
                    price = 5;
                    break;
                case 5:
                    price = 10;
                    break;
                default:
                    break;
            }
            GameData.hitDamage += price;//데미지를 올려줌.
            GameData.Save();
            GetNode(selectBlock).itemamount -= 20;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (selectBlock != -1)//선택 된 블록이 있을때
        {
            if (GetNode(selectBlock).itemCode == -1)//그 블록이 비었다면 선택 블록을 없애줌
            {
                selectBlock--;
                if (selectBlock < 0)
                {
                    selectBlock = -1;
                }
            }
        }
        if(selectBlock!=-1)
        {
            int price=0;
            switch(GetNode(selectBlock).itemCode)
            {
                case 0:
                    price=30;
                    break;
                case 1:
                    price=40;
                    break;
                case 2:
                    price=100;
                    break;
                case 3:
                    price=200;
                    break;
                case 4:
                    price=300;
                    break;
                case 5:
                    price=1000;
                    break;
                default:
                break;
            }
        priceT.text=price+" 골드";//아이템 판매 텍스트 업데이트
        bicItem.sprite=itemSprite[GetNode(selectBlock).itemCode];//마찬가지로 선택 된 블럭의 아이템을 크게 띄워줌.
        }
    }
}
