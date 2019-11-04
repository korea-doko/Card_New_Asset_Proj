using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardView : MonoBehaviour
{
    public Card[,] cardAry;

    public List<Card> cardPool;
    public List<Transform> cardPosList;

    public void Init(CardModel model)
    {
        cardAry = new Card[3, 3];

        MakeCardPool();
       // InitCards();
    }

    public void SetCard(Card _card, int _x, int _y)
    {
        Card originCard = cardAry[_x, _y];
        cardPool.Add(originCard);

        cardAry[_x, _y] = _card;
    }
    public Card GetCard(int _x, int _y)
    {
        return cardAry[_x, _y];
    }
    public Transform GetCardPos(int x, int y)
    {
        return cardPosList[3 * y + x];
    }
    public void HideCardAt(int _x, int _y)
    {        
        Card card = cardAry[_x, _y];
        card.Hide();

        cardAry[_x, _y] = null;
        cardPool.Add(card);
    }
    public Card GetCardFromPool()
    {
        if (cardPosList.Count <= 0)
            throw new Exception();

        Card card = cardPool[0];
        cardPool.RemoveAt(0);

        return card;
    }





    private void InitCards()
    {
        cardAry = new Card[3, 3];

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Card card = GetCardFromPool();

                Transform cardPos = cardPosList[3 * y + x];
                card.transform.position = cardPos.position;

                card.Show();
                cardAry[x, y] = card;
            }
        }
    }
    private void MakeCardPool()
    {
        GameObject prefab = Resources.Load("Prefabs/Card") as GameObject;

        cardPool = new List<Card>();

        for (int i = 0; i < 20; i++)
        {
            Card card = ((GameObject)Instantiate(prefab)).GetComponent<Card>();
            card.transform.SetParent(this.transform);
            card.Init(i);

            cardPool.Add(card);
        }
    }

    

    
}