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


    public void Init(CardModel model)
    {
        cardList = new List<Card>();

        worldHeight = Camera.main.orthographicSize * 2.0f;
        worldWidth = worldHeight / Screen.height * Screen.width;

        //InitCardPosAndSize();


        InitCardPool();              
    }

  
    private void InitCardPosAndSize()
    {
        //cardWidth = worldWidth * 0.33f;
        //cardHeight = worldHeight * 0.33f;
    }

    private void InitCardPool()
    {
        cardPoolList = new List<Card>();


        GameObject cardPrefab = Resources.Load("Prefabs/Card") as GameObject;

   

        for (int i = 0; i < 12; i++)
        {
            Card card = ((GameObject)Instantiate(cardPrefab)).GetComponent<Card>();

            card.Init(worldWidth,worldHeight);

            card.ChangeScale(0.33f, 0.33f);

            cardPoolList.Add(card);
        }
    }
}
