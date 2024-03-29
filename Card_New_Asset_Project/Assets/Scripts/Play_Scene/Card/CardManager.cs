﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;


/// <summary>
/// 처음 초기화 (InitSqeuence)만 Tweener 반환으로 처리하고
/// 나머지는 코드를 풀어쓰도록하자. 
/// 이 부분은 tweener 쪽이 약간 모자라서 그럴 수 있음
/// </summary>
public class CardManager : MonoBehaviour
{
    public enum EMoveDir
    {
        East,
        West,
        South,
        North
    }

    private static CardManager inst;

    public CardModel model;
    public CardView view;

    public readonly Vector2Int cardIndexRange = new Vector2Int(0, 2);
    public readonly float animationTime = 1.0f;

    public Sequence cardMoveSequence;
    public bool isSequencePlaying;
    public float sequenceCheckTime;

    public static CardManager Inst
    {
        get => inst;
    }
    public CardManager()
    {
        inst = this;
    }

    private void Start()
    {        
        model.Init();
        view.Init(model);

        cardMoveSequence = DOTween.Sequence();
        isSequencePlaying = false;
        sequenceCheckTime = 0.0f;


        Sequence initSequence = DOTween.Sequence();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Tweener initTweener = MakeCardAtTweener(x, y);
                initSequence.Join(initTweener);
            }
        }

        initSequence.Play();       
    }
    private void Update()
    {
        if( isSequencePlaying )
        {
            sequenceCheckTime += Time.deltaTime;

            if ( sequenceCheckTime > animationTime)
            {
                isSequencePlaying = false;
                sequenceCheckTime = 0.0f;
            }
        }        
    }

    public void MovePlayer(EMoveDir _dir)
    {
        if (!IsMovable(_dir))
            return;
        
        if (isSequencePlaying)
            return;

        /*
         *  1. 목적지에 있는 카드 효과를 발동한다.
         *  2. 목적지에 있는 카드를 없앤다.
         *  --> 이 때, View, Model에서 해당 관련된 정보들 정리해야함
         *  --> View - 카드풀에 집어넣기 / Model - 새로운 카드 데이터 생성
         *  3. 플레이어 위치 이동 
         *  --> 이 때, 카드도 이동시킨다.
         *  4. 새로운 카드가 빈 공간에 생성된다.
         *  --> 이 때, View, Model에서 새로운 정보 생성해야함
         */

        Card destCard = GetCardByDir(model.curX, model.curY, _dir);

        cardMoveSequence.Append
        (
                destCard.transform.DOScale(Vector3.zero, animationTime)      
        );
        // 목적지에 있는 카드 제거

        Card curCard = GetCard(model.curX, model.curY);
        Transform dest = GetCardPosByDir(model.curX, model.curY, _dir);

        cardMoveSequence.Join
        (
            curCard.transform.DOMove(dest.position, animationTime)        
        );
        // 현재 카드 이동



        Card newCard = view.GetCardFromPool();
        Transform newCardPos = GetCardPos(model.curX, model.curY);
        newCard.transform.position = newCardPos.position;
        newCard.transform.localScale = Vector3.zero;
        newCard.Show();

        cardMoveSequence.Join
        (
            newCard.transform.DOScale(Vector3.one, animationTime)        
        );
        // 삭제 및 이동으로 생긴 빈 공간에 카드 생성

        switch (_dir)
        {
            case EMoveDir.East:
                view.HideCardAt(model.curX + 1, model.curY);
                break;
            case EMoveDir.West:
                view.HideCardAt(model.curX - 1, model.curY);
                break;
            case EMoveDir.South:
                view.HideCardAt(model.curX, model.curY - 1);
                break;
            case EMoveDir.North:
                view.HideCardAt(model.curX, model.curY + 1);
                break;
            default:
                break;
        }

        
        cardMoveSequence.Play();
        isSequencePlaying = true;
        // 시퀀스 플레이

        view.cardAry[model.curX, model.curY] = newCard;
        ChangeCurPosBy(_dir);
        view.cardAry[model.curX, model.curY] = curCard;        
    }

    private void HideCardAt(EMoveDir _dir)
    {
        Card card = GetCardByDir(model.curX, model.curY, _dir);

        card.transform.DOScale(Vector3.zero, 1.0f).
            OnComplete(
            () =>
            {
                switch (_dir)
                {
                    case EMoveDir.East:
                        view.HideCardAt(model.curX + 1, model.curY);
                        break;
                    case EMoveDir.West:
                        view.HideCardAt(model.curX - 1, model.curY);
                        break;
                    case EMoveDir.South:
                        view.HideCardAt(model.curX , model.curY-1);
                        break;
                    case EMoveDir.North:
                        view.HideCardAt(model.curX , model.curY+1);
                        break;
                    default:
                        break;
                }           
            });      
        // 여기서 해당 위치 카드 효과를 발동시켜야한다
        Debug.Log("이 위치에서 카드효과발동필요");
    }
    private void MovePlayerTo(EMoveDir _dir)
    {
        Transform dest = GetCardPosByDir(model.curX, model.curY, _dir);

        Card curCard = GetCard(model.curX, model.curY);
        
        curCard.transform.DOMove(dest.position, 1.0f);        
    }

   
    private Tweener MakeCardAtTweener(int _x, int _y)
    {
        Card card = view.GetCardFromPool();
        Transform dest = GetCardPos(_x, _y);

        card.transform.position = dest.position;
        card.transform.localScale = Vector3.zero;
        card.Show();


        return card.transform.DOScale(Vector3.one, animationTime).Pause()
        .OnComplete
        (
            () =>
            {
                view.cardAry[_x, _y] = card;
            }
        );                               
    }
 
    


    private void ChangeCurPosBy(EMoveDir _dir)
    {
        // 다 끝나면 플레이어위치 변경해야함
        switch (_dir)
        {
            case EMoveDir.East:
                model.curX++;
                break;
            case EMoveDir.West:
                model.curX--;
                break;
            case EMoveDir.South:
                model.curY--;
                break;
            case EMoveDir.North:
                model.curY++;
                break;
            default:
                break;
        }
    }

    private bool CheckCardIndex(int _index)
    {
        if (_index >= cardIndexRange.x && _index <= cardIndexRange.y)
            return true;        
        return false;
    }
    private bool IsMovable(EMoveDir _dir)
    {
        switch (_dir)
        {
            case EMoveDir.East:
                if (CheckCardIndex(model.curX + 1))
                    return true;
                break;
            case EMoveDir.West:
                if (CheckCardIndex(model.curX - 1))
                    return true;
                break;
            case EMoveDir.South:
                if (CheckCardIndex(model.curY - 1))
                    return true;
                break;
            case EMoveDir.North:
                if (CheckCardIndex(model.curY + 1))
                    return true;
                break;
            default:
                break;
        }

        return false;
    }

    private Card GetCardByDir(int _x, int _y, EMoveDir _dir)
    {
        switch (_dir)
        {
            case EMoveDir.East:
                return GetCard(_x + 1, _y);
            case EMoveDir.West:
                return GetCard(_x - 1, _y);
            case EMoveDir.South:
                return GetCard(_x, _y - 1);                
            case EMoveDir.North:
                return GetCard(_x, _y + 1);
            default:
                break;
        }

        throw new System.Exception();
    }
    private Card GetCard(int _x, int _y)
    {
        return view.GetCard(_x, _y);
    }
    
    private Transform GetCardPosByDir(int _x, int _y, EMoveDir _dir)
    {
        switch (_dir)
        {
            case EMoveDir.East:
                return GetCardPos(_x + 1, _y);
            case EMoveDir.West:
                return GetCardPos(_x - 1, _y);
            case EMoveDir.South:
                return GetCardPos(_x, _y - 1);
            case EMoveDir.North:
                return GetCardPos(_x , _y+1);
            default:
                break;
        }
        throw new System.Exception();
    }
    private Transform GetCardPos(int _x, int _y)
    {
        return view.GetCardPos(_x, _y);
    }
   
}
