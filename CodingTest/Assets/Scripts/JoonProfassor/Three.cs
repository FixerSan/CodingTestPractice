using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class Three : MonoBehaviour
{
    public TextAsset[] textAssets;
    public int[] x;
    public int[] y;
    public int direction;

    private void Start()
    {
        StringToIntArray(textAssets[0], () =>
        {
            Solution(x, y, direction);
        });
    }

    public void StringToIntArray(TextAsset _textAsset, Action _callback = null)
    {
        int pointCount = 0;

        StringReader stringReader = new StringReader(_textAsset.text);
        while (stringReader != null)
        {
            string line = stringReader.ReadLine();
            if (line == null)
                break;
            pointCount++;
        }

        x = new int[pointCount];
        y = new int[pointCount];
        pointCount = 0;

        stringReader = new StringReader(_textAsset.text);
        while (stringReader != null)
        {
            string line = stringReader.ReadLine();
            if (line == null)
                break;

            string[] lines = line.Split('\t');
            x[pointCount] = int.Parse(lines[0]);
            y[pointCount] = int.Parse(lines[1]);

            pointCount++;
        }
    }
    /// <summary>
    /// 
    /// </summary> 
    /// �� �Լ��� 0�̻� 1000������ ��ǥ ��, ���� _x, _y�� Length�� �Ű������� �䱸��
    /// <param name="_x"> ����Ʈ�� x��ǥ</param>
    /// <param name="_y">����Ʈ�� y��ǥ</param>
    /// <param name="_direction"> ������ ���� ���� (-1: �ݽð����, 1:�ð����)</param>
    public void Solution(int[] _x, int[] _y, int _direction)
    {
        //���� �� ������ ������ �ε���
        int bestLongLineStartPointIndex = -1;

        //���� ª�� ������ ������ �ε���
        int bestShortLineStartPointIndex = -1;

        //���� ��Ʈ��
        string directionString = string.Empty;

        //�̹� �׷��� ����Ʈ ���� üũ
        bool[] isDrawedPoint = new bool[_x.Length];


        



        if (_direction == -1)
            directionString = "�� �ð� ����";
        else if (_direction == 1)
            directionString = "�ð� ����";

        Debug.Log($"������ :: {directionString}");
        Debug.Log($"���� �� ������ �������� ��ǥ�� :: {x[bestLongLineStartPointIndex]} , {y[bestLongLineStartPointIndex]})");
        Debug.Log($"���� ª�� ������ �������� ��ǥ�� :: {x[bestShortLineStartPointIndex]} , {y[bestShortLineStartPointIndex]})");
    }
}
