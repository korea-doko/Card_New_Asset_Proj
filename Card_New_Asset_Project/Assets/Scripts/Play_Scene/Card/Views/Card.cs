using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer spr;

    public void Init(float worldWidth, float worldHeight)
    {
        spr = this.GetComponent<SpriteRenderer>();

        ChangeScaleToScreen(worldWidth, worldHeight);
    }

    public void ChangeScale(float width, float height)
    {       
        spr.transform.localScale = new 
            Vector3
            (
                spr.transform.localScale.x * width, 
                spr.transform.localScale.y * height,
                1
            );
    }


    private void ChangeScaleToScreen(float width, float height)
    {
        this.transform.localScale =
            new Vector3
            (
                width / spr.sprite.bounds.size.x,
                height / spr.sprite.bounds.size.y,
                1
            );
    }
}
