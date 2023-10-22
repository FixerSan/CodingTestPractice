using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : MonoBehaviour
{

    /// <summary>
    /// �� �� �ִ� �ִ� �Ÿ� ��� �Լ�
    /// </summary>
    /// <param name="x">            �� �ð�</param>
    /// <param name="shoesCount">   �Ź� ���� ���� </param>
    /// <param name="a">            �Ź��� �����Ǳ� ���� �ɸ��� �ð� </param>
    /// <param name="b">            �Ź��� ���ƽŴ� �ð� </param>
    /// <param name="c">            �Ź��� ����� �� �ִ� �ð� </param>
    /// <param name="d">            �Ź��� �ž��� �� �ӵ� (�⺻ �ӵ��� 1) </param>
     
        //���� ó���� �Ŵ� �Ź��� �����ð��� ª���� ����

    public void Solution(int x, int shoesCount, int[] a, int[] b, int[] c, int[] d)
    {
        //�Ź��� ����ϰ� �ִ���
        bool isUsed = false;
        //�Źߺ� ��� ���� ����
        bool[] isCanUses = new bool[shoesCount];
        //�Źߺ� ��� ���� ���� �ʱ�ȭ
        for (int i = 0; i < isCanUses.Length; i++)
            isCanUses[i] = false;

        bool isFirstShoes = true;
        int useShoesIndex = -1;
        int moveDistance = 0;
        int nowSpeed = 1;
        int canChangeShoesIndex = -1;


        //�ð�(i��) ī��Ʈ
        for (int i = 0; i < x; i++)
        {
            //���� �Ǿ��ִ��� üũ
            for (int j = 0; j < shoesCount; j++)
            {
                if (a[j] < i)
                {
                    isCanUses[j] = true;
                }
            }

            //�Ź��� ó�� ���� ����
            if (isFirstShoes)
            {
                //�Ź��� ���� �Ǿ��ִ��� üũ
                //j�� �Ź��� �ε���
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
