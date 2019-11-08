using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public Image pageImage;
    

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Init()
    {
        if (pageImage == null)
            pageImage = this.GetComponentInChildren<Image>();

        Hide();
    }
}
