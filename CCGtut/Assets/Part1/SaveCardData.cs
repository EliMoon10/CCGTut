using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Card //따로 클래스를 만들어 관리하자 (데이터 타입 클래스)
{
    public int CardID;
    public string CardName;
    public string CardDis;
    public int CardMana;

    public Card(int id, int mana, string dis, string name)
    {
        CardID = id; //카드 고유 아이디
        CardMana = mana;// 카드의 마나
        CardDis = dis;// 카드의 설명
        CardName = name;// 카드의 이름
    }
}
public class SaveCardData : MonoBehaviour //읽고 쓰기 클래스
{
    public List<Card> CardList = new List<Card>(); //카드 리스트를 만든다.

    private void Start()
    {
        CardList.Add(new Card(0, 1, "Test", "TestCard"));//카드 리스트에 카드 정보를 추가한다.
    }
    public void SaveCard()
    {
        /*for(int j = 0; j < CardList.Count; j++)
        {
            Debug.Log(CardList[j].CardID); //저장하기 위해서는 카드리스트를 읽어와야한다.
            //태스트 용도
        }*/

        JsonData CardJson = JsonMapper.ToJson(CardList); // 카드리스트를 json화 시킵니다.
        File.WriteAllText(Application.dataPath + "/Resources/CardData.json", CardJson.ToString());//저장! (Resources 폴더)
    }

    public void LoadCard()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/CardData.json");//파일 읽어들이기
        JsonData CardData = JsonMapper.ToObject(json);//변환

        for(int j = 0; j < CardData.Count; j++)//카드 데이터 갯수만큼 for문 돌림
        {
            //카드의 데이터를 콘솔에 출력(id, mana, dis, name순으로 정렬)
            Debug.Log(CardData[j]["CardID"].ToString() + "," + CardData[j]["CardMana"].ToString() + "," + CardData[j]["CardDis"].ToString() + "," + CardData[j]["CardName"].ToString());
        }

    }


}
