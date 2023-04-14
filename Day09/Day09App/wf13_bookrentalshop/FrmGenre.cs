using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace wf13_bookrentalshop
{
    public partial class FrmGenre : Form
    {
        #region < 멤버변수 >
        bool isNew = false; // false(UPDATE) / true(INSERT)
        #endregion

        #region < 생성자 >
        public FrmGenre()
        {
            InitializeComponent();
        }
        #endregion

        #region < 이벤트 핸들러 >
        private void FrmGenre_Load(object sender, EventArgs e)
        {
            // DB divtbl 데이터 조회 DgvResult 뿌림
            RefreshData();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
            isNew = true; // 신규
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckBalidation() != true)
            {
                return;
            }
            SaveData(); //데이터 저장/ 수정
            RefreshData(); // 한번이상 쓰이는 로직은! 메서드화!
            ClearInputs(); // 입력창 클리어

        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (isNew == true) // 신규 => 삭제 불가능
            {
                // 신규 일때 삭제 버튼을 누르면
                MessageBox.Show("삭제할 데이터를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // 삭제여부를 물을때 아니오를 누르면 삭제진행 취소
                return;
            }

            // Yes를 누르면 계속 진행
            // SaveData()에 있는 로직 복사 -> 수정
            DeleteData(); // 데이터 삭제 처리
            RefreshData(); // 지우고나서 재조회
            ClearInputs(); // 입력창 데이터 지우기
        }

        // 그리드 뷰 클릭하면 발생하는 이벤트
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택안하면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex];
                //Debug.WriteLine(selData.ToString()); // 출력에 데이터를 띄워줌!
                Debug.WriteLine(selData.Cells[0].Value);
                Debug.WriteLine(selData.Cells[1].Value);

                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();

                TxtDivision.ReadOnly = true; // PK는 수정하면 안됨

                isNew = false; // 수정

            }
        }

        private void TxtDivision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TxtNames.Focus(); // 패스워드로 포커스이동!
            }
        }

        private void TxtNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnSave_Click(sender, e);
            }
        }
        #endregion

        #region < 커스텀 메서드 >
        private void RefreshData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    // 쿼리 작성
                    var selQuery = @"SELECT Division
                                          , Names
                                       FROM divtbl";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl"); // divtbl으로 DataSet 접근가능

                    // 1. DgvResult.DataSource = ds.Tables[0];
                    DgvResult.DataSource = ds;// 2. 
                    DgvResult.DataMember = "divtbl"; // 2.

                    DgvResult.Columns[0].HeaderText = "장르코드";
                    DgvResult.Columns[1].HeaderText = "장르명";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상정 오류 :{ex.Message}", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearInputs()
        {
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false; // 신규일땐 입력 가능
            TxtDivision.Focus();
            isNew = true; // 신규
        }

        // isNew = true InSERT / false UPDATE
        private void SaveData()
        {
            // INSERT부터 시작
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    var query = "";

                    if (isNew)
                    {
                        query = @"INSERT INTO divtbl
                                       VALUES
                                            ( @Division
		                                    , @Names )";
                    }
                    else
                    {
                        query = @"UPDATE divtbl
                                     SET Names = @Names
                                   WHERE Division = @Division";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);

                    var result = cmd.ExecuteNonQuery(); // Insert, Update, Delete => ExecuteNonQuery() => 돌려받을 쿼리가 없어서 결과만 돌려받음

                    if (result != 0)
                    {
                        MessageBox.Show("저장성공", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("저장 실패", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상정 오류 :{ex.Message}", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    var query = @"DELETE FROM divtbl
                               WHERE Division = @Division";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    cmd.Parameters.Add(prmDivision);

                    var result = cmd.ExecuteNonQuery(); // Insert, Update, Delete => ExecuteNonQuery() => 돌려받을 쿼리가 없어서 결과만 돌려받음

                    if (result != 0)
                    {
                        MessageBox.Show("삭제성공", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("삭제 실패", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 입력 검증
        private bool CheckBalidation()
        {
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                //입력 검증 (Validation check)
                result = false;
                errorMsg += "● 장르코드를 입력하세요\r\n";
            }

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "● 장르명을 입력하세요\r\n";
            }

            if (result == false)
            {
                MessageBox.Show(errorMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            else
            {
                return result;
            }
        }
        
        #endregion
    }
}
