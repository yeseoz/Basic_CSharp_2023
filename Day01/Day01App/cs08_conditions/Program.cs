namespace cs08_conditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 30;
            string result = "";
            if (a== 30) 
            {
                result = "삼십";
            }
            else
            {
                result = "삼십 아님";
            }

            // 조건 연산자 = 삼항 연산자
            int b = 40;
            string result2 = b == 40 ? "사십" : "사십 아님";
            // 긴 코드 안적으려고 삼항 연산자 쓰는 거임 많이 쓰임!

        }
    }
}
