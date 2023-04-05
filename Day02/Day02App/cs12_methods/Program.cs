using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs12_methods
{
    class Calculator
    {
        public static int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, in int b) 
        {
            return a - b; 
        }
    }
    internal class Program
    {
        static void Main(string[] args) // 메인함수는 스테틱이여야함 ==> 프로그램이 끝날때까지 실행
        {
            #region < static 메서드 >
            int result = Calculator.Plus(1, 2); // new를 안하는 이유 static(정적) 때문
            Console.WriteLine(result);
            // static은 최초실행때 메모리에 바로 올라가기 때문에 클래스 객체를 만들필요가 없음
            //int result = new Calculator().Plus(1, 2); // public static int Plus(int a, int b) 하면 new 안해도됨

            //Calculator.Minus(3, 2); // Minus는 static이 아니기 때문에 접근 불가 (객체 생성해야 접근 가능)
            result = new Calculator().Minus(3, 2);
            Console.WriteLine(result);

            #endregion

            #region < Call by reference vs Call by Value 비교 >
            int x = 10;
            int y = 4;
            Swap(ref x, ref y); // x, y가 가지고 있는 주소를 전달하라 Call by reference == pointer
            // C#과 Java에서는 Pointer라는 개념을 덜어냄 근데 파이썬은 있음 ㅋㅋ 하지만 잘 안씀

            Console.WriteLine("x = {0}, y = {1}", x, y); // call by value이기 때문에 값이 안바뀜

            #endregion

            #region < out 매개변수 >

            int divid = 10;
            int divor = 3;
            int rem = 0;

            Divide(divid, divor, out result, out rem); // ref를 쓰든 out을 쓰든 결과는 똑같음 하지만 out을 쓰는 것을 권장함
            Console.WriteLine("나누기 값 {0}, 나머지 {1}", result, rem);


            #endregion

            #region < 가변길이 매개변수 >
            
            Console.WriteLine(Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)); // 개수를 마음대로 해도 상관 없음
            #endregion

        }

        //static int Divide(int x, int y)
        //{
        //    return x / y;
        //}
        //static int Reminder(int x, int y)
        //{
        //    return x % y;
        //} // 메서드 두개 만들걸 아래처럼 하나로 만듬

        //static void Divide(int x, int y, ref int val, ref int rem)
        static void Divide(int x, int y, out int val, out int rem)
        {
            val = x / y;
            rem = x % y;
        }
        
        static (int result, int rem) Divide(int x, int y)
        {
            return (x / y, x % y); // 튜플.. C# 7.0
        }
        static (float result, int rem) Divide(float x, float y)
        {
            return (x / y, (int)(x % y)); // 튜플.. C# 7.0
        }

        // Main 메스드와 같은 레벨에 있는 메서들은 전부 static이 되어야 함(무조건!!)
        public static void Swap(ref int a, ref int b) // static 없으면 부를 수 없음
        { 
            // ref가 없으면 Call by Value
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
        }

        static int val = 100;

        public static ref int GetNumber()
        {
            return ref val; // static 메서드에 접근할 수 있는 변수는 static 밖에 없음
        }

        public static int Sum(params int[] args) // Python 가변길이 매개변수랑 비교
        {
            int sum = 0;

            foreach(var item in args)
            {
                sum += item;
            }
            return sum;
        }
    }
}
