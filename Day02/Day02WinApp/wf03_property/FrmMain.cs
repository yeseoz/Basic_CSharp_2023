using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class FrmMain : Form
    {
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
            if (CboFontFamily.SelectedIndex < 0) return;

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
    }
}
