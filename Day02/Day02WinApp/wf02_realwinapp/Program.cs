using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf02_realwinapp
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 Entry Point입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Systme.Windows.Forms 안에 Application 있음
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain()); // 프로그램 실행되게 해주는 거
        }
    }
}
