using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PageManager : MonoBehaviour
{
    private static PageManager inst;

    [SerializeField] private PageModel model;
    [SerializeField] private PageView view;


    [SerializeField] private float turnOverTime;                  // 페이지 넘기는 전체 시간은 turnOverTime * 2
 


    public static PageManager Inst
    {
        get { return inst; }
    }
    public PageManager()
    {
        inst = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        model.Init();
        view.Init(model);

        turnOverTime = 0.3f;
    }

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.R))
            TurnOverRightToLeft();

        if (Input.GetKeyDown(KeyCode.L))
            TurnOverLeftToRight();
    }

    public void TurnOverLeftToRight( Action _atTheEndAction = null )
    {
        /*
        *  왼쪽에서 오른쪽으로 페이지가 넘어가는 애니메이션
        * 
        *  1. 왼쪽 페이지 열기
        *  -> L_Page Rotate 0 to -90
        *  2. 오른쪽 페이지 닫기
        *  -> R_Page Rotate 90 to 0
        */


        Sequence seq = DOTween.Sequence();

        Page leftPage = view.leftPage;
        Page rightPage = view.rightPage;


        leftPage.transform.eulerAngles = Vector3.zero;
        leftPage.Show();

        Tweener leftPageTweener = leftPage.transform.DORotate(new Vector3(0, -90.0f, 0), turnOverTime 
            )
            .OnComplete
            (
                () =>
                {
                    leftPage.Hide();
                    rightPage.transform.eulerAngles = new Vector3(0, 90.0f, 0);
                    rightPage.Show();
                }
            );
        seq.Append(leftPageTweener);


  

     

        Tweener rightPageTweener = rightPage.transform.DORotate(new Vector3(0, 10.0f, 0), turnOverTime)
            .OnComplete
            (
                () =>
                {
                    rightPage.Hide();
                }
            );
        seq.Append(rightPageTweener);

        if( _atTheEndAction != null)
        {
            seq.OnComplete
            (
                () => 
                {
                    _atTheEndAction();
                }
            );
        }

        seq.Play();
    }

    public void TurnOverRightToLeft( Action _atTheEndAction =null )
    {

        /*
         *  오른쪽에서 왼쪽으로 페이지가 넘어가는 애니메이션
         * 
         *  1. 오른쪽 페이지 열기
         *  -> R_Page Rotate 0 to 90
         *  2. 왼쪽 페이지 닫기
         *  -> L_Page Rotate -90 to 0
         */

        Sequence seq = DOTween.Sequence();


        Page rightPage = view.rightPage;
        Page leftPage = view.leftPage;


        rightPage.transform.rotation = new Quaternion(0, 0, 0, 0);
        rightPage.Show();

        Tweener rightPageTweener = rightPage.transform.DORotate(new Vector3(0, 90.0f, 0), turnOverTime)
            .OnComplete
            (
                () =>
                {
                    rightPage.Hide();
                    leftPage.Show();
                    leftPage.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);

                }
            );
        seq.Append(rightPageTweener);
          
        Tweener leftPageTweener = leftPage.transform.DORotate(new Vector3(0, -10.0f, 0), turnOverTime)
            .OnComplete
            (
                () =>
                {
                    leftPage.Hide();
                }
            );
        seq.Append(leftPageTweener);

        if( _atTheEndAction != null)
        {
            seq.OnComplete
            (
                () =>
                {
                    _atTheEndAction();
                }
            );
        }

        seq.Play();

    }

}
