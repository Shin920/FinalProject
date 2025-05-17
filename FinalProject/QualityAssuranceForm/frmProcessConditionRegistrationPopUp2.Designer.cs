
namespace FinalProject
{
    partial class frmProcessConditionRegistrationPopUp2
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
            this.nmrResult = new System.Windows.Forms.NumericUpDown();
            this.txtInstructionNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIChecktemCode = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.nmrResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grbConditions
            // 
            this.grbConditions.Controls.Add(this.nmrResult);
            this.grbConditions.Controls.Add(this.txtInstructionNum);
            this.grbConditions.Controls.Add(this.label6);
            this.grbConditions.Controls.Add(this.label5);
            this.grbConditions.Controls.Add(this.txtIChecktemCode);
            this.grbConditions.Controls.Add(this.label4);
            this.grbConditions.Controls.Add(this.txtProcessCode);
            this.grbConditions.Controls.Add(this.label3);
            this.grbConditions.Controls.Add(this.txtProductCode);
            this.grbConditions.Controls.Add(this.label2);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(188, 30);
            this.lblTitle.Text = "공정검사 측정추가";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnSave);
            // 
            // nmrResult
            // 
            this.nmrResult.Location = new System.Drawing.Point(478, 90);
            this.nmrResult.Name = "nmrResult";
            this.nmrResult.Size = new System.Drawing.Size(159, 23);
            this.nmrResult.TabIndex = 141;
            // 
            // txtInstructionNum
            // 
            this.txtInstructionNum.Location = new System.Drawing.Point(478, 34);
            this.txtInstructionNum.Name = "txtInstructionNum";
            this.txtInstructionNum.Size = new System.Drawing.Size(159, 23);
            this.txtInstructionNum.TabIndex = 140;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 139;
            this.label6.Text = "작업지시번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 138;
            this.label5.Text = "공정코드";
            // 
            // txtIChecktemCode
            // 
            this.txtIChecktemCode.Location = new System.Drawing.Point(130, 153);
            this.txtIChecktemCode.Name = "txtIChecktemCode";
            this.txtIChecktemCode.Size = new System.Drawing.Size(159, 23);
            this.txtIChecktemCode.TabIndex = 137;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 136;
            this.label4.Text = "항목코드";
            // 
            // txtProcessCode
            // 
            this.txtProcessCode.Location = new System.Drawing.Point(130, 89);
            this.txtProcessCode.Name = "txtProcessCode";
            this.txtProcessCode.Size = new System.Drawing.Size(159, 23);
            this.txtProcessCode.TabIndex = 135;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(388, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 134;
            this.label3.Text = "측정값";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(130, 34);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(159, 23);
            this.txtProductCode.TabIndex = 133;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 132;
            this.label2.Text = "품목코드";
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
            this.btnSave.Location = new System.Drawing.Point(199, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 28);
            this.btnSave.TabIndex = 120;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmProcessConditionRegistrationPopUp2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(814, 400);
            this.Name = "frmProcessConditionRegistrationPopUp2";
            this.Text = "공정검사 측정추가";
            this.Load += new System.EventHandler(this.frmProcessConditionRegistrationPopUp2_Load);
            this.panel1.ResumeLayout(false);
            this.grbConditions.ResumeLayout(false);
            this.grbConditions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmrResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmrResult;
        private System.Windows.Forms.TextBox txtInstructionNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIChecktemCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProcessCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnSave;
    }
}
