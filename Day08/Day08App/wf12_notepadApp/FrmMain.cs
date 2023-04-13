using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf12_notepadApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false; // 여러파일 선택안되도록 함
            if(dialog.ShowDialog() == DialogResult.OK) // 대화상자가 반환되면?
            {
                string fileName = dialog.FileName;
                TxtPath.Text = dialog.FileName;

                FileStream stream = null;
                StreamReader reader = null;

                try
                {
                    stream = new FileStream(fileName, FileMode.Open, FileAccess.Read); // FileStream 쓰면 좀더 다양한 옵션 처리
                    reader = new StreamReader(stream, Encoding.UTF8);

                    // 몽땅 읽겠어!
                    RtbNote.Text = reader.ReadToEnd();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"오류! {ex.Message}", "Notdpad v0.1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    reader.Close();
                    stream.Close();
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string fileName = TxtPath.Text; // 열었던 파일 위치

            FileStream stream = null;
            StreamWriter writer = null;

            try
            {
                stream = new FileStream(fileName, FileMode.Truncate, FileAccess.Write);
                writer = new StreamWriter(stream, Encoding.UTF8);

                writer.WriteLine(RtbNote.Text);
                writer.Flush(); // 버퍼의 데이터를 해당 스트림에 전송하는 일을 함

                MessageBox.Show("저장되었습니다", "Notdpad v0.1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류! {ex.Message}", "Notdpad v0.1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
        }
    }
}
