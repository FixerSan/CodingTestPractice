using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInt : MonoBehaviour
{
    /// <summary>
    /// �ڿ��� n�� �Ű������� �־����ϴ�. n�� 3���� �󿡼� �յڷ� ������ ��, �̸� �ٽ� 10�������� ǥ���� ���� return �ϵ��� solution �Լ��� �ϼ����ּ���.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int solution(int n)
    {
        // 10���� -> 3���� ���� ����Ʈ
        List<int> triList = new List<int>();
        int remain = n;
        while (remain > 0)
        {
            triList.Add(remain % 3);
            remain /= 3;
        }

        // 3���� ��������Ʈ -> 10����
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
