using System; //include

// 네임스페이스 ConsoleApp1
namespace ConsoleApp1 // 파이썬의 패키지
{
    /// <summary> => xml 주석 만들어진 소스를 문서화 할때 자동화 하는 좋은 주석
    /// 프로그램 클래스
    /// </summary>
    internal class Program // internal ==> private, public, protected (상속) 다 포함하는 기능
    {               // 파일명과 클래스명을 동일하게 하는 것이 좋음
        /// <summary>
        /// 메인 엔트리 포인트
        /// </summary>
        /// <param name="args">콘솔 매개변수</param>
        static void Main(string[] args) // 엔트리 포인트 시작점 ==>  void main()
        {
            Console.WriteLine("Hello C#"); // printf()
            
        }
    }
}
