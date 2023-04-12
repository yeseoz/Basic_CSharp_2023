using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf10_mysqlhabdling
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // MySql용 연결 문자열
            string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();

            string selQuery = @"SELECT memberIdx
	                                 , Names
                                     , Levels
                                     , Addr
                                     , Mobile
                                     , Email
                                  FROM membertbl";

            MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            // 바인딩 소스는 굳이 쓰지 않아도 됨
            DgvMember.DataSource = ds.Tables[0];

            conn.Close();
        }
    }
}
