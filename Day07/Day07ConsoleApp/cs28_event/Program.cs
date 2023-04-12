using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs28_event // 어떤일이 생겼을때 ?
{ 
    // 이벤트를 사용하려면
    // 1. delegate 생성 (대리자 생성)
    delegate void EventHandler(string message);

    class CustomNotifier
    {
        // 2. 이벤트를 준비 (대리자를 사용한)
        public event EventHandler somethingChanged; // 대릴자의 이름을 somethingChanged로 바꿈
        public void DoSomething(int number)
        {
            int temp = number % 10;

            if(temp != 0 && temp % 3 ==0)
            {
                // 3. 특별한 이벤트가 발생할 상황에서 이벤트를 수행
                somethingChanged(string.Format("{0} : odd", number)); // 이런 값들을 보내준다~

                // 이런 일일때만 보내준다~
            }
        }
    }

    internal class Program
    {
        // 4. 이벤트가 대신호출할 메서드
        static void CustomHandler(string message) 
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            CustomNotifier notifier = new CustomNotifier();
            notifier.somethingChanged += new EventHandler(CustomHandler); // 클래스가 불러지면 CustomHandler가 일을 대신해 준다~

            for(int i = 0; i <= 30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
