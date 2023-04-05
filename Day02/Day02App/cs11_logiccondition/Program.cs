﻿using System;

namespace cs11_logiccondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region < if구문 >
            int a = 20;

            if(a==20)
            {
                Console.WriteLine("20입니다");
            }
            else
            {
                Console.WriteLine("20이 아닙니다.");
            }

            if (a == 30) return;
            // region 지역 주석

            #endregion
             
            #region < 데이터타입 비교 Switch 구문 >
            // 데이터 타입 비교 switch문 (C# 7.0부터 .NET framework 4.7 / 4.8)
            object obj = null;

            string inputs = Console.ReadLine(); // 콘솔에서 입력
            if (int.TryParse(inputs, out int ioupout))
            {
                obj = ioupout; // 입력한 값이 정수라서 문자열을 정수로 변환
            }
            else if(float.TryParse(inputs, out float foutput))
            {
                obj = foutput;
            }
            else
            {
                obj = inputs; // 이도 저도 아니다
            }

            Console.WriteLine(obj);
            switch (obj)
            {
                case int i: // 정수라면
                    Console.WriteLine("{0}은(는) int형식입니다.", i);
                    break;
                case float f: // 실수라면
                    Console.WriteLine("{0}은(는) float형식입니다.", f);
                    break;
                case string s: // 문자열이면
                    Console.WriteLine("{0}은(는) string형식입니다", s);
                    break;
                default:
                    Console.WriteLine("몰라요..");
                    break;
            }

            #endregion

            #region< 2중 For문 -구구단 >

            for(int x = 2; x<=9; x++)
            {
                for(int y = 1; y <= 9; y++)
                {
                    Console.WriteLine("{0} X {1} = {2}", x, y, x * y);
                }
                Console.WriteLine();
            }

            #endregion

            #region < Foreach문 >
            int[] ary = { 2, 4, 6, 8, 10 }; 

            foreach(int i in ary) // 배열이나 컬렉션(리스트)
            {
                Console.WriteLine("{0}*2 = {1}", i, i * 2);
            }

            Console.WriteLine();

            // 위와 완전 동일 하지만 위가 쓰기 편함
            for (int i = 0; i<ary.Length; i++)
            {
                Console.WriteLine("{0}*2 = {1}", ary[i], ary[i] * 2);
            }

            #endregion

        }
    }
}
