namespace wf05_login
{
    partial class Frmmain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.Lblsuccess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.Location = new System.Drawing.Point(25, 42);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(41, 12);
            this.LblId.TabIndex = 0;
            this.LblId.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "패스워드";
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(84, 39);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(119, 21);
            this.TxtId.TabIndex = 2;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(84, 71);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(119, 21);
            this.TxtPassword.TabIndex = 3;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(128, 120);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "로그인";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // Lblsuccess
            // 
            this.Lblsuccess.AutoSize = true;
            this.Lblsuccess.Location = new System.Drawing.Point(126, 155);
            this.Lblsuccess.Name = "Lblsuccess";
            this.Lblsuccess.Size = new System.Drawing.Size(9, 12);
            this.Lblsuccess.TabIndex = 5;
            this.Lblsuccess.Text = " ";
            // 
            // Frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 177);
            this.Controls.Add(this.Lblsuccess);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frmmain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Label Lblsuccess;
    }
}

