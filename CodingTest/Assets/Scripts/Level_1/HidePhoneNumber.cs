using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HidePhoneNumber : MonoBehaviour
{
    /// <summary>
    /// 
    /// ���α׷��ӽ� ������� �������� ��ȣ�� ���� �������� ���� �� ������ ��ȭ��ȣ�� �Ϻθ� �����ϴ�.
    /// ��ȭ��ȣ�� ���ڿ� phone_number�� �־����� ��, ��ȭ��ȣ�� �� 4�ڸ��� ������ ������ ���ڸ� ����* ���� ���� ���ڿ��� �����ϴ� �Լ�, solution�� �ϼ����ּ���.
    /// 
    /// phone_number�� ���� 4 �̻�, 20������ ���ڿ��Դϴ�.
    /// 
    /// </summary>
    public string solution(string phone_number)
    {
        string answer = "";
        char[] chars = phone_number.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
            if (i < chars.Length - 4)
                chars[i] = '*';
        answer = new string(chars);
        return answer;
    }

    private void Awake()
    {
        Debug.Log(solution("01091204075"));
    }
}
