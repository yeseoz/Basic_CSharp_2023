using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs19_interface
{
    interface ILogger // 약속 > 하위 클래스는 
    {
        void WriteLog(string log); // 이걸 반드시 만들어야 한다! 는 약속
    } // 얘가 클래스면 상속이 됨
    // 하지만 얘가 인터페이스면 구현이됨

   interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params object[] args); // args 다중 파라미터
    }


    class ConsoleLogger : ILogger // 상속 아님 구현임
    {
        // 인터페이스를 가져다 쓰면 반드시 인테페이스 안에 있는 인터페이스 멤버를 사용해야함
        public void WriteLog(string log)
        {
            // throw new NotImplementedException(); // 반드시 예외가 발생하기 때문에 지워줘야함
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), log);
        }
    }

    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string format, params object[] args)
        {
            string messaage = string.Format(format, args);
            Console.WriteLine("{0}, {1}", DateTime.Now.ToLocalTime(), messaage);
        }

        public void WriteLog(string log)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), log);
        }
    }

    class Car
    {
        public string Name { get; set; }
        public string Color { get; set; } 
        public void Stop()
        {
            Console.WriteLine("멈춰!");
        }
    }

    interface IHoverable
    {
        void Hover(); // 물에서 달린다.
    }

    interface IFlyable
    {
        void Fly();  // 날다
    }

    class FlyHoverCar : Car, IFlyable, IHoverable  //, ConsoleLogger C#은 다중상속 안됨
        // 다중상속 문제를 해결하기 위해 Interface 만듬
    {
        public void Fly()
        {
            Console.WriteLine("납니다.");
        }

        public void Hover()
        {
            Console.WriteLine("물에서 달립니다");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.WriteLog("안녕!");

            IFormattableLogger logger2 = new ConsoleLogger2();
            logger2.WriteLog("{0} * {1} = {2}", 6, 5, (6 * 5));
        }
    }
}
