using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{

    public CardData[,] cardDataAry;

    public int curX;
    public int curY;
     
    public void Init()
    {
        cardDataAry = new CardData[3, 3];

        for(int i = 0; i < 3;i++)
        {
            for(int j = 0; j < 3;j++)
            {
                cardDataAry[i, j] = new CardData();
            }
        }

        curX = 1;
        curY = 1;
    }




}
