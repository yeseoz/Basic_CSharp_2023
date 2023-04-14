using System;
using System.Windows.Forms;

namespace wf13_bookrentalshop
{
    #region < 생성자 >
    public partial class FrmMain : Form
    {
        #region < 각화면 폼 >
        FrmGenre frmGenre = null;
        #endregion

        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region < 이벤트 핸들러 >

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }
        
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 전체 프로그램 종료!
        }

        private void MniGenre_Click(object sender, EventArgs e)
        {
            //FrmGenre frm = new FrmGenre();
            //frm.TopLevel = false;
            //this.Controls.Add(frm);
            //frm.Show();
            frmGenre = ShowActiveForm(frmGenre, typeof(FrmGenre)) as FrmGenre;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MniBookInfo_Click(object sender, EventArgs e)
        {

        }

        private void MniMember_Click(object sender, EventArgs e)
        {

        }

        private void MniRental_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private Form ShowActiveForm(Form form, Type type)
        {
            if (form == null) // 한번도 자식창을 안열었으면
            {
                form = (Form)Activator.CreateInstance(type); // 리플렉션으로 타입에 맞는 창을 새로 생성
                form.MdiParent = this; // frmMain이 MDI 부모
                form.WindowState = FormWindowState.Normal;
                form.Show();
            }
            else
            {
                if (form.IsDisposed) // 닫혔다 다시 열린 상태면
                {
                    form = (Form)Activator.CreateInstance(type); // 리플렉션으로 타입에 맞는 창을 새로 생성
                    form.MdiParent = this; // frmMain이 MDI 부모
                    form.WindowState = FormWindowState.Normal;
                    form.Show();
                }
                else // 열려있으면 활성화
                {
                    form.Activate(); // 화면이 있으면 그 화면을 활성화
                }
            }
            return form;
        }
    }
}
