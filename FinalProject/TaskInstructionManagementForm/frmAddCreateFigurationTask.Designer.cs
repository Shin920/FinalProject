
namespace FinalProject
{
    partial class frmAddCreateFigurationTask
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
            this.txtPlanQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtICode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlanQUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboWC = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReqNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblWoNo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grbConditions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblWoNo);
            this.panel1.Controls.SetChildIndex(this.grbConditions, 0);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlButtons, 0);
            this.panel1.Controls.SetChildIndex(this.lblWoNo, 0);
            // 
            // grbConditions
            // 
            this.grbConditions.Controls.Add(this.dtpOrderDate);
            this.grbConditions.Controls.Add(this.txtPlanQUnit);
            this.grbConditions.Controls.Add(this.label6);
            this.grbConditions.Controls.Add(this.cboWC);
            this.grbConditions.Controls.Add(this.label7);
            this.grbConditions.Controls.Add(this.txtReqNo);
            this.grbConditions.Controls.Add(this.label8);
            this.grbConditions.Controls.Add(this.txtIName);
            this.grbConditions.Controls.Add(this.label9);
            this.grbConditions.Controls.Add(this.txtPlanQty);
            this.grbConditions.Controls.Add(this.label1);
            this.grbConditions.Controls.Add(this.txtRemark);
            this.grbConditions.Controls.Add(this.label2);
            this.grbConditions.Controls.Add(this.label3);
            this.grbConditions.Controls.Add(this.txtOrder);
            this.grbConditions.Controls.Add(this.label4);
            this.grbConditions.Controls.Add(this.txtICode);
            this.grbConditions.Controls.Add(this.label5);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(254, 30);
            this.lblTitle.Text = "성형작업지시생성 - 등록";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.button1);
            this.pnlButtons.Controls.Add(this.btnSave);
            // 
            // txtPlanQty
            // 
            this.txtPlanQty.Location = new System.Drawing.Point(150, 150);
            this.txtPlanQty.Name = "txtPlanQty";
            this.txtPlanQty.ReadOnly = true;
            this.txtPlanQty.Size = new System.Drawing.Size(201, 23);
            this.txtPlanQty.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label1.Location = new System.Drawing.Point(52, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "계획수량";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(150, 195);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(581, 47);
            this.txtRemark.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 80;
            this.label2.Text = "비고";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label3.Location = new System.Drawing.Point(52, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 79;
            this.label3.Text = "생산의뢰순번";
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(150, 35);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.ReadOnly = true;
            this.txtOrder.Size = new System.Drawing.Size(201, 23);
            this.txtOrder.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label4.Location = new System.Drawing.Point(52, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 82;
            this.label4.Text = "품목코드";
            // 
            // txtICode
            // 
            this.txtICode.Location = new System.Drawing.Point(150, 74);
            this.txtICode.Name = "txtICode";
            this.txtICode.ReadOnly = true;
            this.txtICode.Size = new System.Drawing.Size(201, 23);
            this.txtICode.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label5.Location = new System.Drawing.Point(52, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 84;
            this.label5.Text = "작업지시일";
            // 
            // txtPlanQUnit
            // 
            this.txtPlanQUnit.Location = new System.Drawing.Point(530, 150);
            this.txtPlanQUnit.Name = "txtPlanQUnit";
            this.txtPlanQUnit.ReadOnly = true;
            this.txtPlanQUnit.Size = new System.Drawing.Size(201, 23);
            this.txtPlanQUnit.TabIndex = 96;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label6.Location = new System.Drawing.Point(433, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 95;
            this.label6.Text = "계획수량단위";
            // 
            // cboWC
            // 
            this.cboWC.FormattingEnabled = true;
            this.cboWC.Location = new System.Drawing.Point(530, 112);
            this.cboWC.Name = "cboWC";
            this.cboWC.Size = new System.Drawing.Size(201, 23);
            this.cboWC.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label7.Location = new System.Drawing.Point(432, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 89;
            this.label7.Text = "생산의뢰번호";
            // 
            // txtReqNo
            // 
            this.txtReqNo.Location = new System.Drawing.Point(530, 35);
            this.txtReqNo.Name = "txtReqNo";
            this.txtReqNo.ReadOnly = true;
            this.txtReqNo.Size = new System.Drawing.Size(201, 23);
            this.txtReqNo.TabIndex = 90;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label8.Location = new System.Drawing.Point(468, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 91;
            this.label8.Text = "품목명";
            // 
            // txtIName
            // 
            this.txtIName.Location = new System.Drawing.Point(530, 74);
            this.txtIName.Name = "txtIName";
            this.txtIName.ReadOnly = true;
            this.txtIName.Size = new System.Drawing.Size(201, 23);
            this.txtIName.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.label9.Location = new System.Drawing.Point(468, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 93;
            this.label9.Text = "작업장";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button1.Location = new System.Drawing.Point(272, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 26);
            this.button1.TabIndex = 67;
            this.button1.Text = "닫기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(200, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 28);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(150, 112);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 23);
            this.dtpOrderDate.TabIndex = 0;
            // 
            // lblWoNo
            // 
            this.lblWoNo.AutoSize = true;
            this.lblWoNo.Location = new System.Drawing.Point(714, 12);
            this.lblWoNo.Name = "lblWoNo";
            this.lblWoNo.Size = new System.Drawing.Size(46, 15);
            this.lblWoNo.TabIndex = 63;
            this.lblWoNo.Text = "label10";
            this.lblWoNo.Visible = false;
            // 
            // frmAddCreateFigurationTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(814, 400);
            this.Name = "frmAddCreateFigurationTask";
            this.Load += new System.EventHandler(this.frmAddCreateFigurationTask_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbConditions.ResumeLayout(false);
            this.grbConditions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox txtPlanQty;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtRemark;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtOrder;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtICode;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox txtPlanQUnit;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.ComboBox cboWC;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox txtReqNo;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox txtIName;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblWoNo;
    }
}
