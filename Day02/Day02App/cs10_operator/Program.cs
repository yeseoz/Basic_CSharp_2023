using System;

namespace cs10_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 비트연산자 //
            // << == *2
            // >> == /2
          
            int firstval = 15; // 15 = 1111
            int secondval = firstval << 1; // 11110 ==> 16 + 8 + 4 + 2 = 30
            Console.WriteLine(secondval);

            firstval = 15;
            secondval = 13;
            Console.WriteLine(firstval & secondval);
            firstval = 10;
            secondval = 5;
            Console.WriteLine(secondval | secondval);
            Console.WriteLine(firstval ^ secondval); // XOR
            Console.WriteLine(~secondval); // 보수
            // 실무에서는 많이 안씀
            // 비트연산(Shift) 연산은 조금 쓰일지도

            // Null 병합 연산자
            int? checkval = null;
            Console.WriteLine(checkval == null ? 0 : checkval); // 3항 연산자로 출력문을 만들 수 있음
            Console.WriteLine(checkval ?? 0); // null 병합 연산자는 3항 연산자를 더 축소 한것

            checkval = 25;
            Console.WriteLine(checkval.HasValue ? checkval.Value : 0); // 다 같은거!!
            Console.WriteLine(checkval == null ? 0 : checkval);
            Console.WriteLine(checkval ?? 0);

        }
    }
}
