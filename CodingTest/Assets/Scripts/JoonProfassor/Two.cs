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

    public void Update()
    {

            if (Input.GetMouseButtonDown(0))
                Debug.Log(Solution(TIME, SC, A, B, C, D));
    }

    public int Solution(int x, int shoesCount, int[] a, int[] b, int[] c, int[] d)
    {
        //신발을 처음 신는 상황인지
        bool isFirstChange = true;

        //지금 신발을 바꾸고 있는지
        bool isChanging = false;

        //신발을 처음 바꿀 때 걸리는 시간 체크용
        int changeTimeCheck = -1;

        //신발별 사용 가능 여부
        bool[] isCanUses = new bool[shoesCount];

        //지금 바꿀 수 있는 신발이 있는지
        bool isCanChange = true;

        //신발 별 사용되었는지 여부
        bool[] isUsedShoes = new bool[shoesCount];

        //신발을 사용하고 있는지
        bool isUsing = false;

        //신발 유지 시간
        int useRemainingTime = 0;

        //사용하고 있는 신발의 인덱스
        int useShoesIndex = -1;

        //현재 초속
        int nowSpeed = 1;

        //움직인 거리
        int moveDistance = 0;

        //신발을 언제까지 유지해도 괜찮은지 확인용
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
            //변경 가능 여부 초기화
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
                //처음 바꾸는 거라면
                if(isFirstChange)
                {
                    //바꿀 수 있는 신발을 찾고
                    for (int j = 0; j < isCanUses.Length; j++)
                    {
                        //바꿀 수 있는 신발이 있다면
                        if (isCanUses[j])
                        {
                            //그 신발과 다른 신발을 비교
                            for (int k = 0; k < shoesCount; k++)
                            {
                                //다른 신발이 쓰였거나 같은 신발이면 넘기고
                                if (k == j || isUsedShoes[k])
                                    continue;

                                //바꾸려는 신발의 다른 신발들의 처음 사용 가능 시간을 비교해서 바꾸려는 신발이 더 긴 경우
                                //여기서 처음 사용 가능 시간이란 신발이 만들어지는 시간(a) + 신발을 장착하는 시간(b)
                                if (a[j] + b[j] > a[k] + b[k])
                                {
                                    //다른 신발을 기다리게끔 지금 바꾸려는 신발을 불가능 처리 후 브레이크
                                    isCanUses[j] = false;
                                    break;
                                }

                                //바꾸려는 신발의 다른 신발들의 처음 사용 가능 시간을 비교해서 서로 같을 경우
                                else if (a[j] + b[j] == a[k] + b[k])
                                {
                                    //둘의 속도를 비교해서 만약 바꾸려는 신발의 속도가 더 느리다면 다른 신발을 기다리게끔
                                    //지금 바꾸려는 신발을 불가능 처리 후 브레이크
                                    if (d[j] < d[k])
                                    {
                                        isCanUses[j] = false;
                                        break;
                                    }
                                }
                            }
                            //모든 예외처리를 거치고 아직도 바꿀 수 있는 상태라면 바꾸기
                            if (isCanUses[j])
                            {
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
                        //바꿀 수 있는 신발을 찾고 그 신발이 나보다 더 좋은 성능을 가지고 있는지 체크
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
                    {
                        nowSpeed = 1;
                        isUsing = false;
                    }
                }
            }
        }
        return moveDistance;
    }
}

