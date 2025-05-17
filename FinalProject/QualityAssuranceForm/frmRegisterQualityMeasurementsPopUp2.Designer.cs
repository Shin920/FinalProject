
namespace FinalProject
{
    partial class frmRegisterQualityMeasurementsPopUp2
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
            this.nmrCheckResult = new System.Windows.Forms.NumericUpDown();
            this.txtInstructionNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCheckItemCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProcessCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grbConditions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCheckResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grbConditions
            // 
            this.grbConditions.Controls.Add(this.nmrCheckResult);
            this.grbConditions.Controls.Add(this.txtInstructionNum);
            this.grbConditions.Controls.Add(this.label6);
            this.grbConditions.Controls.Add(this.label5);
            this.grbConditions.Controls.Add(this.txtCheckItemCode);
            this.grbConditions.Controls.Add(this.label4);
            this.grbConditions.Controls.Add(this.txtProcessCode);
            this.grbConditions.Controls.Add(this.label3);
            this.grbConditions.Controls.Add(this.txtProductCode);
            this.grbConditions.Controls.Add(this.label2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(168, 30);
            this.lblTitle.Text = "품질측정값 추가";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnSave);
            // 
            // nmrCheckResult
            // 
            this.nmrCheckResult.Location = new System.Drawing.Point(483, 109);
            this.nmrCheckResult.Name = "nmrCheckResult";
            this.nmrCheckResult.Size = new System.Drawing.Size(159, 23);
            this.nmrCheckResult.TabIndex = 151;
            // 
            // txtInstructionNum
            // 
            this.txtInstructionNum.Location = new System.Drawing.Point(483, 53);
            this.txtInstructionNum.Name = "txtInstructionNum";
            this.txtInstructionNum.Size = new System.Drawing.Size(159, 23);
            this.txtInstructionNum.TabIndex = 150;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 149;
            this.label6.Text = "작업지시번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 148;
            this.label5.Text = "공정코드";
            // 
            // txtCheckItemCode
            // 
            this.txtCheckItemCode.Location = new System.Drawing.Point(135, 172);
            this.txtCheckItemCode.Name = "txtCheckItemCode";
            this.txtCheckItemCode.Size = new System.Drawing.Size(159, 23);
            this.txtCheckItemCode.TabIndex = 147;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 146;
            this.label4.Text = "항목코드";
            // 
            // txtProcessCode
            // 
            this.txtProcessCode.Location = new System.Drawing.Point(135, 108);
            this.txtProcessCode.Name = "txtProcessCode";
            this.txtProcessCode.Size = new System.Drawing.Size(159, 23);
            this.txtProcessCode.TabIndex = 145;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(393, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 144;
            this.label3.Text = "측정값";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(135, 53);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(159, 23);
            this.txtProductCode.TabIndex = 143;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 142;
            this.label2.Text = "품목코드";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClose.Location = new System.Drawing.Point(270, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 26);
            this.btnClose.TabIndex = 123;
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
            this.btnSave.Location = new System.Drawing.Point(199, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 28);
            this.btnSave.TabIndex = 122;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmRegisterQualityMeasurementsPopUp2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(814, 400);
            this.Name = "frmRegisterQualityMeasurementsPopUp2";
            this.Text = "품질측정값 추가";
            this.panel1.ResumeLayout(false);
            this.grbConditions.ResumeLayout(false);
            this.grbConditions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmrCheckResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmrCheckResult;
        private System.Windows.Forms.TextBox txtInstructionNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCheckItemCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProcessCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnSave;
    }
}
