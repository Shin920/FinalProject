
namespace FinalProject
{
    partial class frmEndTaskMgmt
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.nmcPlanQty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUdtCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUdtNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUdtName = new System.Windows.Forms.TextBox();
            this.dtpUdtDate = new System.Windows.Forms.DateTimePicker();
            this.txtPlanUnit = new System.Windows.Forms.TextBox();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpLdate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcPlanQty)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(271, 40);
            this.lblTitle.Text = "작업지시 마감관리";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.txtPlanUnit);
            this.pnlCondition.Controls.Add(this.dtpUdtDate);
            this.pnlCondition.Controls.Add(this.txtUdtName);
            this.pnlCondition.Controls.Add(this.label6);
            this.pnlCondition.Controls.Add(this.nmcPlanQty);
            this.pnlCondition.Controls.Add(this.label5);
            this.pnlCondition.Controls.Add(this.label7);
            this.pnlCondition.Controls.Add(this.label8);
            this.pnlCondition.Controls.Add(this.txtUdtCode);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtUdtNo);
            this.pnlCondition.Controls.Add(this.label12);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Text = "☷ 입력정보";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnFinish);
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvOrder);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(392, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(193, 32);
            this.btnCancel.TabIndex = 69;
            this.btnCancel.Text = "작업지시 마감취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(202, 0);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(193, 32);
            this.btnFinish.TabIndex = 68;
            this.btnFinish.Text = "작업지시 마감";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // dgvOrder
            // 
            this.dgvOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowTemplate.Height = 23;
            this.dgvOrder.Size = new System.Drawing.Size(1457, 688);
            this.dgvOrder.TabIndex = 0;
            this.dgvOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(959, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = " ✧  계획수량단위";
            // 
            // nmcPlanQty
            // 
            this.nmcPlanQty.Location = new System.Drawing.Point(652, 75);
            this.nmcPlanQty.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmcPlanQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmcPlanQty.Name = "nmcPlanQty";
            this.nmcPlanQty.Size = new System.Drawing.Size(272, 23);
            this.nmcPlanQty.TabIndex = 38;
            this.nmcPlanQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(543, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = " ✧  계획수량";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = " ✧  계획일자";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(959, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = " ✧  품목명";
            // 
            // txtUdtCode
            // 
            this.txtUdtCode.Location = new System.Drawing.Point(652, 29);
            this.txtUdtCode.Name = "txtUdtCode";
            this.txtUdtCode.ReadOnly = true;
            this.txtUdtCode.Size = new System.Drawing.Size(272, 23);
            this.txtUdtCode.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(543, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = " ✧  품목코드";
            // 
            // txtUdtNo
            // 
            this.txtUdtNo.Location = new System.Drawing.Point(232, 25);
            this.txtUdtNo.Name = "txtUdtNo";
            this.txtUdtNo.ReadOnly = true;
            this.txtUdtNo.Size = new System.Drawing.Size(272, 23);
            this.txtUdtNo.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(108, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 15);
            this.label12.TabIndex = 32;
            this.label12.Text = " ✧  작업지시번호";
            // 
            // txtUdtName
            // 
            this.txtUdtName.Location = new System.Drawing.Point(1075, 30);
            this.txtUdtName.Name = "txtUdtName";
            this.txtUdtName.ReadOnly = true;
            this.txtUdtName.Size = new System.Drawing.Size(272, 23);
            this.txtUdtName.TabIndex = 41;
            // 
            // dtpUdtDate
            // 
            this.dtpUdtDate.Location = new System.Drawing.Point(232, 74);
            this.dtpUdtDate.Name = "dtpUdtDate";
            this.dtpUdtDate.Size = new System.Drawing.Size(272, 23);
            this.dtpUdtDate.TabIndex = 42;
            // 
            // txtPlanUnit
            // 
            this.txtPlanUnit.Location = new System.Drawing.Point(1075, 75);
            this.txtPlanUnit.Name = "txtPlanUnit";
            this.txtPlanUnit.Size = new System.Drawing.Size(272, 23);
            this.txtPlanUnit.TabIndex = 43;
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.44231F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.722528F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.42033F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.340659F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.74176F));
            this.tblSearch.Controls.Add(this.label1, 4, 0);
            this.tblSearch.Controls.Add(this.panel2, 0, 0);
            this.tblSearch.Controls.Add(this.label2, 2, 0);
            this.tblSearch.Controls.Add(this.label3, 0, 0);
            this.tblSearch.Controls.Add(this.textBox4, 3, 0);
            this.tblSearch.Controls.Add(this.textBox1, 5, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(1022, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 53);
            this.label1.TabIndex = 39;
            this.label1.Text = "작업장";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpLdate);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.dtpFdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(173, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 47);
            this.panel2.TabIndex = 36;
            // 
            // dtpLdate
            // 
            this.dtpLdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpLdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLdate.Location = new System.Drawing.Point(218, 13);
            this.dtpLdate.Name = "dtpLdate";
            this.dtpLdate.Size = new System.Drawing.Size(155, 23);
            this.dtpLdate.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(185, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "~";
            // 
            // dtpFdate
            // 
            this.dtpFdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFdate.Location = new System.Drawing.Point(12, 13);
            this.dtpFdate.Name = "dtpFdate";
            this.dtpFdate.Size = new System.Drawing.Size(158, 23);
            this.dtpFdate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(556, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 53);
            this.label2.TabIndex = 3;
            this.label2.Text = "공정";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 53);
            this.label3.TabIndex = 0;
            this.label3.Text = "작업지시일자";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(683, 16);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(332, 23);
            this.textBox4.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(1157, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 23);
            this.textBox1.TabIndex = 38;
            // 
            // frmEndTaskMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmEndTaskMgmt";
            this.Load += new System.EventHandler(this.frmEndTaskMgmt_Load);
            this.panel1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcPlanQty)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.DataGridView dgvOrder;
        protected System.Windows.Forms.TextBox txtPlanUnit;
        private System.Windows.Forms.DateTimePicker dtpUdtDate;
        protected System.Windows.Forms.TextBox txtUdtName;
        protected System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nmcPlanQty;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox txtUdtCode;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtUdtNo;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpLdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
    }
}
