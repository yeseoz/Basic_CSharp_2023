using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using wf13_bookrentalshop.Helpers;

namespace wf13_bookrentalshop
{
    public partial class FrmBooks : Form
    {
        #region < 멤버변수 >
        bool isNew = false; // false(UPDATE) / true(INSERT)
        #endregion

        #region < 생성자 >
        public FrmBooks()
        {
            InitializeComponent();
        }
        #endregion

        #region < 이벤트 핸들러 >
        private void FrmGenre_Load(object sender, EventArgs e)
        {
            // DB divtbl 데이터 조회 DgvResult 뿌림
            isNew = true;
            RefreshData();
            LoadBboData(); // 콤보박스ㅡ에 들어갈 데이터 로드
            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
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

            // FK 제약조건으로 지울수 없는 데이터인지 먼저 확인
            using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string strChkQuery = @"SELECT COUNT(*) FROM rentaltbl WHERE bookIdx = @bookIdx";
                MySqlCommand chkCmd = new MySqlCommand(strChkQuery, conn);
                MySqlParameter prmDivision = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                chkCmd.Parameters.Add(prmDivision);

                var result = chkCmd.ExecuteScalar(); // Scalar 커리를 실행한다음 첫번째 컬럼 값을 가지고 나와서 리턴해줌 컬럼하나만있으면 ExecuteScalar 쓰면 좋음

                if (result.ToString() != "0")
                {
                    MessageBox.Show("이미 대여중인 책입니다.", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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

                TxtBookIdx.Text = selData.Cells[0].Value.ToString();
                TxtAuthor.Text = selData.Cells[1].Value.ToString();

                CboDivision.SelectedValue = selData.Cells[2].Value; //B001 == B001
                // sleData.Cell[3] 사용 안함
                TxtNames.Text = selData.Cells[4].Value.ToString();
                DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
                TxtIsbn.Text = selData.Cells[6].Value.ToString();
                NudPrice.Text = selData.Cells[7].Value.ToString();
                isNew = false; // 수정

            }
        }

        private void TxtDivision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TxtAuthor.Focus(); // 패스워드로 포커스이동!
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
                    var selQuery = @"SELECT b.bookIdx
                                          , b.Author
                                          , b.Division
                                          , d.Names AS DivNames
                                          , b.Names
                                          , b.ReleaseDate
                                          , b.ISBN
                                          , b.Price
                                       FROM bookstbl AS b
                                      INNER JOIN divtbl AS d
	                                     ON b.Division = d.Division
                                      ORDER BY b.bookIdx ASC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl"); // divtbl으로 DataSet 접근가능

                    DgvResult.DataSource = ds.Tables[0];
                    // 데이터그리드뷰 컬럼 헤더 제목
                    DgvResult.Columns[0].HeaderText = "번호";
                    DgvResult.Columns[1].HeaderText = "저자명";
                    DgvResult.Columns[2].HeaderText = "책장르";
                    DgvResult.Columns[3].HeaderText = "책장르";
                    DgvResult.Columns[4].HeaderText = "책제목";
                    DgvResult.Columns[5].HeaderText = "출판일자";
                    DgvResult.Columns[6].HeaderText = "ISBN";
                    DgvResult.Columns[7].HeaderText = "책가격";
                    // 컬럼 넓이 또는 보이기
                    DgvResult.Columns[0].Width = 55;
                    DgvResult.Columns[2].Visible = false; // 안보이게
                    DgvResult.Columns[5].Width = 80;
                    DgvResult.Columns[7].Width = 80;
                    // 컬럼 데이터 정렬
                    DgvResult.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DgvResult.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DgvResult.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상정 오류 :{ex.Message}", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBboData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    var query = "SELECT Division, Names FROM divtbl";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while (reader.Read())
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString()); // (key) BB001, (value) 공포스릴러
                    }

                    // 콤보박스에 할당
                    CboDivision.DataSource = new BindingSource(temp, null); // divtbl은 null로 써도 무방
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadBboData() 비정상적 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            TxtNames.Text = TxtIsbn.Text = string.Empty;
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now; // 오늘날짜로 포기화
            NudPrice.Value = 0;
            TxtAuthor.Focus(); // 번호는 입력안함!
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
                        query = @"INSERT INTO bookstbl
                                       ( Author
                                       , Division
                                       , Names
                                       , ReleaseDate
                                       , ISBN
                                       , Price)
                                  VALUES
                                       (  @Author
                                       , @Division
                                       , @Names
                                       , @ReleaseDate
                                       , @ISBN
                                       , @Price)";
                    }
                    else
                    {
                        query = @"UPDATE bookstbl
                                     SET Author = @Author,
	                                     Division = @Division,
	                                     Names = @Names,
	                                     ReleaseDate = @ReleaseDate,
	                                     ISBN = @ISBN,
	                                     Price = @Price
                                   WHERE bookIdx = @bookIdx";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmAuthor = new MySqlParameter("@Author", TxtAuthor.Text);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", CboDivision.SelectedValue.ToString());
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    MySqlParameter prmReleaseData = new MySqlParameter("@ReleaseDate", DtpReleaseDate.Value);
                    MySqlParameter prmISBN = new MySqlParameter("@ISBN", TxtIsbn.Text);
                    MySqlParameter prmPrice = new MySqlParameter("@Price", NudPrice.Value);

                    cmd.Parameters.Add(prmAuthor);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);
                    cmd.Parameters.Add(prmReleaseData);
                    cmd.Parameters.Add(prmISBN);
                    cmd.Parameters.Add(prmPrice);

                    if(isNew== false) // 업데이트 할때는 bookIdx 파라미터를 반드시 추가해줘야함
                    {
                        MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);
                    }

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

                    var query = @"DELETE FROM bookstbl
                               WHERE bookIdx = @bookIdx";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmBookIdx = new MySqlParameter("@BookIdx", TxtBookIdx.Text);
                    cmd.Parameters.Add(prmBookIdx);

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

            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                //입력 검증 (Validation check)
                result = false;
                errorMsg += "● 저자명을 입력하세요.\r\n";
            }

            if (CboDivision.SelectedIndex < 0)
            {
                result = false;
                errorMsg += "● 장르를 선택하세요.\r\n";
            }

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                //입력 검증 (Validation check)
                result = false;
                errorMsg += "● 책제목을 입력하세요.\r\n";
            }

            if (DtpReleaseDate.Value == null)
            {
                //입력 검증 (Validation check)
                result = false;
                errorMsg += "● 출판일자를 선택하세요.\r\n";
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

        private void DgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvResult.ClearSelection(); // 최초에 첫번째열 첫번째 셸 선택되어 있는 것을 해제
        }
    }
}
