using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageView : MonoBehaviour
{
    public Page rightPage;
    public Page leftPage;
    
    public void Init(PageModel model)
    {
        rightPage.Init();
        leftPage.Init();
    }   
}
