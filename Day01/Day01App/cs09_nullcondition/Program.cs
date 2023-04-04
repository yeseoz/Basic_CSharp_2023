namespace cs09_nullcondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo myfoo = null; // new Foo();
            //// myfoo.member = 30;
            //// 지금은 null 이기 때문에 접근 할 수 없음 

            //int? bar;
            //if(myfoo != null) // 그래서 if 문쓴 것
            //{
            //    bar = myfoo.member;
            //}
            //else
            //{
            //    bar = null;
            //}
            // 위의 9줄을 (주석부분) 모두 축약 시킴
            int? bar = myfoo?.member; // myfoo가 null이 아니면 그 밑에 있는 member변수를 bar에 넣어라
            // <-- 눈에 잘 안들어 오는데 잘 봐둬야 함 -->
            // <-- 6버전 부터 나왔기 때문에 지금 많이 쓰인다.-->
        }
    }

    class Foo
    {
        public int member;
    }
}
