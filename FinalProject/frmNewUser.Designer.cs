
namespace FinalProject
{
    partial class frmNewUser
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwdR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.lblPwdWrong = new System.Windows.Forms.Label();
            this.lblBadID = new System.Windows.Forms.Label();
            this.lblIsPhone = new System.Windows.Forms.Label();
            this.lblGoodID = new System.Windows.Forms.Label();
            this.lblPwdWarning = new System.Windows.Forms.Label();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboGroup = new System.Windows.Forms.ComboBox();
            this.cboEmail = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.grbConditions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(886, 400);
            // 
            // grbConditions
            // 
            this.grbConditions.Controls.Add(this.cboEmail);
            this.grbConditions.Controls.Add(this.cboGroup);
            this.grbConditions.Controls.Add(this.label8);
            this.grbConditions.Controls.Add(this.label9);
            this.grbConditions.Controls.Add(this.label6);
            this.grbConditions.Controls.Add(this.txtEmail2);
            this.grbConditions.Controls.Add(this.lblPwdWarning);
            this.grbConditions.Controls.Add(this.lblGoodID);
            this.grbConditions.Controls.Add(this.lblIsPhone);
            this.grbConditions.Controls.Add(this.lblBadID);
            this.grbConditions.Controls.Add(this.lblPwdWrong);
            this.grbConditions.Controls.Add(this.btnPost);
            this.grbConditions.Controls.Add(this.btnCheck);
            this.grbConditions.Controls.Add(this.txtAddr1);
            this.grbConditions.Controls.Add(this.txtAddr2);
            this.grbConditions.Controls.Add(this.txtPhone);
            this.grbConditions.Controls.Add(this.label7);
            this.grbConditions.Controls.Add(this.txtZipCode);
            this.grbConditions.Controls.Add(this.txtEmail);
            this.grbConditions.Controls.Add(this.label5);
            this.grbConditions.Controls.Add(this.txtPwdR);
            this.grbConditions.Controls.Add(this.label4);
            this.grbConditions.Controls.Add(this.txtPwd);
            this.grbConditions.Controls.Add(this.label2);
            this.grbConditions.Controls.Add(this.label1);
            this.grbConditions.Controls.Add(this.txtID);
            this.grbConditions.Controls.Add(this.label3);
            this.grbConditions.Controls.Add(this.txtName);
            this.grbConditions.Size = new System.Drawing.Size(854, 276);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(103, 30);
            this.lblTitle.Text = "신규등록";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Location = new System.Drawing.Point(532, 357);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(121, 97);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(201, 23);
            this.txtID.TabIndex = 22;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(55, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "아이디";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 23);
            this.txtName.TabIndex = 19;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(67, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "이름";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(121, 174);
            this.txtPwd.MaxLength = 16;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(201, 23);
            this.txtPwd.TabIndex = 25;
            this.txtPwd.Leave += new System.EventHandler(this.txtPwd_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label2.Location = new System.Drawing.Point(43, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "비밀번호";
            // 
            // txtPwdR
            // 
            this.txtPwdR.Location = new System.Drawing.Point(121, 220);
            this.txtPwdR.MaxLength = 16;
            this.txtPwdR.Name = "txtPwdR";
            this.txtPwdR.PasswordChar = '*';
            this.txtPwdR.Size = new System.Drawing.Size(201, 23);
            this.txtPwdR.TabIndex = 27;
            this.txtPwdR.Leave += new System.EventHandler(this.txtPwdR_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label4.Location = new System.Drawing.Point(3, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "비밀번호 재확인";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(463, 84);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(114, 23);
            this.txtEmail.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label5.Location = new System.Drawing.Point(394, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "E-Mail";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(463, 135);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.ReadOnly = true;
            this.txtZipCode.Size = new System.Drawing.Size(114, 23);
            this.txtZipCode.TabIndex = 30;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(463, 35);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(149, 23);
            this.txtPhone.TabIndex = 33;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label7.Location = new System.Drawing.Point(380, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "전화번호";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(198, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 28);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClose.Location = new System.Drawing.Point(272, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 26);
            this.btnClose.TabIndex = 64;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(463, 174);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.ReadOnly = true;
            this.txtAddr1.Size = new System.Drawing.Size(293, 23);
            this.txtAddr1.TabIndex = 35;
            // 
            // txtAddr2
            // 
            this.txtAddr2.Location = new System.Drawing.Point(463, 220);
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(293, 23);
            this.txtAddr2.TabIndex = 34;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCheck.Location = new System.Drawing.Point(244, 142);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(78, 26);
            this.btnCheck.TabIndex = 65;
            this.btnCheck.Text = "중복체크";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPost.BackColor = System.Drawing.Color.White;
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPost.Location = new System.Drawing.Point(608, 133);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(108, 26);
            this.btnPost.TabIndex = 66;
            this.btnPost.Text = "우편번호 찾기";
            this.btnPost.UseVisualStyleBackColor = false;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // lblPwdWrong
            // 
            this.lblPwdWrong.AutoSize = true;
            this.lblPwdWrong.ForeColor = System.Drawing.Color.Red;
            this.lblPwdWrong.Location = new System.Drawing.Point(152, 246);
            this.lblPwdWrong.Name = "lblPwdWrong";
            this.lblPwdWrong.Size = new System.Drawing.Size(170, 15);
            this.lblPwdWrong.TabIndex = 67;
            this.lblPwdWrong.Text = "비밀번호가 일치하지않습니다.";
            this.lblPwdWrong.Visible = false;
            // 
            // lblBadID
            // 
            this.lblBadID.AutoSize = true;
            this.lblBadID.ForeColor = System.Drawing.Color.Red;
            this.lblBadID.Location = new System.Drawing.Point(147, 123);
            this.lblBadID.Name = "lblBadID";
            this.lblBadID.Size = new System.Drawing.Size(150, 15);
            this.lblBadID.TabIndex = 68;
            this.lblBadID.Text = "이미 등록된 아이디입니다.";
            this.lblBadID.Visible = false;
            // 
            // lblIsPhone
            // 
            this.lblIsPhone.AutoSize = true;
            this.lblIsPhone.Location = new System.Drawing.Point(464, 61);
            this.lblIsPhone.Name = "lblIsPhone";
            this.lblIsPhone.Size = new System.Drawing.Size(237, 15);
            this.lblIsPhone.TabIndex = 69;
            this.lblIsPhone.Text = "전화번호는 \'-\'를 제외하고 입력해주십시오.";
            // 
            // lblGoodID
            // 
            this.lblGoodID.AutoSize = true;
            this.lblGoodID.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblGoodID.Location = new System.Drawing.Point(147, 123);
            this.lblGoodID.Name = "lblGoodID";
            this.lblGoodID.Size = new System.Drawing.Size(146, 15);
            this.lblGoodID.TabIndex = 70;
            this.lblGoodID.Text = "사용가능한 아이디입니다.";
            this.lblGoodID.Visible = false;
            // 
            // lblPwdWarning
            // 
            this.lblPwdWarning.AutoSize = true;
            this.lblPwdWarning.ForeColor = System.Drawing.Color.Red;
            this.lblPwdWarning.Location = new System.Drawing.Point(23, 202);
            this.lblPwdWarning.Name = "lblPwdWarning";
            this.lblPwdWarning.Size = new System.Drawing.Size(381, 15);
            this.lblPwdWarning.TabIndex = 71;
            this.lblPwdWarning.Text = "비밀번호는 8~16자리의 영문자, 숫자, 특수기호의 조합이어야 합니다.";
            this.lblPwdWarning.Visible = false;
            // 
            // txtEmail2
            // 
            this.txtEmail2.Location = new System.Drawing.Point(608, 84);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(114, 23);
            this.txtEmail2.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label6.Location = new System.Drawing.Point(404, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 73;
            this.label6.Text = "주소";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(583, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 15);
            this.label9.TabIndex = 74;
            this.label9.Text = "@";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label8.Location = new System.Drawing.Point(67, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 75;
            this.label8.Text = "부서";
            // 
            // cboGroup
            // 
            this.cboGroup.FormattingEnabled = true;
            this.cboGroup.Location = new System.Drawing.Point(121, 58);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(141, 23);
            this.cboGroup.TabIndex = 76;
            // 
            // cboEmail
            // 
            this.cboEmail.FormattingEnabled = true;
            this.cboEmail.Items.AddRange(new object[] {
            "직접입력",
            "naver.com",
            "hanmail.com",
            "nate.com",
            "daum.net"});
            this.cboEmail.Location = new System.Drawing.Point(728, 84);
            this.cboEmail.Name = "cboEmail";
            this.cboEmail.Size = new System.Drawing.Size(114, 23);
            this.cboEmail.TabIndex = 77;
            this.cboEmail.SelectedIndexChanged += new System.EventHandler(this.cboEmail_SelectedIndexChanged);
            // 
            // frmNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(886, 400);
            this.Name = "frmNewUser";
            this.Text = "신규등록";
            this.Load += new System.EventHandler(this.frmNewUser_Load);
            this.panel1.ResumeLayout(false);
            this.grbConditions.ResumeLayout(false);
            this.grbConditions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox txtID;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtName;
        protected System.Windows.Forms.TextBox txtEmail;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox txtPwdR;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtPwd;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtPhone;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox txtZipCode;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnPost;
        protected System.Windows.Forms.Button btnCheck;
        protected System.Windows.Forms.TextBox txtAddr1;
        protected System.Windows.Forms.TextBox txtAddr2;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.Label lblPwdWarning;
        private System.Windows.Forms.Label lblGoodID;
        private System.Windows.Forms.Label lblIsPhone;
        private System.Windows.Forms.Label lblBadID;
        private System.Windows.Forms.Label lblPwdWrong;
        protected System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboGroup;
        protected System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboEmail;
    }
}
