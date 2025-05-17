
namespace FinalProject
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkramenRemember = new System.Windows.Forms.CheckBox();
            this.lblBar = new System.Windows.Forms.Label();
            this.lblSignUp = new System.Windows.Forms.Label();
            this.lblFindPwd = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBack = new System.Windows.Forms.Label();
            this.txtEmailS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIDS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPwdSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(47, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 21);
            this.label6.TabIndex = 66;
            this.label6.Text = "👥 아이디";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtID.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtID.Location = new System.Drawing.Point(152, 40);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(209, 29);
            this.txtID.TabIndex = 6;
            this.txtID.Text = "abcd123";
            // 
            // txtpassword
            // 
            this.txtpassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtpassword.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtpassword.Location = new System.Drawing.Point(152, 101);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(209, 29);
            this.txtpassword.TabIndex = 7;
            this.txtpassword.Text = "abcd1234#";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(34, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 70;
            this.label2.Text = "🔒 비밀번호";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnLogin);
            this.pnlSearch.Controls.Add(this.chkramenRemember);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.txtpassword);
            this.pnlSearch.Controls.Add(this.txtID);
            this.pnlSearch.Controls.Add(this.label6);
            this.pnlSearch.Location = new System.Drawing.Point(9, 265);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(408, 182);
            this.pnlSearch.TabIndex = 52;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(46, 136);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(313, 38);
            this.btnLogin.TabIndex = 62;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkramenRemember
            // 
            this.chkramenRemember.AutoSize = true;
            this.chkramenRemember.ForeColor = System.Drawing.Color.Gray;
            this.chkramenRemember.Location = new System.Drawing.Point(247, 79);
            this.chkramenRemember.Name = "chkramenRemember";
            this.chkramenRemember.Size = new System.Drawing.Size(112, 16);
            this.chkramenRemember.TabIndex = 71;
            this.chkramenRemember.Text = "아이디 저장하기";
            this.chkramenRemember.UseVisualStyleBackColor = true;
            // 
            // lblBar
            // 
            this.lblBar.AutoSize = true;
            this.lblBar.ForeColor = System.Drawing.Color.Gray;
            this.lblBar.Location = new System.Drawing.Point(217, 450);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(11, 12);
            this.lblBar.TabIndex = 63;
            this.lblBar.Text = "|";
            this.lblBar.Visible = false;
            // 
            // lblSignUp
            // 
            this.lblSignUp.AutoSize = true;
            this.lblSignUp.ForeColor = System.Drawing.Color.Gray;
            this.lblSignUp.Location = new System.Drawing.Point(234, 450);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(53, 12);
            this.lblSignUp.TabIndex = 64;
            this.lblSignUp.Text = "회원가입";
            this.lblSignUp.Visible = false;
            this.lblSignUp.Click += new System.EventHandler(this.lblSignUp_Click);
            // 
            // lblFindPwd
            // 
            this.lblFindPwd.AutoSize = true;
            this.lblFindPwd.ForeColor = System.Drawing.Color.Gray;
            this.lblFindPwd.Location = new System.Drawing.Point(126, 450);
            this.lblFindPwd.Name = "lblFindPwd";
            this.lblFindPwd.Size = new System.Drawing.Size(81, 12);
            this.lblFindPwd.TabIndex = 65;
            this.lblFindPwd.Text = "비밀번호 찾기";
            this.lblFindPwd.Visible = false;
            this.lblFindPwd.Click += new System.EventHandler(this.lblFindPwd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblBack);
            this.panel1.Controls.Add(this.txtEmailS);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtIDS);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnPwdSearch);
            this.panel1.Location = new System.Drawing.Point(12, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 215);
            this.panel1.TabIndex = 66;
            this.panel1.Visible = false;
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.ForeColor = System.Drawing.Color.Gray;
            this.lblBack.Location = new System.Drawing.Point(302, 188);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(53, 12);
            this.lblBack.TabIndex = 206;
            this.lblBack.Text = "뒤로가기";
            this.lblBack.Visible = false;
            this.lblBack.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtEmailS
            // 
            this.txtEmailS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmailS.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtEmailS.Location = new System.Drawing.Point(142, 99);
            this.txtEmailS.Name = "txtEmailS";
            this.txtEmailS.Size = new System.Drawing.Size(209, 29);
            this.txtEmailS.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(37, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 21);
            this.label7.TabIndex = 68;
            this.label7.Text = "📧 이메일";
            // 
            // txtIDS
            // 
            this.txtIDS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtIDS.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtIDS.Location = new System.Drawing.Point(142, 47);
            this.txtIDS.Name = "txtIDS";
            this.txtIDS.Size = new System.Drawing.Size(209, 29);
            this.txtIDS.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(37, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 21);
            this.label3.TabIndex = 66;
            this.label3.Text = "👥 아이디";
            // 
            // btnPwdSearch
            // 
            this.btnPwdSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPwdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPwdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPwdSearch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPwdSearch.ForeColor = System.Drawing.Color.White;
            this.btnPwdSearch.Location = new System.Drawing.Point(41, 147);
            this.btnPwdSearch.Name = "btnPwdSearch";
            this.btnPwdSearch.Size = new System.Drawing.Size(313, 38);
            this.btnPwdSearch.TabIndex = 63;
            this.btnPwdSearch.Text = "비밀번호찾기";
            this.btnPwdSearch.UseVisualStyleBackColor = false;
            this.btnPwdSearch.Click += new System.EventHandler(this.btnPwdSearch_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(437, 475);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lblBar);
            this.Controls.Add(this.lblSignUp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFindPwd);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.CheckBox chkramenRemember;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblBar;
        private System.Windows.Forms.Label lblSignUp;
        private System.Windows.Forms.Label lblFindPwd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.TextBox txtEmailS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIDS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPwdSearch;
    }
}