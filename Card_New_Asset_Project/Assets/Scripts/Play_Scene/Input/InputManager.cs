using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class InputManager : MonoBehaviour
{
    public const float clickCardTimeThreshHold = 1.0f;
    public const float dragDistanceThreshHold = 12.0f;
    public const float dragUnitVectorThreshHold = 0.5f;
    // 카드 클릭 시간 쓰레쉬홀드
    // 입출력 드래그 거리 쓰레쉬홀드


    public float clickCardCurTime;
    // 카드 클릭 시간
    public bool isCardClicked;
    // 카드 클릭 확인


    public Vector3 clickStartPos;
    public Card clickedCard;

    
    void Start()
    {           
        clickCardCurTime = 0.0f;
        isCardClicked = false;
        clickStartPos = Vector3.zero;
        clickedCard = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                clickStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D raycastHit2D = Physics2D.Raycast(clickStartPos, Vector2.zero);

                if(raycastHit2D)
                {
                    // 카드에 맞았다. ( 게임에서 콜라이더 카드만 있음 )
                    clickedCard = raycastHit2D.collider.GetComponent<Card>();
                    isCardClicked = true;
                }
                else
                {
                    // UI && Card에 맞지 않음
                    //Debug.Log("b");
                }
           }            
        }

        if( Input.GetMouseButton(0))
        {
            if( isCardClicked )
            {
                clickCardCurTime += Time.deltaTime;
            }
        }

        if( Input.GetMouseButtonUp(0))
        {
            Vector3 clickEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 clickVector = clickEndPos - clickStartPos;
            
            if( clickVector.magnitude > dragDistanceThreshHold)
            {
                Vector3 clickUnitVector = clickVector.normalized;

                Debug.Log("충분히 움직여서 카드입출력으로 처리");      
                
                if( clickUnitVector.x >= 0 )
                {
                    if (clickUnitVector.y >= 0)
                    {
                        // 1사분면
                        if (Mathf.Abs(clickUnitVector.x) > Mathf.Abs(clickUnitVector.y))
                        {
                            Debug.Log("동");
                        }
                        else
                        {
                            Debug.Log("북");
                        }
                    }
                    else
                    {
                        // 4사분면

                        if (Mathf.Abs(clickUnitVector.x) > Mathf.Abs(clickUnitVector.y))
                        {
                            // 오른쪽이동

                            Debug.Log("동");
                        }
                        else
                        {
                            // 아래로 이동
                            Debug.Log("남");
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
                            Debug.Log("서");
                        }
                        else
                        {
                            // 위로 이동

                            Debug.Log("북");
                        }
                    }
                    else
                    {
                        // 3사분면

                        if (Mathf.Abs(clickUnitVector.x) > Mathf.Abs(clickUnitVector.y))
                        {
                            // 왼쪽이동

                            Debug.Log("서");
                        }
                        else
                        {
                            // 아래로 이동

                            Debug.Log("남");
                        }
                    }
                }



            }
            else
            {
                Debug.Log("충분히 움직이지 않아서 입출력처리불가능");
            }


            if ( isCardClicked )
            {
                // 클릭한 시간이 쓰레쉬홀드보다 큰 상황인지 확인
                if ( clickCardCurTime >= clickCardTimeThreshHold)
                {
                    // 눌러도 같은 카드인지 확인해야함
                    RaycastHit2D raycastHit2D = Physics2D.Raycast(clickEndPos, Vector2.zero);

                    if (raycastHit2D)
                    {
                        // 카드에 맞았다. ( 게임에서 콜라이더 카드만 있음 )
                        Card card = raycastHit2D.collider.GetComponent<Card>();

                        if( card.id == this.clickedCard.id)
                        {
                            Debug.Log("이 카드의 정보를 보여준다");
                        }
                        else
                        {
                            Debug.Log("카드긴한데 다른카드임 움직여서");
                        }

                    }
                }
                else
                {
                    Debug.Log("카드 충분히 오래 누르지 않음");
                }     
            }

            isCardClicked = false;
            clickCardCurTime = 0.0f;
            clickedCard = null;
        }
    }
}   
    
