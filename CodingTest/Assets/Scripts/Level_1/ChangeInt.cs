using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInt : MonoBehaviour
{
    /// <summary>
    /// 자연수 n이 매개변수로 주어집니다. n을 3진법 상에서 앞뒤로 뒤집은 후, 이를 다시 10진법으로 표현한 수를 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int solution(int n)
    {
        // 10진법 -> 3진법 반전 리스트
        List<int> triList = new List<int>();
        int remain = n;
        while (remain > 0)
        {
            triList.Add(remain % 3);
            remain /= 3;
        }

        // 3진법 반전리스트 -> 10진법
        int answer = 0;
        for (int i = 0; i < triList.Count; i++)
            answer += (int)Math.Pow(3, triList.Count - i - 1) * triList[i];

        return answer;
    }

    private void Awake()
    {
        Debug.Log(solution(10));
    }

    /// 1 
    /// 1 2 3
    /// 2
    /// 456
    /// 3
    /// 7 8 9
    /// 10
    /// 10 11 12

}
