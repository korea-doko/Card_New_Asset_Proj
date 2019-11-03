using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
    public Card[,] cardAry;

    public List<Card> cardPool;
    public List<Transform> cardPosList;

    public void Init(CardModel model)
    {
        MakeCardPool();
        InitCards();
    }

    private void MakeCardPool()
    {
        GameObject prefab = Resources.Load("Prefabs/Card") as GameObject;

        cardPool = new List<Card>();

        for (int i = 0; i < 20 ; i++)
        {
            Card card = ((GameObject)Instantiate(prefab)).GetComponent<Card>();
            card.transform.SetParent(this.transform);
            card.Init(i);

            cardPool.Add(card);
        }
    }

    public Card GetCard(int _x, int _y)
    {
        return cardAry[_x, _y];
    }

    private void InitCards()
    {
        cardAry = new Card[3, 3]; 

        for(int y = 0; y< 3 ; y++)
        {
            for(int x = 0; x <3; x++)
            {
                Card card = GetCardFromPool();

                Transform cardPos = cardPosList[3 * y + x];
                card.transform.position = cardPos.position;

                card.Show();
                cardAry[x, y] = card;
            }
        }
    }
    private Card GetCardFromPool()
    {
        if (cardPosList.Count <= 0)
            throw new Exception();

        Card card = cardPool[0];
        cardPool.RemoveAt(0);

        return card;
    } 
}
