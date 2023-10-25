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
    /// 본 함수는 0이상 1000이하의 좌표 값, 같은 _x, _y의 Length의 매개변수를 요구함
    /// <param name="_x"> 포인트의 x좌표</param>
    /// <param name="_y">포인트의 y좌표</param>
    /// <param name="_direction"> 담장을 짓는 방향 (-1: 반시계방향, 1:시계방향)</param>
    public void Solution(int[] _x, int[] _y, int _direction)
    {
        //가장 긴 라인의 시작점 인덱스
        int bestLongLineStartPointIndex = -1;

        //가장 짧은 라인의 시작점 인덱스
        int bestShortLineStartPointIndex = -1;

        //방향 스트링
        string directionString = string.Empty;

        //이미 그려진 포인트 인지 체크
        bool[] isDrawedPoint = new bool[_x.Length];


        



        if (_direction == -1)
            directionString = "반 시계 방향";
        else if (_direction == 1)
            directionString = "시계 방향";

        Debug.Log($"방향은 :: {directionString}");
        Debug.Log($"가장 긴 담장의 시작점의 좌표는 :: {x[bestLongLineStartPointIndex]} , {y[bestLongLineStartPointIndex]})");
        Debug.Log($"가장 짧은 담장의 시작점의 좌표는 :: {x[bestShortLineStartPointIndex]} , {y[bestShortLineStartPointIndex]})");
    }
}
