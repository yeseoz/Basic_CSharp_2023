using System;

namespace cs06_var
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 변수형을 뭘로 지정해야할지 모르겠을 때 var 컴파일러가 알아서 바꿔줌
            var a = 4000000;
            Console.WriteLine("Type : {0}, Value : {1}", a.GetType(),a);

            var b = 3.141592; // f 붙이면 float 형이 됨
            Console.WriteLine("Type : {0}, Value : {1}", b.GetType(), b);

            var c = "Basic C#";
            Console.WriteLine("Type : {0}, Value : {1}", c.GetType(), c);
        }
    }
}
