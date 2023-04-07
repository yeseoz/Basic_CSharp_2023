using System;
using System.Windows.Forms;

namespace wf05_login
{
    public partial class Frmmain : Form
    {
        public Frmmain()
        {
            InitializeComponent();
        }

      
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "abcd" && TxtPassword.Text == "1234")
            {
                    Lblsuccess.Text = "로그인 성공";
            }
            else
            {
                Lblsuccess.Text = "로그인 실패";
            }
        }
    }
}
