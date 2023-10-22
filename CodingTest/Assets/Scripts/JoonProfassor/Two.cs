using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : MonoBehaviour
{

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

    public void Solution(int x, int shoesCount, int[] a, int[] b, int[] c, int[] d)
    {
        //신발을 사용하고 있는지
        bool isUsed = false;
        //신발별 사용 가능 여부
        bool[] isCanUses = new bool[shoesCount];
        //신발별 사용 가능 여부 초기화
        for (int i = 0; i < isCanUses.Length; i++)
            isCanUses[i] = false;

        bool isFirstShoes = true;
        int useShoesIndex = -1;
        int moveDistance = 0;
        int nowSpeed = 1;
        int canChangeShoesIndex = -1;


        //시간(i초) 카운트
        for (int i = 0; i < x; i++)
        {
            //생성 되어있는지 체크
            for (int j = 0; j < shoesCount; j++)
            {
                if (a[j] < i)
                {
                    isCanUses[j] = true;
                }
            }

            //신발을 처음 신을 때는
            if (isFirstShoes)
            {
                //신발이 생성 되어있는지 체크
                //j는 신발의 인덱스
            }
            else
            {

            }

            useShoesIndex = canChangeShoesIndex;
            nowSpeed = d[useShoesIndex];
            moveDistance += nowSpeed;
        }
    }
}
