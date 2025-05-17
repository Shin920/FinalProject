
namespace FinalProject
{
    partial class frmCarriageHistoryInquiry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarriageHistoryInquiry));
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucPeriodControl1 = new FinalProject.UcPeriodControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnProductList = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCarriageCode = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCarriageName = new System.Windows.Forms.TextBox();
            this.btnCarriageList = new System.Windows.Forms.Button();
            this.dgvCarriageHistory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarriageHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.SetChildIndex(this.pnlButtons, 0);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.pnlDataGridView, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "minus.png");
            this.imageList1.Images.SetKeyName(1, "plus.png");
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(215, 40);
            this.lblTitle.Text = "대차 이력 조회";
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.label1);
            this.pnlDataGridView.Controls.Add(this.dgvCarriageHistory);
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 8;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.534619F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.66288F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.32917F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.87453F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.63118F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.973081F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 287F));
            this.tblSearch.Controls.Add(this.panel2, 0, 0);
            this.tblSearch.Controls.Add(this.panel4, 7, 0);
            this.tblSearch.Controls.Add(this.txtProductCode, 6, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.label12, 5, 0);
            this.tblSearch.Controls.Add(this.label14, 0, 0);
            this.tblSearch.Controls.Add(this.txtCarriageCode, 3, 0);
            this.tblSearch.Controls.Add(this.panel3, 4, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucPeriodControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(99, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 47);
            this.panel2.TabIndex = 40;
            // 
            // ucPeriodControl1
            // 
            this.ucPeriodControl1.dtFrom = "2021-07-03";
            this.ucPeriodControl1.dtTo = "2021-07-27";
            this.ucPeriodControl1.Location = new System.Drawing.Point(35, 6);
            this.ucPeriodControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPeriodControl1.Name = "ucPeriodControl1";
            this.ucPeriodControl1.Size = new System.Drawing.Size(306, 30);
            this.ucPeriodControl1.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnProductList);
            this.panel4.Controls.Add(this.txtProductName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1170, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(283, 47);
            this.panel4.TabIndex = 39;
            // 
            // btnProductList
            // 
            this.btnProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProductList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnProductList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductList.ForeColor = System.Drawing.Color.White;
            this.btnProductList.Location = new System.Drawing.Point(235, 12);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.Size = new System.Drawing.Size(36, 24);
            this.btnProductList.TabIndex = 37;
            this.btnProductList.Text = "...";
            this.btnProductList.UseVisualStyleBackColor = false;
            this.btnProductList.Click += new System.EventHandler(this.btnProductList_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductName.Location = new System.Drawing.Point(3, 13);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(226, 23);
            this.txtProductName.TabIndex = 2;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductCode.Location = new System.Drawing.Point(996, 16);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(167, 23);
            this.txtProductCode.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(462, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 53);
            this.label13.TabIndex = 3;
            this.label13.Text = "대차";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(907, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 53);
            this.label12.TabIndex = 4;
            this.label12.Text = "품목";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(4, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 53);
            this.label14.TabIndex = 0;
            this.label14.Text = "로딩일자";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCarriageCode
            // 
            this.txtCarriageCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarriageCode.Location = new System.Drawing.Point(565, 16);
            this.txtCarriageCode.Name = "txtCarriageCode";
            this.txtCarriageCode.Size = new System.Drawing.Size(150, 23);
            this.txtCarriageCode.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtCarriageName);
            this.panel3.Controls.Add(this.btnCarriageList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(722, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 47);
            this.panel3.TabIndex = 38;
            // 
            // txtCarriageName
            // 
            this.txtCarriageName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarriageName.Location = new System.Drawing.Point(3, 13);
            this.txtCarriageName.Name = "txtCarriageName";
            this.txtCarriageName.Size = new System.Drawing.Size(121, 23);
            this.txtCarriageName.TabIndex = 2;
            // 
            // btnCarriageList
            // 
            this.btnCarriageList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarriageList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnCarriageList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarriageList.ForeColor = System.Drawing.Color.White;
            this.btnCarriageList.Location = new System.Drawing.Point(130, 12);
            this.btnCarriageList.Name = "btnCarriageList";
            this.btnCarriageList.Size = new System.Drawing.Size(37, 24);
            this.btnCarriageList.TabIndex = 36;
            this.btnCarriageList.Text = "...";
            this.btnCarriageList.UseVisualStyleBackColor = false;
            this.btnCarriageList.Click += new System.EventHandler(this.btnCarriageList_Click);
            // 
            // dgvCarriageHistory
            // 
            this.dgvCarriageHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarriageHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarriageHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarriageHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvCarriageHistory.Name = "dgvCarriageHistory";
            this.dgvCarriageHistory.RowTemplate.Height = 23;
            this.dgvCarriageHistory.Size = new System.Drawing.Size(1457, 651);
            this.dgvCarriageHistory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(133, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(839, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "대차코드/대차명/작업지시번호/품목코드/품목명/로딩일자/로딩수량/로딩시간/로딩작업장/요입시간/중간시간/요출시간/언로딩수량/언로딩일자/언로딩일시/언로" +
    "딩작업장/대상대차/대차비우기 일자/대차비우기일시/대차비우기수량/대차비우기원인/대상작업장/대상작업장품목";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(653, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "이 앞부분은 대차명이면 콤보박스인게 낫지않은지? 근데 왼쪽이 코드 오른쪽이 네임으로 팝업창이 뜨니까 그냥 해도될듯";
            this.label2.Visible = false;
            // 
            // frmCarriageHistoryInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Name = "frmCarriageHistoryInquiry";
            this.Text = "대차 이력 조회";
            this.Load += new System.EventHandler(this.frmCarriageHistoryInquiry_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlDataGridView.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarriageHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCarriageCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCarriageName;
        private System.Windows.Forms.Button btnCarriageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCarriageHistory;
        private System.Windows.Forms.Button btnProductList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private UcPeriodControl ucPeriodControl1;
    }
}
