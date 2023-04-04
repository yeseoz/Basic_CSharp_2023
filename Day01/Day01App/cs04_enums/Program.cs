using System;
namespace cs04_enums
{
    internal class Program
    {
        enum HomeTown
        {
            SEOUL = 1,
            DAEJEON = 2,
            DAEGU = 3,
            BUSAN = 4,
            JEJU = 5
        };
        static void Main(string[] args)
        {
            HomeTown myHomeTown;
            myHomeTown = HomeTown.BUSAN;
            // 열거형을 쓰면 오타날 일이 줄어들음
            //

            myHomeTown = HomeTown.BUSAN;

            if(myHomeTown == HomeTown.SEOUL) 
            {
                Console.WriteLine("서울 출신이시군요!");
            }
            else if(myHomeTown == HomeTown.DAEJEON)
            {
                Console.WriteLine("충청도예유~");
            }
            else if (myHomeTown == HomeTown.DAEGU)
            {
                Console.WriteLine("대구여~");
            }
            else if(myHomeTown == HomeTown.BUSAN)
            {
                Console.WriteLine("부산이라예~~");
            }
        }
    }
}
