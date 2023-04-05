using System;



namespace wf01_simplewinapp
{
    class Program :System.Windows.Forms.Form // Form 클래스 상속
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First WinApp");
            System.Windows.Forms.Application.Run(new Program());
        }
    }
}
