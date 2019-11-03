using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CardManager : MonoBehaviour
{
    private static CardManager inst;

    public enum EMoveDir
    {
        East,
        West,
        South,
        North
    }

 
    public CardModel model;
    public CardView view;

    public Vector2Int cardIndexRange;

    public static CardManager Inst
    {
        get => inst;
    }
    public CardManager()
    {
        inst = this;
    }


    public void MovePlayer(EMoveDir _dir)
    {
        if (!IsMovable(_dir))
            return;

        Card curCard = view.GetCard(model.curX, model.curY);
        
        //curCard.transform.DOMove();
    }
    private void Start()
    {
        cardIndexRange = new Vector2Int(0, 2);

        model.Init();
        view.Init(model);
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

    private Card GetCard(int _x, int _y)
    {
        return view.GetCard(_x, _y);
    }

}
