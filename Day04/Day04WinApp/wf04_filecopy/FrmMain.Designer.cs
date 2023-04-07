﻿namespace wf04_filecopy
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnFindSource = new System.Windows.Forms.Button();
            this.TxtSource = new System.Windows.Forms.TextBox();
            this.TxtTarget = new System.Windows.Forms.TextBox();
            this.BtnFindTarget = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAsyncCopy = new System.Windows.Forms.Button();
            this.PgbCopy = new System.Windows.Forms.ProgressBar();
            this.BtnSyncCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source :";
            // 
            // BtnFindSource
            // 
            this.BtnFindSource.Location = new System.Drawing.Point(333, 14);
            this.BtnFindSource.Name = "BtnFindSource";
            this.BtnFindSource.Size = new System.Drawing.Size(41, 23);
            this.BtnFindSource.TabIndex = 2;
            this.BtnFindSource.Text = "...";
            this.BtnFindSource.UseVisualStyleBackColor = true;
            this.BtnFindSource.Click += new System.EventHandler(this.BtnFindSource_Click);
            // 
            // TxtSource
            // 
            this.TxtSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtSource.Location = new System.Drawing.Point(66, 14);
            this.TxtSource.Name = "TxtSource";
            this.TxtSource.ReadOnly = true;
            this.TxtSource.Size = new System.Drawing.Size(260, 23);
            this.TxtSource.TabIndex = 1;
            this.TxtSource.TabStop = false;
            // 
            // TxtTarget
            // 
            this.TxtTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtTarget.Location = new System.Drawing.Point(66, 43);
            this.TxtTarget.Name = "TxtTarget";
            this.TxtTarget.ReadOnly = true;
            this.TxtTarget.Size = new System.Drawing.Size(260, 23);
            this.TxtTarget.TabIndex = 3;
            this.TxtTarget.TabStop = false;
            // 
            // BtnFindTarget
            // 
            this.BtnFindTarget.Location = new System.Drawing.Point(333, 43);
            this.BtnFindTarget.Name = "BtnFindTarget";
            this.BtnFindTarget.Size = new System.Drawing.Size(41, 23);
            this.BtnFindTarget.TabIndex = 4;
            this.BtnFindTarget.Text = "...";
            this.BtnFindTarget.UseVisualStyleBackColor = true;
            this.BtnFindTarget.Click += new System.EventHandler(this.BtnFindTarget_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target :";
            // 
            // BtnAsyncCopy
            // 
            this.BtnAsyncCopy.Location = new System.Drawing.Point(66, 83);
            this.BtnAsyncCopy.Name = "BtnAsyncCopy";
            this.BtnAsyncCopy.Size = new System.Drawing.Size(97, 23);
            this.BtnAsyncCopy.TabIndex = 5;
            this.BtnAsyncCopy.Text = "Async Copy";
            this.BtnAsyncCopy.UseVisualStyleBackColor = true;
            this.BtnAsyncCopy.Click += new System.EventHandler(this.BtnAsyncCopy_Click);
            // 
            // PgbCopy
            // 
            this.PgbCopy.Location = new System.Drawing.Point(15, 124);
            this.PgbCopy.Name = "PgbCopy";
            this.PgbCopy.Size = new System.Drawing.Size(359, 23);
            this.PgbCopy.TabIndex = 6;
            // 
            // BtnSyncCopy
            // 
            this.BtnSyncCopy.Location = new System.Drawing.Point(229, 83);
            this.BtnSyncCopy.Name = "BtnSyncCopy";
            this.BtnSyncCopy.Size = new System.Drawing.Size(97, 23);
            this.BtnSyncCopy.TabIndex = 6;
            this.BtnSyncCopy.Text = "Sync Copy";
            this.BtnSyncCopy.UseVisualStyleBackColor = true;
            this.BtnSyncCopy.Click += new System.EventHandler(this.BtnSyncCopy_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 163);
            this.Controls.Add(this.BtnSyncCopy);
            this.Controls.Add(this.PgbCopy);
            this.Controls.Add(this.BtnAsyncCopy);
            this.Controls.Add(this.TxtTarget);
            this.Controls.Add(this.BtnFindTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtSource);
            this.Controls.Add(this.BtnFindSource);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Async File Copy";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnFindSource;
        private System.Windows.Forms.TextBox TxtSource;
        private System.Windows.Forms.TextBox TxtTarget;
        private System.Windows.Forms.Button BtnFindTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAsyncCopy;
        private System.Windows.Forms.ProgressBar PgbCopy;
        private System.Windows.Forms.Button BtnSyncCopy;
    }
}

