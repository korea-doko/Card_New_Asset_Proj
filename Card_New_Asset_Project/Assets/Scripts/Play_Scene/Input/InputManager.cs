using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class InputManager : MonoBehaviour
{
    public const float clickingCardTimeThreshHold = 1.0f;
    public const float dragDistanceThreshHold = 12.0f;
    // 카드 클릭 시간 쓰레쉬홀드
    // 입출력 드래그 거리 쓰레쉬홀드


    public float clickingCardTime;
    // 카드 클릭 시간
    public bool isCardClicked;
    // 카드 클릭 확인
    public Card clickedCard;
    // 클릭한 카드

    public Vector3 dragBeginScreenPos;
    // 클릭 시작 스크린위치
    
    private void Start()
    {           
        clickingCardTime = 0.0f;
        isCardClicked = false;
        dragBeginScreenPos = Vector3.zero;
        clickedCard = null;
    }
    
    // Update is called once per frame
    private void Update()
    {
        CheckCardClick();
        CheckMoveInput();
    }

    private void CheckCardClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);                
                RaycastHit2D raycastHit2D = Physics2D.Raycast(clickedPos, Vector2.zero);

                if (raycastHit2D)
                {
                    clickedCard = raycastHit2D.collider.GetComponent<Card>();
                    isCardClicked = true;
                }                
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (isCardClicked)
            {
                clickingCardTime += Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {         
            if (isCardClicked)
            {                
                // 클릭한 시간이 쓰레쉬홀드보다 큰 상황인지 확인
                if (clickingCardTime >= clickingCardTimeThreshHold)
                {
                    Vector3 clickEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    
                    // 눌러도 같은 카드인지 확인해야함
                    RaycastHit2D raycastHit2D = Physics2D.Raycast(clickEndPos, Vector2.zero);

                    if (raycastHit2D)
                    {
                        // 카드에 맞았다. ( 게임에서 콜라이더 카드만 있음 )
                        Card card = raycastHit2D.collider.GetComponent<Card>();

                        if (card.id == clickedCard.id)
                        {
                            Debug.Log("이 카드의 정보를 보여준다");
                        }
                        else
                        {
                   //         Debug.Log("카드긴한데 다른카드임 움직여서");
                        }

                    }
                }
                else
                {
                 //   Debug.Log("카드 충분히 오래 누르지 않음");
                }
            }

            isCardClicked = false;
            clickingCardTime = 0.0f;
            clickedCard = null;
        }
    }
    private void CheckMoveInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                dragBeginScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 dragEndScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 unitDragVector = dragEndScreenPos - dragBeginScreenPos;

            if (unitDragVector.magnitude > dragDistanceThreshHold)
            {
                Vector3 clickUnitVector = unitDragVector.normalized;
              
                if (clickUnitVector.x >= 0)
                {
                    if (clickUnitVector.y >= 0)
                    {
                        // 1사분면
                        if (Mathf.Abs(clickUnitVector.x) > Mathf.Abs(clickUnitVector.y))
                        {
                            CardManager.Inst.MovePlayer(CardManager.EMoveDir.East);
                        }
                        else
                        {
                            CardManager.Inst.MovePlayer(CardManager.EMoveDir.North);
                        }
                    }
                    else
                    {
                        // 4사분면

                        if (Mathf.Abs(clickUnitVector.x) > Mathf.Abs(clickUnitVector.y))
                        {
                            // 오른쪽이동
                            CardManager.Inst.MovePlayer(CardManager.EMoveDir.East);
                        }
                        else
                        {
                            CardManager.Inst.MovePlayer(CardManager.EMoveDir.South);
                            // 아래로 이동
                        }
                    }
                }
                else
                {
                    if (clickUnitVector.y >= 0)
                    {
                        // 2사분면
                        if (Mathf.Abs(clickUnitVector.x) > Mathf.Abs(clickUnitVector.y))
                        {
                            // 왼쪽이동
                            CardManager.Inst.MovePlayer(CardManager.EMoveDir.West);
                        }
                        else
                        {
                            // 위로 이동
                            CardManager.Inst.MovePlayer(CardManager.EMoveDir.North);
                        }
                    }
                    else
                    {
                        // 3사분면

                        if (Mathf.Abs(clickUnitVector.x) > Mathf.Abs(clickUnitVector.y))
                        {
                            // 왼쪽이동
                            CardManager.Inst.MovePlayer(CardManager.EMoveDir.West);
                        }
                        else
                        {
                            // 아래로 이동
                            CardManager.Inst.MovePlayer(CardManager.EMoveDir.South);
                        }
                    }
                }
            }    
        }
    }
}   
    
