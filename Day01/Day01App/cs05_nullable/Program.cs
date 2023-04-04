using System;

namespace cs05_nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int a = 0; // 초기화 하면 사용도 안됨
            // int a null 값을 담을 수 없음 C# 6.0에 Nullable 등장!
            int? a = null;
            Console.WriteLine(a == null); // int는 Null 값을 가질 수 없다.
            // Console.WriteLine(a.GetType()); // Null은 GetType()를 받아 올 수 없다. => 예외 발생

            int b = 0;
            Console.WriteLine(b == null);
            Console.WriteLine(b.GetType());

            // 값형식 byte, short, int, long, float, double, char 등은 null을 할당 x
            // null 을 할당할 수 잇또록 만드는 방식 type? ==> int? a

            float? c = null;
            Console.WriteLine(c.HasValue);

            c = 3.14f;
            Console.WriteLine(c.HasValue);
            Console.WriteLine(c.Value);
            Console.WriteLine(c);
        }
    }
}
