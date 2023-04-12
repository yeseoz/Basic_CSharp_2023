using System;

namespace cs27_delgatechain
{
    delegate void ThereIsAFire(string location); // 불났을 때 대리해주는 대리자
    delegate int Calc(int a, int b);
    delegate string Concatenate(string[] args);
    class Sample
    {
        private int valueA; // 멤버변수 - 외부에서 접근 불가

        public int ValueA // 프로퍼티
        {
            //get { return valueA; } 
            //set { valueA = value; } // 일반식

            get => valueA;
            set => valueA = value; // 람다식
        }
    }

    internal class Program
    {
        #region < 대리자 활용을 위한 함수 생성 >
        static void Call119(string location)
        {
            Console.WriteLine("소방관님! 여기 {0}에 불났어옹..!", location);
        }

        static void ShoutOut(string location) 
        {
            Console.WriteLine("{0}에 불났어요!!", location);
        }

        static void Escape(string location)
        {
            Console.WriteLine("{0}에서 탈출합니다.", location);
        }
        #endregion

        static string ProcConcate(string[] args)
        {
            string result = string.Empty;
            foreach(string s in args)
            {
                result += s + "/";
            }
            return result;
        }

        static void Main(string[] args)
        {
            #region < 대리자 사용법 >
            // 우리가 직접 메서드를 호출해야한다면 밑의 코딩을 다해야함..!
            // 불이나면 그때부터 전화하고 소리지르고 탈출하고 해야함
            var loc = "우리집";
            Call119(loc);
            ShoutOut(loc);
            Escape(loc);

            // 하지만 대리자를 쓴다면?
            // 불이 날 수도 있으니까 미리준비 해놓는것!!
            // 준비가 되어있기 때문에 금방 사용가능!
            Console.WriteLine();
            Console.WriteLine("=====대리자 사용=====");
            var otherloc = "경찰서";
            ThereIsAFire fire = new ThereIsAFire(Call119);
            fire += new ThereIsAFire(ShoutOut);
            fire += new ThereIsAFire(Escape);

            fire(otherloc);

            // 체인 끊기
            Console.WriteLine();
            Console.WriteLine("====체인 끊기===");

            fire -= new ThereIsAFire(ShoutOut);
            fire("다른집");
            #endregion

            #region < 익명함수 >
            Console.WriteLine();
            Console.WriteLine("== 익명 함수 ==");
            Calc plus = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine(plus(6, 7));

            // 위의 형식과 동일한 것 => 람다식
            Calc minus = (a, b) => { return a - b; };
            //Calc minus = (a, b)=> a - b;
            
            Console.WriteLine(minus(6, 7));

            #endregion

            #region < 람다식 >
            Console.WriteLine();
            Console.WriteLine("=== 람다식 ===");
            Concatenate concat = new Concatenate(ProcConcate);
            var result = concat(args);

            Console.WriteLine(result);

            // 람다함수
            Console.WriteLine();
            Console.WriteLine(" === 람다 함수 ===");
            Concatenate concat2 = (arr) =>
            {
                string res = string.Empty;
                foreach (string s in args)
                {
                    res += s + "/";
                }
                return res;
            };

            Console.WriteLine(concat2(args));
            #endregion
        }
    }
}
