using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public int maxLife;                     // 최대 체력
    public int curLife;                     // 현재 체력

    public int maxFood;                     // 최대 식량
    public int curFood;                     // 현재 식량

    public int maxGold;                     // 최대 골드
    public int curGold;                     // 현재 골드

    public int maxEnergy;                   // 전투에서 가지는 최대 에너지 보유량
    public int maxHandSlots;                // 전투에서 가지는 핸드의 최대 갯수

    public int maxItemLimit;                // 아이템 소지 갯수 제한
    public List<GameObject> itemList;       // 현재 가지고 있는 아이템 리스트

    public void Init()
    {

    }
}
