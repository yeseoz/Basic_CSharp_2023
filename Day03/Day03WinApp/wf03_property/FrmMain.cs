using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class FrmMain : Form
    {   
        Random rnd = new Random();
    
        public FrmMain() // 생성자는 왠만하면 건들디 말고 FrmMain_Load에 넣는게 좋음
        {
            // 위에 아무것도 넣지 말것
            InitializeComponent(); // form 그리고 들어가는 속성들 다 지정함 절대 손대면 안돼!
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GbxMain.Text = "컨트롤 학습"; // 이니셜 라이즈 위에 넣으면 반영 안됨
            var fonts = FontFamily.Families.ToList(); // 내 OS 폰트 이름을 다가져옴  // ToList => 컬렉션으로 바꿔줌
            foreach (var font in fonts) 
            {
                CboFontFamily.Items.Add(font.Name); 
            }

            // 글자크기 최소값 , 최대값 지정
            NudFontSize.Minimum = 5;
            NudFontSize.Maximum = 40;

            // 텍스트 박스 초기화
            TxtResult.Text = "Hello, WinForms!!";

            NudFontSize.Value = 9; // 기본값 
            
        }
        /// <summary>
        /// 글자 스타일, 크기, 글자체를 변경해주는 메서드
        /// </summary>
        private void ChangeFontStyle()
        {
            if (CboFontFamily.SelectedIndex < 0)
            {
                CboFontFamily.SelectedIndex = 279; // 디폴트를 나눔고딕으로 지정
            }

            FontStyle style = FontStyle.Regular; // 기본
            if(ChkBold.Checked == true) // Bold에 Check 되면 Bold체로 바뀜
            {
                style |= FontStyle.Bold; // Bit 연산 or
                Console.WriteLine(style); 
            }
            if(ChkItalic.Checked == true) // Italic에 Check되면 기울어짐
            {
                style |= FontStyle.Italic;
            }

            decimal fontSize = NudFontSize.Value; // fontSize는 NudFontSize의 Value값으로 변함

            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem, (float)fontSize, style); // TxtResult의 폰트 이름과, 폰트 사이즈와 , 폰트 스타일을 변경함
            // (string familyname, float emSize, Fontstyle style)

        }

        void ChangeIndent()
        {
            if (RdoNomal.Checked) // 라디오버튼 추가 이벤트 추가
            {
                TxtResult.Text = TxtResult.Text.Trim();
            }
            else if (RdoIndent.Checked)
            {
                TxtResult.Text = "    " + TxtResult.Text;
            }
        }


        private void CboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void NudFontSize_ValueChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PgbDummy.Value = TrbDummy.Value; 
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            // 자식창이 떠있는 동안 부모창에 접근할 수 없도록 하는 기능
            Form frm = new Form()
            {
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.AliceBlue,
                StartPosition = FormStartPosition.CenterParent,
            };
            frm.ShowDialog(); // 모달 방식으로 자식창 새로 띄우기 
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            // 자식창이 떠있어도 부모창에 접근할 수 있음

            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen, // 모달리스는 CenterParent가 안먹힘 
                BackColor = Color.GreenYellow
            };
            frm.Show(); // 모달리스 방식으로 자식창 띄움
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            // 기본적으로 메시지박스는 모달임
            //MessageBox.Show(TxtResult.Text); // 기본
            //MessageBox.Show(TxtResult.Text, caption: "메시지창"); // 캡션 사용
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo); // 버튼 
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo,MessageBoxIcon.Information); // 아이콘 추가
            // 여기까지는 알고 있어야 함..!
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Information,MessageBoxDefaultButton.Button2); // 기본포커스 버튼 
            MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2,MessageBoxOptions.RightAlign); //디폴트 버튼
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            // 리스트 뷰는 루트가 있어야함
            TrvDummy.Nodes.Add(rnd.Next(50).ToString()); // int => string
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            // 루트에 자식을 추가하는 것
            if(TrvDummy.SelectedNode.Nodes !=null)
            {
                TrvDummy.SelectedNode.Nodes.Add(rnd.Next(50, 100).ToString());
                TrvDummy.SelectedNode.Expand(); // 트리노드 하위것 펼쳐주기 <=> .Collapse
                TreeToList();
            }
        }

        // 트리뷰에 있는것들을 리스트 뷰에서 보여줌
        void TreeToList()
        {
            LsvDummy.Items.Clear(); // 리스트뷰, 트리뷰 모든 아이템을 제거 초기화 메서드
            foreach (TreeNode item in TrvDummy.Nodes)
            {
                TreeToList(item);
            }
        }

        private void TreeToList(TreeNode item)
        {
            // 어려운 부분
            LsvDummy.Items.Add(
                new ListViewItem(new[] { item.Text, item.FullPath.ToString() }));

            foreach(TreeNode node in item.Nodes)
            {
                TreeToList(node); // 재귀호출
            }
        }

        private void RboNomal_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void RboIndent_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }


        private void BtnLoad_Click(object sender, EventArgs e)
        {
            PcbDummy.Image = Bitmap.FromFile("cat.png");
        }

        private void PcbDummy_Click(object sender, EventArgs e)
        {
            if(PcbDummy.SizeMode == PictureBoxSizeMode.Zoom)
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
