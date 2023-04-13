using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace wf13_bookrentalshop
{
    public partial class FrmLogin : Form
    {
        private bool isLogined = false; // 로그인 성공했는지 변수
        public FrmLogin()
        {
            InitializeComponent();
        }
        // 로그인 버튼이 클릭되면
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            isLogined = LoginProcess(); // 로그인을 성공해야만 true가 됨

            if (isLogined)
            {
                this.Close();
            }
        }

        // 취소버튼이 클릭되면
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            Environment.Exit(0);
        }

        // FrmLogin이 꺼지면!
        // 이게 없으면 X 버튼이나 Alt+f4 했을때 메인폼이 나타남
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLogined != true) // 로그인 안되었을 때 창을 닫으면 프로그램 모두 종료
            {
                Environment.Exit(0); // 가장 완벽하게 프로그램 종료
            }
        }

        // TxtID에서 엔터키 누르면 TxtPassword로 넘어감
        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TxtPassword.Focus(); // 패스워드로 포커스이동!
            }
        }

        // 엔터키 누르면 로그인이 되게 만들어주는 것!
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnLogin_Click(sender, e); // 버튼 클릭 이벤트핸들러 호출
            }
        }

        // 로그인 프로세스 핵심!
        // DB userTbl에서 정보확인 로그인 처리
        // DB에서 Notnull인 친구들은 다 검증해야행
        private bool LoginProcess()
        {
            // Validation check => 검증
            if (string.IsNullOrEmpty(TxtId.Text))
            {
                MessageBox.Show("아이디를 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("패스워드를 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string strUserId = "";
            string strPassword = "";

            try
            {
                // DB 처리 (MySQL이기 때문에 어려움)

                //MySqlConnection conn = new MySqlConnection("");
                //conn.Close(); => 구식 방식

                string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=12345";
                using (MySqlConnection conn = new MySqlConnection(connectionString)) // Close를 자동으로 해줌
                {
                    conn.Open();

                    #region < DB 쿼리를 위한 구성 >
                    string selQuery = @"SELECT userId
                                             , password
                                          FROM usertbl
                                         WHERE userID = @userID
                                           AND password = @password"; // TxtID, TxtPassword에 있는 값 치환
                    MySqlCommand selCmd = new MySqlCommand(selQuery, conn); // 쿼리문, connection
                    //@userId, @password 파마미터 할당
                    MySqlParameter prmUserID = new MySqlParameter("@userID", TxtId.Text);
                    MySqlParameter prmPassword = new MySqlParameter("@password", TxtPassword.Text);

                    selCmd.Parameters.Add(prmUserID);
                    selCmd.Parameters.Add(prmPassword);
                    #endregion

                    MySqlDataReader reader = selCmd.ExecuteReader(); // 실행한 다음에 userIde, password
                    if (reader.Read())
                    {

                        strUserId = reader["userId"] != null ? reader["userId"].ToString() : "-"; // 값이 널이아니면 ToString()
                        strPassword = reader["password"] != null ? reader["password"].ToString() : "--";

                        return true;
                    }  // conn.Close();
                    else
                    {
                        MessageBox.Show("로그인 정보가 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적인 오류 : {ex.Message}", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
