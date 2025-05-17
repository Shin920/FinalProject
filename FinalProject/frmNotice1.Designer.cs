
namespace FinalProject
{
    partial class frmNotice1
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
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboUseYNS = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboUseYN = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpNoticeDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.lblseq = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblseq);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.lblSubTitle2, 0);
            this.panel1.Controls.SetChildIndex(this.pnlCondition, 0);
            this.panel1.Controls.SetChildIndex(this.pnlButtons, 0);
            this.panel1.Controls.SetChildIndex(this.pnlDataGridView, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSubBottons, 0);
            this.panel1.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.panel1.Controls.SetChildIndex(this.lblseq, 0);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(134, 40);
            this.lblTitle.Text = "공지사항";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.label1);
            this.pnlCondition.Controls.Add(this.cboUseYN);
            this.pnlCondition.Controls.Add(this.dtpEndDate);
            this.pnlCondition.Controls.Add(this.dtpNoticeDate);
            this.pnlCondition.Controls.Add(this.label11);
            this.pnlCondition.Controls.Add(this.txtDes);
            this.pnlCondition.Controls.Add(this.txtTitle);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.label2);
            this.pnlCondition.Controls.Add(this.label12);
            this.pnlCondition.Location = new System.Drawing.Point(44, 791);
            this.pnlCondition.Size = new System.Drawing.Size(1457, 235);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Location = new System.Drawing.Point(39, 754);
            this.lblSubTitle2.Text = "☷ 입력정보";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.button6);
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dataGridView1);
            this.pnlDataGridView.Size = new System.Drawing.Size(1457, 580);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Location = new System.Drawing.Point(1157, 753);
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.Controls.Add(this.panel2, 0, 0);
            this.tblSearch.Controls.Add(this.label7, 0, 0);
            this.tblSearch.Controls.Add(this.label6, 2, 0);
            this.tblSearch.Controls.Add(this.label8, 4, 0);
            this.tblSearch.Controls.Add(this.cboUseYNS, 5, 0);
            this.tblSearch.Controls.Add(this.txtSearch, 3, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(174, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 47);
            this.panel2.TabIndex = 6;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(181, 13);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(121, 23);
            this.dtpTo.TabIndex = 31;
            this.dtpTo.Value = new System.DateTime(3000, 7, 20, 13, 34, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "~";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(12, 13);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(121, 23);
            this.dtpFrom.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(4, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 53);
            this.label7.TabIndex = 0;
            this.label7.Text = "공지 일자";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(489, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 53);
            this.label6.TabIndex = 3;
            this.label6.Text = "검색어";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(974, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 53);
            this.label8.TabIndex = 4;
            this.label8.Text = "사용여부";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboUseYNS
            // 
            this.cboUseYNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUseYNS.FormattingEnabled = true;
            this.cboUseYNS.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cboUseYNS.Location = new System.Drawing.Point(1144, 17);
            this.cboUseYNS.Name = "cboUseYNS";
            this.cboUseYNS.Size = new System.Drawing.Size(309, 23);
            this.cboUseYNS.TabIndex = 2;
            this.cboUseYNS.Text = "Y";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(659, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(308, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1457, 580);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cboUseYN
            // 
            this.cboUseYN.FormattingEnabled = true;
            this.cboUseYN.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cboUseYN.Location = new System.Drawing.Point(213, 124);
            this.cboUseYN.Name = "cboUseYN";
            this.cboUseYN.Size = new System.Drawing.Size(128, 23);
            this.cboUseYN.TabIndex = 27;
            this.cboUseYN.Text = "Y";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(213, 69);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 19;
            // 
            // dtpNoticeDate
            // 
            this.dtpNoticeDate.Location = new System.Drawing.Point(213, 17);
            this.dtpNoticeDate.Name = "dtpNoticeDate";
            this.dtpNoticeDate.Size = new System.Drawing.Size(200, 23);
            this.dtpNoticeDate.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(494, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = " ✧  내용";
            // 
            // txtDes
            // 
            this.txtDes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDes.Location = new System.Drawing.Point(581, 72);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDes.Size = new System.Drawing.Size(850, 146);
            this.txtDes.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(581, 15);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(540, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(494, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = " ✧  제목";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = " ✧ 사용 여부";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(66, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = " ✧  공지 시작 일자";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = " ✧  공지 종료 일자";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(514, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(71, 32);
            this.button6.TabIndex = 32;
            this.button6.Text = "🔍조회";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // lblseq
            // 
            this.lblseq.AutoSize = true;
            this.lblseq.Location = new System.Drawing.Point(194, 762);
            this.lblseq.Name = "lblseq";
            this.lblseq.Size = new System.Drawing.Size(25, 15);
            this.lblseq.TabIndex = 33;
            this.lblseq.Text = "seq";
            this.lblseq.Visible = false;
            // 
            // frmNotice1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmNotice1";
            this.Text = "공지사항";
            this.Load += new System.EventHandler(this.frmNotice1_Load);
            this.Shown += new System.EventHandler(this.frmNotice1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlDataGridView.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboUseYNS;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboUseYN;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpNoticeDate;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox txtDes;
        protected System.Windows.Forms.TextBox txtTitle;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        protected System.Windows.Forms.Label lblseq;
    }
}
