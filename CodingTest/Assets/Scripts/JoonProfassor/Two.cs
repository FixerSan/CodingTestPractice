using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : MonoBehaviour
{
    public int TIME;
    public int SC;
    public int[] A;
    public int[] B;
    public int[] C;
    public int[] D;
    /// <summary>
    /// 갈 수 있는 최대 거리 계산 함수
    /// </summary>
    /// <param name="x">            총 시간</param>
    /// <param name="shoesCount">   신발 종류 개수 </param>
    /// <param name="a">            신발이 생성되기 까지 걸리는 시간 </param>
    /// <param name="b">            신발을 갈아신는 시간 </param>
    /// <param name="c">            신발을 사용할 수 있는 시간 </param>
    /// <param name="d">            신발을 신었을 때 속도 (기본 속도는 1) </param>

    //가장 처음에 신는 신발이 장착시간이 짧으면 좋음

    public void Start()
    {
        Debug.Log(Solution(TIME, SC, A, B, C, D));
    }

    public int Solution(int x, int shoesCount, int[] a, int[] b, int[] c, int[] d)
    {
        //신발을 처음 신는 상황인지
        bool isFirstChange = true;

        //지금 신발을 바꾸고 있는지
        bool isChanging = false;

        int changeTimeCheck = -1;

        //신발별 사용 가능 여부
        bool[] isCanUses = new bool[shoesCount];

        //지금 바꿀 수 있는 신발이 있는지
        bool isCanChange = true;

        //신발 별 사용되었는지 여부
        bool[] isUsedShoes = new bool[shoesCount];

        //신발을 사용하고 있는지
        bool isUsing = false;

        int useRemainingTime = 0;

        //사용하고 있는 신발의 인덱스
        int useShoesIndex = -1;
        
        //가장 속도가 느린 신발의 인덱스

        //현재 초속
        int nowSpeed = 1;

        //움직인 거리
        int moveDistance = 0;

        //임시 인트
        int tempInt = 0;

        //값 초기화
        for (int i = 0; i < shoesCount; i++)
        {
            isCanUses[i] = false;
            isUsedShoes[i] = false;
        }


        //시간(i초) 카운트
        for (int i = 0; i < x; i++)
        {
            isCanChange = false;
            //생성 되어있는지 체크
            for (int j = 0; j < shoesCount; j++)
            {
                //신발 생성 시간이 지났으면서 사용되지 않았을 때
                if (a[j] < i+1 && !isUsedShoes[j])
                {
                    //j번째 신발은 사용할 수 있다고 표시
                    isCanUses[j] = true;

                    //신발을 바꿀 수 있는 상태로 변경
                    if (!isCanChange && !isChanging)
                        isCanChange = true;
                }
            }

            //바꿀 수 있으면서 바꾸고 있는 상태가 아닐 때
            if(isCanChange && !isChanging)
            {
                //처음 바꾸는 거 면서
                if(isFirstChange)
                {
                    for (int j = 0; j < isCanUses.Length; j++)
                    {
                        //바꿀 수 있는 녀석이 
                        if (isCanUses[j])
                        {
                            //다음 녀석이 사용 되지 않았으면서 다음 녀석을 기다리는 것 보다 그냥 장착하는게 시간 손실이 적을 경우
                            if (j + 1 < shoesCount && !isUsedShoes[j+1] && a[j] + b[j] < a[j + 1] + b[j + 1])
                            {
                                //바꾸기
                                isUsing = true;
                                useRemainingTime = c[j];
                                isFirstChange = false;
                                isChanging = true;
                                isUsedShoes[j] = true;
                                isCanUses[j] = false;
                                changeTimeCheck = b[j];
                                useShoesIndex = j;
                                break;
                            }
                        }
                    }
                }

                //처음 바꾸는 게 아니라면
                else
                {
                    for (int j = shoesCount; j > 0; j--)
                    {
                        //바꿀 수 있는 녀석을 찾고
                        if(isCanUses[j-1] && nowSpeed < d[j-1])
                        {
                            //바꿀 수 있지만 굳이 지금 바꿔야 하는지 테스트
                            tempInt = 0;
                            for (int k = 0; k < shoesCount; k++)
                            {
                                if (!isUsedShoes[k])
                                    tempInt += c[k];
                            }

                            //지금 바꾸지 않으면 손실이 일어날 경우 변경
                            if(tempInt>x-(i+1))
                            {
                                isUsedShoes[j - 1] = true;
                                isCanUses[j - 1] = false;
                                nowSpeed = d[j-1];
                                useRemainingTime = c[j - 1];
                                useShoesIndex = j - 1;
                                isUsing = true;
                                break;
                            }
                        }
                    }
                }
            }

            //바꾸는 중이라면
            if (isChanging)
            {
                //체인지 딜레이 감소
                changeTimeCheck--;
                //체인지 딜레이가 전부 감소 했다면 신발 장착
                if (changeTimeCheck <= 0)
                {
                    isChanging = false;
                    nowSpeed = d[useShoesIndex];
                    isUsing = true;
                    useRemainingTime = c[useShoesIndex];
                }
            }

            //바꾸는 중이 아니라면
            else
            {
                //움직이기
                 moveDistance += nowSpeed;
                //움직이고 나서 아이템 유지시간 감소
                if (isUsing)
                {
                    useRemainingTime--;
                    //유지시간이 전부 감소했다면 원래 속도로 변경
                    if (useRemainingTime <= 0)
                        nowSpeed = 1;
                }
            }
        }
        return moveDistance;
    }
}

