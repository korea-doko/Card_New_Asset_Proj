using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int id;

    public SpriteRenderer spr;

    public void Init(int _id)
    {
        this.id = _id;
        Hide();
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    

}
