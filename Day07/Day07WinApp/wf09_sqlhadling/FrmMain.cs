using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf09_sqlhadling
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 1. 연결문자열 생성(제일중요!)
            string connectionString = "Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=12345;";
            // DB연결을 위해서 Connection 객체를 생성
            SqlConnection conn = new SqlConnection(connectionString); // 연결문자열없이 객체 생성X // 첫번째방법
                                                                      // conn.ConnectionString = connectionString; // 두번째방법

            // 3. 객체를 통해서 DB연결
            conn.Open(); // close를 만날때까지 계속 연결

            // 4. DB처리를 위한 쿼리 작성
            string selQuery = @"SELECT CustomerID
                                     , CompanyName
                                     , ContactName
                                     , ContactTitle
                                     , Address
                                     , City
                                     , Region
                                     , PostalCode
                                     , Country
                                     , Phone
                                     , Fax
                                  FROM Customers";

            // 5. SqlDapaAdapter 생성
            SqlDataAdapter adapter = new SqlDataAdapter(selQuery, conn);

            // 테이터셋으로 전달
            DataSet ds = new DataSet(); // 테이블 여러개 담을 수 있음
            adapter.Fill(ds);

            // 7. 데이터그리드뷰에 바인딩하기 위한 BindingSource 생성
            BindingSource source = new BindingSource();

            // 8. 데이터그리디뷰의 DataSource에 데이터셋을 할당
            source.DataSource = ds.Tables[0]; // 0번째사용(Customers)
            DgvNorthwind.DataSource = source;

            // 9. DB close
            conn.Close();
        }
    }
}
