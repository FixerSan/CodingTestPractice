using System;
using System.Collections.Generic;
using UnityEngine;

public class One :MonoBehaviour
{
    public int value;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log(Solution_B(value));
    }

    public int F(int _x)
    {
        //몇의 자리
        int K = _x.ToString("D").Length;

        //X 제곱 후 X 스트링으로 변환
        string _xSquareString = ((ulong)_x * (ulong)_x).ToString("D");

        //조건이 맞는지 체크할 때 사용할 변수
        string tempString = string.Empty;
        
        //값 체크
        for (int i = _xSquareString.Length - K; i < _xSquareString.Length; i++)
            tempString += _xSquareString[i];
        if (tempString == _x.ToString("D"))
            return 1;

        return 0;
    }
    
    public int Solution(int n)
    {
        //제일 큰 수를 찾는 거니까 뒤에서부터 반복문
        for (int i = n; i > 0; i--)
        {
            if (F(i) == 1)
            {
                return i;
            }
        }
        return -1;
    }

    public int Solution_B(int n)
    {
        string tempString = string.Empty;

        string pattern_A = "212890625";
        string pattern_B = "787109376";

        //제일 큰 수를 찾는 거니까 뒤에서부터 반복문
        for (int i = n; i > 0; i--)
        {
            //i 가 100 미만일 때
            if (i < 100)
            {
                if (F(i) == 1)
                {
                    return i;
                }
            }

            //i 가 100 이상이면서 1000미만일 때
            else if (i >= 100 && i < 787109377)
            {
                //초기화
                tempString = string.Empty;

                //i 스트링으로 변환
                tempString = i.ToString("D");


                if (tempString == pattern_A.Substring(pattern_A.Length - tempString.Length) || tempString == pattern_B.Substring(pattern_B.Length - tempString.Length))
                {
                    if (F(i) == 1)
                    {
                        return i;
                    }
                }
            }

            else if(i >= 787109377 && i < 1787109376)
            {
                return 787109376;
            }

            else if(i >= 1787109376)
            {
                return 1787109376;
            }
        }
        return -1;
    }

}

