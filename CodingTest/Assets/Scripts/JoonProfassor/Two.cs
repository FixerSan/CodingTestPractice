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

    public void Update()
    {

            if (Input.GetMouseButtonDown(0))
                Debug.Log(Solution(TIME, SC, A, B, C, D));
    }

    public int Solution(int x, int shoesCount, int[] a, int[] b, int[] c, int[] d)
    {
        //�Ź��� ó�� �Ŵ� ��Ȳ����
        bool isFirstChange = true;

        //���� �Ź��� �ٲٰ� �ִ���
        bool isChanging = false;

        //�Ź��� ó�� �ٲ� �� �ɸ��� �ð� üũ��
        int changeTimeCheck = -1;

        //�Źߺ� ��� ���� ����
        bool[] isCanUses = new bool[shoesCount];

        //���� �ٲ� �� �ִ� �Ź��� �ִ���
        bool isCanChange = true;

        //�Ź� �� ���Ǿ����� ����
        bool[] isUsedShoes = new bool[shoesCount];

        //�Ź��� ����ϰ� �ִ���
        bool isUsing = false;

        //�Ź� ���� �ð�
        int useRemainingTime = 0;

        //����ϰ� �ִ� �Ź��� �ε���
        int useShoesIndex = -1;

        //���� �ʼ�
        int nowSpeed = 1;

        //������ �Ÿ�
        int moveDistance = 0;

        //�Ź��� �������� �����ص� �������� Ȯ�ο�
        int tempInt = 0;

        //�� �ʱ�ȭ
        for (int i = 0; i < shoesCount; i++)
        {
            isCanUses[i] = false;
            isUsedShoes[i] = false;
        }


        //�ð�(i��) ī��Ʈ
        for (int i = 0; i < x; i++)
        {
            //���� ���� ���� �ʱ�ȭ
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

            //�ٲ� �� �����鼭 �ٲٰ� �ִ� ���°� �ƴ� ��
            if(isCanChange && !isChanging)
            {
                //ó�� �ٲٴ� �Ŷ��
                if(isFirstChange)
                {
                    //�ٲ� �� �ִ� �Ź��� ã��
                    for (int j = 0; j < isCanUses.Length; j++)
                    {
                        //�ٲ� �� �ִ� �Ź��� �ִٸ�
                        if (isCanUses[j])
                        {
                            //�� �Ź߰� �ٸ� �Ź��� ��
                            for (int k = 0; k < shoesCount; k++)
                            {
                                //�ٸ� �Ź��� �����ų� ���� �Ź��̸� �ѱ��
                                if (k == j || isUsedShoes[k])
                                    continue;

                                //�ٲٷ��� �Ź��� �ٸ� �Źߵ��� ó�� ��� ���� �ð��� ���ؼ� �ٲٷ��� �Ź��� �� �� ���
                                //���⼭ ó�� ��� ���� �ð��̶� �Ź��� ��������� �ð�(a) + �Ź��� �����ϴ� �ð�(b)
                                if (a[j] + b[j] > a[k] + b[k])
                                {
                                    //�ٸ� �Ź��� ��ٸ��Բ� ���� �ٲٷ��� �Ź��� �Ұ��� ó�� �� �극��ũ
                                    isCanUses[j] = false;
                                    break;
                                }

                                //�ٲٷ��� �Ź��� �ٸ� �Źߵ��� ó�� ��� ���� �ð��� ���ؼ� ���� ���� ���
                                else if (a[j] + b[j] == a[k] + b[k])
                                {
                                    //���� �ӵ��� ���ؼ� ���� �ٲٷ��� �Ź��� �ӵ��� �� �����ٸ� �ٸ� �Ź��� ��ٸ��Բ�
                                    //���� �ٲٷ��� �Ź��� �Ұ��� ó�� �� �극��ũ
                                    if (d[j] < d[k])
                                    {
                                        isCanUses[j] = false;
                                        break;
                                    }
                                }
                            }
                            //��� ����ó���� ��ġ�� ������ �ٲ� �� �ִ� ���¶�� �ٲٱ�
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

                //ó�� �ٲٴ� �� �ƴ϶��
                else
                {
                    for (int j = shoesCount; j > 0; j--)
                    {
                        //�ٲ� �� �ִ� �Ź��� ã�� �� �Ź��� ������ �� ���� ������ ������ �ִ��� üũ
                        if(isCanUses[j-1] && nowSpeed < d[j-1])
                        {
                            //�ٲ� �� ������ ���� ���� �ٲ�� �ϴ��� �׽�Ʈ
                            tempInt = 0;
                            for (int k = 0; k < shoesCount; k++)
                            {
                                if (!isUsedShoes[k])
                                    tempInt += c[k];
                            }

                            //���� �ٲ��� ������ �ս��� �Ͼ ��� ����
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

            //�ٲٴ� ���̶��
            if (isChanging)
            {
                //ü���� ������ ����
                changeTimeCheck--;
                //ü���� �����̰� ���� ���� �ߴٸ� �Ź� ����
                if (changeTimeCheck <= 0)
                {
                    isChanging = false;
                    nowSpeed = d[useShoesIndex];
                    isUsing = true;
                    useRemainingTime = c[useShoesIndex];
                }
            }

            //�ٲٴ� ���� �ƴ϶��
            else
            {
                //�����̱�
                 moveDistance += nowSpeed;
                //�����̰� ���� ������ �����ð� ����
                if (isUsing)
                {
                    useRemainingTime--;
                    //�����ð��� ���� �����ߴٸ� ���� �ӵ��� ����
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

