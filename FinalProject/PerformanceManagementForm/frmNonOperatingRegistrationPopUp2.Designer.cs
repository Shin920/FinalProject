
namespace FinalProject
{
    partial class frmNonOperatingRegistrationPopUp2
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
            this.cboNopDetailName = new System.Windows.Forms.ComboBox();
            this.cboWorkPlace = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNopType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNopDetailCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorkPlaceCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grbConditions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(814, 399);
            // 
            // grbConditions
            // 
            this.grbConditions.Controls.Add(this.cboNopDetailName);
            this.grbConditions.Controls.Add(this.cboWorkPlace);
            this.grbConditions.Controls.Add(this.numericUpDown1);
            this.grbConditions.Controls.Add(this.txtNote);
            this.grbConditions.Controls.Add(this.label8);
            this.grbConditions.Controls.Add(this.label7);
            this.grbConditions.Controls.Add(this.txtNopType);
            this.grbConditions.Controls.Add(this.label6);
            this.grbConditions.Controls.Add(this.txtNopDetailCode);
            this.grbConditions.Controls.Add(this.label5);
            this.grbConditions.Controls.Add(this.label4);
            this.grbConditions.Controls.Add(this.txtWorkPlaceCode);
            this.grbConditions.Controls.Add(this.label3);
            this.grbConditions.Controls.Add(this.label2);
            this.grbConditions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(126, 30);
            this.lblTitle.Text = "비가동 등록";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnSave);
            // 
            // cboNopDetailName
            // 
            this.cboNopDetailName.FormattingEnabled = true;
            this.cboNopDetailName.Location = new System.Drawing.Point(171, 152);
            this.cboNopDetailName.Name = "cboNopDetailName";
            this.cboNopDetailName.Size = new System.Drawing.Size(133, 23);
            this.cboNopDetailName.TabIndex = 151;
            this.cboNopDetailName.SelectedIndexChanged += new System.EventHandler(this.cboNopDetailName_SelectedIndexChanged);
            // 
            // cboWorkPlace
            // 
            this.cboWorkPlace.FormattingEnabled = true;
            this.cboWorkPlace.Location = new System.Drawing.Point(171, 45);
            this.cboWorkPlace.Name = "cboWorkPlace";
            this.cboWorkPlace.Size = new System.Drawing.Size(133, 23);
            this.cboWorkPlace.TabIndex = 150;
            this.cboWorkPlace.SelectedIndexChanged += new System.EventHandler(this.cboWorkPlace_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(535, 88);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(133, 23);
            this.numericUpDown1.TabIndex = 149;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(535, 152);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(206, 104);
            this.txtNote.TabIndex = 148;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(432, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 147;
            this.label8.Text = "비고";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label7.Location = new System.Drawing.Point(432, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 146;
            this.label7.Text = "비가동시간";
            // 
            // txtNopType
            // 
            this.txtNopType.Location = new System.Drawing.Point(535, 45);
            this.txtNopType.Name = "txtNopType";
            this.txtNopType.Size = new System.Drawing.Size(133, 23);
            this.txtNopType.TabIndex = 145;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label6.Location = new System.Drawing.Point(434, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 144;
            this.label6.Text = "발생유형";
            // 
            // txtNopDetailCode
            // 
            this.txtNopDetailCode.Location = new System.Drawing.Point(171, 207);
            this.txtNopDetailCode.Name = "txtNopDetailCode";
            this.txtNopDetailCode.Size = new System.Drawing.Size(212, 23);
            this.txtNopDetailCode.TabIndex = 143;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label5.Location = new System.Drawing.Point(39, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 142;
            this.label5.Text = "작업장코드";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label4.Location = new System.Drawing.Point(39, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 141;
            this.label4.Text = "비가동상세분류명";
            // 
            // txtWorkPlaceCode
            // 
            this.txtWorkPlaceCode.Location = new System.Drawing.Point(171, 100);
            this.txtWorkPlaceCode.Name = "txtWorkPlaceCode";
            this.txtWorkPlaceCode.Size = new System.Drawing.Size(212, 23);
            this.txtWorkPlaceCode.TabIndex = 140;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(39, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 139;
            this.label3.Text = "비가동상세분류코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label2.Location = new System.Drawing.Point(39, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 138;
            this.label2.Text = "작업장명";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClose.Location = new System.Drawing.Point(270, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 26);
            this.btnClose.TabIndex = 121;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(196, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 28);
            this.btnSave.TabIndex = 120;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmNonOperatingRegistrationPopUp2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(814, 400);
            this.Name = "frmNonOperatingRegistrationPopUp2";
            this.Text = "비가동 등록";
            this.Load += new System.EventHandler(this.frmNonOperatingRegistrationPopUp2_Load);
            this.panel1.ResumeLayout(false);
            this.grbConditions.ResumeLayout(false);
            this.grbConditions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNopDetailName;
        private System.Windows.Forms.ComboBox cboWorkPlace;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNopType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNopDetailCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWorkPlaceCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnSave;
    }
}
