using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
    public List<Card> cardList;

    public List<Card> cardPoolList;

    public float worldWidth;
    public float worldHeight;

    public float widthMargin;

    public float cardWidth;
    public float cardHeight;
    
    //
    public List<Transform> cardPosList;

    public void Init(CardModel model)
    {
        GameObject prefab = Resources.Load("Prefabs/Card") as GameObject;

        for(int i = 0; i < 9;i++)
        {
            Card card = ((GameObject)Instantiate(prefab)).GetComponent<Card>();

            Transform pos = cardPosList[i];

            card.transform.position = pos.position;
        }

    }

  

}
