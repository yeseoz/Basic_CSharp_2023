using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs30_filereadwrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region < 파일 읽기 >
            string line = string.Empty; // 텍스트를 읽어와서 출력
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(@".\python.py"); // StreamReader에 파일을 연결
                line = reader.ReadLine(); // 한줄씩 읽음

                while (line != null)
                {
                    Console.WriteLine(line); // 한줄 읽은 것을 출력
                    line = reader.ReadLine(); // 다음줄을 읽어라~

                }
            }
            catch(Exception e) 
            {
                Console.WriteLine($"예외! {e.Message}");
            }
            finally
            {
                reader.Close(); // 반드시!! 무조건!!! 제발!!! 꼭!!!! 파일을 열면 닫아야함!!
            }
            #endregion

            #region < 파일 쓰기 >
            StreamWriter writer = new StreamWriter(@".\pythonByCsharp.py");

            try 
            {
                writer.WriteLine("import sys");
                writer.WriteLine("");
                writer.WriteLine("print(sys.executable)");
            }

            catch(Exception ex)
            {
                Console.WriteLine($"예외! {ex.Message}");
            }
            finally 
            {
                writer.Close(); 
            }

            Console.WriteLine("파일생성 완료!");

            #endregion
        }
    }
}
