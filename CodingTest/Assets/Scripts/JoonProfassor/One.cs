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
        //���� �ڸ�
        int K = _x.ToString("D").Length;

        //X ���� �� X ��Ʈ������ ��ȯ
        string _xSquareString = ((ulong)_x * (ulong)_x).ToString("D");

        //������ �´��� üũ�� �� ����� ����
        string tempString = string.Empty;
        
        //�� üũ
        for (int i = _xSquareString.Length - K; i < _xSquareString.Length; i++)
            tempString += _xSquareString[i];
        if (tempString == _x.ToString("D"))
            return 1;

        return 0;
    }
    
    public int Solution(int n)
    {
        //���� ū ���� ã�� �Ŵϱ� �ڿ������� �ݺ���
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

        //���� ū ���� ã�� �Ŵϱ� �ڿ������� �ݺ���
        for (int i = n; i > 0; i--)
        {
            //i �� 100 �̸��� ��
            if (i < 100)
            {
                if (F(i) == 1)
                {
                    return i;
                }
            }

            //i �� 100 �̻��̸鼭 1000�̸��� ��
            else if (i >= 100 && i < 787109377)
            {
                //�ʱ�ȭ
                tempString = string.Empty;

                //i ��Ʈ������ ��ȯ
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

