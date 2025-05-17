
namespace FinalProject
{
    partial class frmPerformanceModify2
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
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInstructionNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInstructionCondition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInstructionDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResultQty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCalcQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtInsertQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWorkPlace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grbConditions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.txtNumber, 0);
            this.panel1.Controls.SetChildIndex(this.grbConditions, 0);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlButtons, 0);
            // 
            // grbConditions
            // 
            this.grbConditions.Controls.Add(this.txtResultQty);
            this.grbConditions.Controls.Add(this.label12);
            this.grbConditions.Controls.Add(this.txtCalcQty);
            this.grbConditions.Controls.Add(this.label11);
            this.grbConditions.Controls.Add(this.txtInsertQty);
            this.grbConditions.Controls.Add(this.label10);
            this.grbConditions.Controls.Add(this.txtProcessName);
            this.grbConditions.Controls.Add(this.label9);
            this.grbConditions.Controls.Add(this.txtWorkPlace);
            this.grbConditions.Controls.Add(this.label8);
            this.grbConditions.Controls.Add(this.txtProductName);
            this.grbConditions.Controls.Add(this.label7);
            this.grbConditions.Controls.Add(this.txtProductCode);
            this.grbConditions.Controls.Add(this.label6);
            this.grbConditions.Controls.Add(this.txtInstructionNum);
            this.grbConditions.Controls.Add(this.label5);
            this.grbConditions.Controls.Add(this.txtInstructionCondition);
            this.grbConditions.Controls.Add(this.label4);
            this.grbConditions.Controls.Add(this.txtInstructionDate);
            this.grbConditions.Controls.Add(this.label3);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(97, 30);
            this.lblTitle.Text = "실적보정";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnSave);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(135, 224);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(212, 23);
            this.txtProductName.TabIndex = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 89;
            this.label7.Text = "품목명";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(135, 175);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(133, 23);
            this.txtProductCode.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 87;
            this.label6.Text = "품목코드";
            // 
            // txtInstructionNum
            // 
            this.txtInstructionNum.Location = new System.Drawing.Point(135, 125);
            this.txtInstructionNum.Name = "txtInstructionNum";
            this.txtInstructionNum.ReadOnly = true;
            this.txtInstructionNum.Size = new System.Drawing.Size(212, 23);
            this.txtInstructionNum.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 85;
            this.label5.Text = "작업지시일자";
            // 
            // txtInstructionCondition
            // 
            this.txtInstructionCondition.Location = new System.Drawing.Point(135, 77);
            this.txtInstructionCondition.Name = "txtInstructionCondition";
            this.txtInstructionCondition.ReadOnly = true;
            this.txtInstructionCondition.Size = new System.Drawing.Size(212, 23);
            this.txtInstructionCondition.TabIndex = 84;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 83;
            this.label4.Text = "작업지시상태";
            // 
            // txtInstructionDate
            // 
            this.txtInstructionDate.Location = new System.Drawing.Point(135, 35);
            this.txtInstructionDate.Name = "txtInstructionDate";
            this.txtInstructionDate.ReadOnly = true;
            this.txtInstructionDate.Size = new System.Drawing.Size(212, 23);
            this.txtInstructionDate.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 81;
            this.label3.Text = "작업시지번호";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(280, 35);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(133, 23);
            this.txtNumber.TabIndex = 80;
            this.txtNumber.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 79;
            this.label2.Text = "번호";
            this.label2.Visible = false;
            // 
            // txtResultQty
            // 
            this.txtResultQty.Location = new System.Drawing.Point(510, 227);
            this.txtResultQty.Name = "txtResultQty";
            this.txtResultQty.Size = new System.Drawing.Size(133, 23);
            this.txtResultQty.TabIndex = 100;
            this.txtResultQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResultQty_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label12.Location = new System.Drawing.Point(420, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 99;
            this.label12.Text = "생산수량";
            // 
            // txtCalcQty
            // 
            this.txtCalcQty.Location = new System.Drawing.Point(510, 175);
            this.txtCalcQty.Name = "txtCalcQty";
            this.txtCalcQty.ReadOnly = true;
            this.txtCalcQty.Size = new System.Drawing.Size(133, 23);
            this.txtCalcQty.TabIndex = 98;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(420, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 97;
            this.label11.Text = "산출수량";
            // 
            // txtInsertQty
            // 
            this.txtInsertQty.Location = new System.Drawing.Point(510, 125);
            this.txtInsertQty.Name = "txtInsertQty";
            this.txtInsertQty.ReadOnly = true;
            this.txtInsertQty.Size = new System.Drawing.Size(133, 23);
            this.txtInsertQty.TabIndex = 96;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(420, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 95;
            this.label10.Text = "투입수량";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(510, 77);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.ReadOnly = true;
            this.txtProcessName.Size = new System.Drawing.Size(212, 23);
            this.txtProcessName.TabIndex = 94;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(420, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 93;
            this.label9.Text = "공정명";
            // 
            // txtWorkPlace
            // 
            this.txtWorkPlace.Location = new System.Drawing.Point(510, 32);
            this.txtWorkPlace.Name = "txtWorkPlace";
            this.txtWorkPlace.ReadOnly = true;
            this.txtWorkPlace.Size = new System.Drawing.Size(212, 23);
            this.txtWorkPlace.TabIndex = 92;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(420, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 91;
            this.label8.Text = "작업장";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClose.Location = new System.Drawing.Point(270, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 26);
            this.btnClose.TabIndex = 95;
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
            this.btnSave.Location = new System.Drawing.Point(199, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 28);
            this.btnSave.TabIndex = 94;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPerformanceModify2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(814, 400);
            this.Name = "frmPerformanceModify2";
            this.Text = "실적보정";
            this.Load += new System.EventHandler(this.frmPerformanceModify2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbConditions.ResumeLayout(false);
            this.grbConditions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInstructionNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInstructionCondition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInstructionDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResultQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCalcQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtInsertQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWorkPlace;
        private System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnSave;
    }
}
