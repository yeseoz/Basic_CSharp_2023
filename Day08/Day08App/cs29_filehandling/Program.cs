using System;
using System.IO;

namespace cs29_filehandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region < 특정 경로에 하위폴더/ 하위파일 조회 >
            // Directory == Folder
            // string curdir = "."; // 현재 디렉토리 (상대경로)
            // string curdir = ".."; // 부모디렉토리
            string curdir = @"C:\Temp"; // 절대경로 @ => 리터럴 문자 여러줄 문자열 만들때 사용


            Console.WriteLine("현재 디렉토리 정보");

            var dirs = Directory.GetDirectories(curdir); // 현재 디렉토리의 모든 디렉토리를 불러오겠다. string[]

            foreach (var dir in dirs) 
            {
                var dirInfo = new DirectoryInfo(dir);

                Console.Write(dirInfo.Name);
                Console.WriteLine(" [{0}]",dirInfo.Attributes); // 현재 디렉터리의 특성을 알려줌
            }

            Console.WriteLine();
            Console.WriteLine("현재 디렉토리 파일정보");

            var files = Directory.GetFiles(curdir); // 디렉터리에 있는 파일 이름을 반환

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                Console.Write(fileInfo.Name);   
                Console.WriteLine(" [{0}]" , fileInfo.Attributes); // 파일의 특성을 알려줌
            }
            #endregion

            #region < 디렉토리/파일 직접 만들기 >

            string path = @"C:\Temp\Csharp_Bank"; // 만들고자 하는 폴더  // 구분자 '/' 도 가능! 업데이트된 C언어 두둥
            string sfile = "Test.log"; // 생성할 파일

            if (Directory.Exists(path)) // path라는 폴더가  있으면
            {
                Console.WriteLine("경로가 존재하여 파일을 생성합니다.");
                File.Create(path + @"\" + sfile); // C:\Temp\Csharp_Bank\Test.log
            }
            else // 경로가 없으면
            {
                Console.WriteLine($"해당경로가 없습니다. {path} 폴더를 생성합니다."); // 더욱더 쉬워진 데이터 포맷
                Directory.CreateDirectory(path);

                Console.WriteLine("경로를 생성하여 파일을 생성합니다.");
                File.Create(path + @"\" + sfile);
            }
           
            #endregion
        }
    }
}
