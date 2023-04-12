using System;

namespace cs26_delegate
{

        #region < 대리자  선언 >
        // 대리자 사용하겠다는 선언
        delegate int CalcDelegate(int a, int b); // 매게변수는 동일하게 <!--타입이 클래스랑 다르면 안됨 --!>
        // CalcDelegate가 static Minus를 대신해서 사용
        // 값이 아닌 코드 자체를 매개변수로 넘기고 싶을때
        delegate int Compare(int a, int b);
        
        #endregion

        #region < 계산기 클래스 >

        class Calc
        {
            public int Plus(int a, int b)
            {
                return a + b;
            }
            // static이 붙으면 무조건 실행될때 최초 메모리에 올라감
            // 프로그램 실행중에는 언제든지 접근 가능
            public static int Minus(int a, int b)
            {
                return a - b;
            }
        }

    #endregion
    internal class Program
    {
        #region < 오름차순 내림차순 비교 >
        // 오름차순 비교
        static int AscendCompare(int a, int b) 
        {
            if (a > b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        // 내림차순 비교
        static int DescendCompare(int a, int b)
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        static void BubbleSort(int[] DataSet, Compare comparer)
        {
            int i = 0, j = 0, temp = 0;

            for( i = 0; i < DataSet.Length-1; i++)
            {
                for(j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    //if (DataSet[j] > DataSet[j + 1]) // 오름차순
                    if (comparer(DataSet[j], DataSet[j + 1]) > 0) // 대리자 사용
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp; // Swap
                    }
                }
            }
        }
        #endregion
        static void Main(string[] args)
        {
            #region < 일반적 클래스 사용방식 - 직접호출 >
            // 일반적으로 클래스 사용방식
            Calc normalCalc = new Calc();
            int x = 10, y = 15;
            Console.WriteLine(normalCalc.Plus(x, y));

            // normalCalc.Minus(x, y); // static이라서 안됨 정적인 메소드라서
            Console.WriteLine(Calc.Minus(x, y));
            #endregion

            #region < 대리자를 사용하는 방식 - 간접호출 >
            // 대신해주는 이유는???? 뒤에 나옴... 조금더 편리해 지기 위해서..
            x = 30; y = 20;
            
            Calc delCalc = new Calc();
            CalcDelegate Callback; // 대신할꺼야

            Callback = new CalcDelegate(delCalc.Plus); // 클래스 처럼 사용 
            int res2 = Callback(x, y); // = Calc.Plus() 대신 호출 => Calc.Plus()의 일을 내가 대신해줄께!
            Console.WriteLine(res2);

            Callback = new CalcDelegate(Calc.Minus);
            res2 = Callback(x, y);
            Console.WriteLine(res2);

            #endregion

            #region < 오름차순 >
            int[] origin = { 4, 7, 8, 2, 9, 1 };

            BubbleSort(origin, new Compare(AscendCompare));

            foreach(var item in  origin)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            Console.WriteLine("내ㅐ림차순 버블정렬");
            BubbleSort(origin, new Compare(DescendCompare));

            foreach (var item in origin)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            #endregion

        }
    }
}
