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
    /// �� �� �ִ� �ִ� �Ÿ� ��� �Լ�
    /// </summary>
    /// <param name="x">            �� �ð�</param>
    /// <param name="shoesCount">   �Ź� ���� ���� </param>
    /// <param name="a">            �Ź��� �����Ǳ� ���� �ɸ��� �ð� </param>
    /// <param name="b">            �Ź��� ���ƽŴ� �ð� </param>
    /// <param name="c">            �Ź��� ����� �� �ִ� �ð� </param>
    /// <param name="d">            �Ź��� �ž��� �� �ӵ� (�⺻ �ӵ��� 1) </param>

    //���� ó���� �Ŵ� �Ź��� �����ð��� ª���� ����

    public void Start()
    {
        Debug.Log(Solution(TIME, SC, A, B, C, D));
    }

    public int Solution(int x, int shoesCount, int[] a, int[] b, int[] c, int[] d)
    {
        //�Ź��� ó�� �Ŵ� ��Ȳ����
        bool isFirstChange = true;

        //���� �Ź��� �ٲٰ� �ִ���
        bool isChanging = false;

        int changeTimeCheck = -1;

        //�Źߺ� ��� ���� ����
        bool[] isCanUses = new bool[shoesCount];

        //���� �ٲ� �� �ִ� �Ź��� �ִ���
        bool isCanChange = true;

        //�Ź� �� ���Ǿ����� ����
        bool[] isUsedShoes = new bool[shoesCount];

        //�Ź��� ����ϰ� �ִ���
        bool isUsing = false;

        int useRemainingTime = 0;

        //����ϰ� �ִ� �Ź��� �ε���
        int useShoesIndex = -1;

        //������ �Ÿ�
        int moveDistance = 0;

        //���� �ʼ�
        int nowSpeed = 1;

        //���� �� ���ǵ�
        int changeAfterSpeed = 0;

        //�迭�� �ʱ�ȭ
        for (int i = 0; i < shoesCount; i++)
        {
            isCanUses[i] = false;
            isUsedShoes[i] = false;
        }


        //�ð�(i��) ī��Ʈ
        for (int i = 0; i < x; i++)
        {
            isCanChange = false;
            //���� �Ǿ��ִ��� üũ
            for (int j = 0; j < shoesCount; j++)
            {
                //�Ź� ���� �ð��� �������鼭 ������ �ʾ��� ��
                if (a[j] < i+1 && !isUsedShoes[j])
                {
                    //j��° �Ź��� ����� �� �ִٰ� ǥ��
                    isCanUses[j] = true;

                    //�Ź��� �ٲ� �� �ִ� ���·� ����
                    if (!isCanChange && !isChanging)
                        isCanChange = true;
                }
            }

            //�ٲ� �� �����鼭
            if(isCanChange)
            {
                //ó�� �ٲٴ� �� �鼭
                if(isFirstChange)
                {
                    for (int j = 0; j < isCanUses.Length; j++)
                    {
                        //�ٲ� �� �ִ� �༮�� 
                        if (isCanUses[j])
                        {
                            //���� �༮�� ��� ���� �ʾ����鼭 ���� �༮�� ��ٸ��� �� ���� �׳� �����ϴ°� �ð� �ս��� ���� ���
                            if (j + 1 < shoesCount && !isUsedShoes[j+1] && a[j] + b[j] < a[j + 1] + b[j + 1])
                            {
                                isUsing = true;
                                useRemainingTime = c[j];
                                isFirstChange = false;
                                isChanging = true;
                                isUsedShoes[j] = true;
                                isCanUses[j] = false;
                                changeTimeCheck = b[j];
                                changeAfterSpeed = d[j];
                                break;
                            }
                        }
                    }
                }

                else
                {
                    for (int j = shoesCount; j > 0; j--)
                    {
                        if(isCanUses[j-1])
                        {
                            isUsing = true;
                            isUsedShoes[j - 1] = true;
                            isCanUses[j - 1] = false;
                            nowSpeed = d[j-1];
                            useRemainingTime = c[j];
                            break;
                        }
                    }
                }
            }

            if (isChanging)
            {
                changeTimeCheck--;
                if (changeTimeCheck <= 0)
                {
                    isChanging = false;
                    nowSpeed = changeAfterSpeed;
                    isUsing = true;
                    useRemainingTime = c[j];        //���⼭���� �ٽ���
                }
            }

            else
                moveDistance += nowSpeed;

            //
            if(isUsing)
            {
                useRemainingTime--;
                if(useRemainingTime <= 0)
                {
                    nowSpeed = 0;
                    
                }
            }
        }
        return moveDistance;
    }
}
