using System;
using System.Collections.Generic;

namespace number_4App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("무지개 색은 빨간색, 주황색, 노란색, 초록색, 파란색, 남색, 보라색, 입니다.");
            Console.WriteLine();

            var values = new Dictionary<string, string>();
            values.Add("Red", "Red는 빨간색 입니다.");
            values.Add("Orange", "Orange는 주황색 입니다.");
            values.Add("Yello", "Yello는 노란색 입니다.");
            values.Add("Green", "Green는 초록색 입니다.");
            values.Add("Blue", "Blue는 파란색 입니다.");
            values.Add("Indigo", "Indigo는 남색 입니다.");
            values.Add("Purple", "Purple는 보라색 입니다.");

            Console.WriteLine("Key와 Value확인");

            string color = "Purple";

            if(values.TryGetValue(color, out string result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("무지개 색이 아닙니다.");
            }

            
               
        }
    }
}
