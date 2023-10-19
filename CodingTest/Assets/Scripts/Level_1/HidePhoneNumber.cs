using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HidePhoneNumber : MonoBehaviour
{
    /// <summary>
    /// 
    /// 프로그래머스 모바일은 개인정보 보호를 위해 고지서를 보낼 때 고객들의 전화번호의 일부를 가립니다.
    /// 전화번호가 문자열 phone_number로 주어졌을 때, 전화번호의 뒷 4자리를 제외한 나머지 숫자를 전부* 으로 가린 문자열을 리턴하는 함수, solution을 완성해주세요.
    /// 
    /// phone_number는 길이 4 이상, 20이하인 문자열입니다.
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
