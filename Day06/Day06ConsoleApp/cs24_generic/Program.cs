using System;
using System.Collections.Generic;

namespace cs24_generic
{
    #region < 일반화 클래스 >
    // 일반화는 꼭 알아야함!!!!!! 이거 만들면 밑에꺼 만들 필요가 없음ㅋ
    class MyArray<T> where T : class // where T: class 사용할 타입은 무조건 클래스 타입이여야 한다.
    {
        T[] array;
    }
    //class MyArray
    //{
    //    int[] array;
    //}

    //class MyArray_float
    //{
    //    float[] array;
    //}

    //class MyArray_double
    //{
    //    double[] array;
    //}
    #endregion

    internal class Program
    {
        #region < 일반화 메서드 >
        // 하나로 퉁! 치자!
        static void CopyArray<T>(T[]source, T[] target)
        {
            for(var i = 0; i< source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        //static void CopyArray(int[] source, int[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i];
        //    }
        //}

        //static void CopyArray(long[] source, long[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i];
        //    }
        //}

        //static void CopyArray(float[] source, float[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i];
        //    }
        //}

        //static void CopyArray(double[] source, double[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i];
        //    }
        //}

        //static void CopyArray(string[] source, string[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i];
        //    }
        //}

        //static void CopyArray(bool[] source, bool[] target)
        //{
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        target[i] = source[i];
        //    }
        //}
        #endregion

        static void Main(string[] args)
        {
            #region< 일반화 시키기 >

            // 일반화 컬렉션 제일 많이 사용
            // 타입이 다르면 계속.... 메소드 만들어야함
            int[] source = { 2, 4, 6, 8, 10 };
            int[] target = new int[source.Length];

            //CopyArray<int>(source, target); // 이제는 알아서 바꿔줌!
            CopyArray(source, target);
            Console.WriteLine("===int===");
            foreach(var item in target)
            {
                Console.WriteLine(item);
            }

            long[] source2 = { 2100000, 2300000, 3300000, 5600000, 7800000 };
            long[] target2 = new long[source2.Length];

            CopyArray(source2, target2);
            Console.WriteLine("===long===");
            foreach (var item in target2)
            {
                Console.WriteLine(item);
            }

            float[] source3 = { 3.14f, 3.15f, 3.16f, 3.17f, 3.19f };
            float[] target3 = new float[source3.Length];

            CopyArray(source3, target3);
            Console.WriteLine("===float===");
            foreach (var item in target3)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region < 일반화 컬렉션 >
            List<int> list = new List<int>();
            for(var i = 10; i > 0; i--)
            {
                list.Add(i);
            }

            Console.WriteLine("===일반화 컬렉션===");

            // 리스트는 컬렉션이기 때문에 foreach가 됨
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            list.RemoveAt(3); // 7 삭제
            Console.WriteLine("===RemoveAt(3)===");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Sort();
            Console.WriteLine("=== Sort() ===");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // 아래와 같은 일반화 컬렉션을 자주볼 수 있음
            List<MyArray<string>> myStringArray = new List<MyArray<string>>();

            #endregion

            #region < 일반화 스택 >

            Console.WriteLine("=== 일반화 스택 ===");
            Stack<float> stFloats = new Stack<float>();
            stFloats.Push(3.15f);
            stFloats.Push(3.14f);
            stFloats.Push(7.24f);

            while(stFloats.Count > 0)
            {
                Console.WriteLine(stFloats.Pop());
            }
            #endregion

            #region < 일반화 Queue >

            Console.WriteLine("=== 일반화 Queue  ===");

            Queue<string> qString = new Queue<string>();
            qString.Enqueue("Hello");
            qString.Enqueue("World");
            qString.Enqueue("My");
            qString.Enqueue("C#");

            while(qString.Count > 0)
            {
                Console.WriteLine(qString.Dequeue());
            }

            #endregion

            #region < 일반화 딕셔너리 >

            // 그다음 많이 사용
            Console.WriteLine("=== 일반화 딕셔너리 ===");

            Dictionary<string, int> dicNumbers = new Dictionary<string, int>();
            dicNumbers["하나"] = 1;
            dicNumbers["둘"] = 2;
            dicNumbers["셋"] = 3;
            dicNumbers["넷"] = 4;

            Console.WriteLine(dicNumbers["셋"]);

            #endregion

        }
    }
}
