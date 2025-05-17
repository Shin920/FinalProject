
namespace FinalProject
{
    partial class frmAnalysisOfAbsenteeism
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalysisOfAbsenteeism));
            this.dgvWorkHistory = new System.Windows.Forms.DataGridView();
            this.dgvDetailWorkHistory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucPeriodControl1 = new FinalProject.UcPeriodControl();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtWorkerID = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtWorkerName = new System.Windows.Forms.TextBox();
            this.btnWorkerList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailWorkHistory)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
            this.panel1.Controls.SetChildIndex(this.pnlButtons, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Location = new System.Drawing.Point(3, 8);
            this.lblSubTitle2.Size = new System.Drawing.Size(169, 28);
            this.lblSubTitle2.Text = "☷ 작업상세정보";
            this.lblSubTitle2.Visible = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Size = new System.Drawing.Size(133, 29);
            this.lblSubTitle.Text = "☷ 조회내역";
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(201, 40);
            this.lblTitle.Text = "근태현황 분석";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dgvWorkHistory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetailWorkHistory);
            // 
            // dgvWorkHistory
            // 
            this.dgvWorkHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvWorkHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvWorkHistory.Name = "dgvWorkHistory";
            this.dgvWorkHistory.RowTemplate.Height = 23;
            this.dgvWorkHistory.Size = new System.Drawing.Size(1457, 430);
            this.dgvWorkHistory.TabIndex = 0;
            this.dgvWorkHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkHistory_CellDoubleClick);
            // 
            // dgvDetailWorkHistory
            // 
            this.dgvDetailWorkHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetailWorkHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailWorkHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailWorkHistory.Location = new System.Drawing.Point(0, 39);
            this.dgvDetailWorkHistory.Name = "dgvDetailWorkHistory";
            this.dgvDetailWorkHistory.RowTemplate.Height = 23;
            this.dgvDetailWorkHistory.Size = new System.Drawing.Size(1457, 390);
            this.dgvDetailWorkHistory.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(906, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "근데 이 메뉴명이 있는게 어색할수도있을듯, 탭페이지로 생성되면 위에 탭쪽에 메뉴명이 나오는데 이렇게도 있으면 조금 그럴수도. 이걸 visible=" +
    "false로 하거나 해도될듯";
            this.label1.Visible = false;
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.90934F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.26374F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.Controls.Add(this.panel2, 1, 0);
            this.tblSearch.Controls.Add(this.label12, 4, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.label14, 0, 0);
            this.tblSearch.Controls.Add(this.txtWorkerID, 3, 0);
            this.tblSearch.Controls.Add(this.panel3, 5, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucPeriodControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(174, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 47);
            this.panel2.TabIndex = 39;
            // 
            // ucPeriodControl1
            // 
            this.ucPeriodControl1.dtFrom = "2021-07-03";
            this.ucPeriodControl1.dtTo = "2021-07-26";
            this.ucPeriodControl1.Location = new System.Drawing.Point(5, 6);
            this.ucPeriodControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPeriodControl1.Name = "ucPeriodControl1";
            this.ucPeriodControl1.Size = new System.Drawing.Size(306, 30);
            this.ucPeriodControl1.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(972, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 53);
            this.label12.TabIndex = 4;
            this.label12.Text = "작업자명";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(493, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 53);
            this.label13.TabIndex = 3;
            this.label13.Text = "사용자ID";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label14.Size = new System.Drawing.Size(163, 53);
            this.label14.TabIndex = 0;
            this.label14.Text = "근무일자";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWorkerID
            // 
            this.txtWorkerID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkerID.Location = new System.Drawing.Point(657, 16);
            this.txtWorkerID.Name = "txtWorkerID";
            this.txtWorkerID.Size = new System.Drawing.Size(308, 23);
            this.txtWorkerID.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtWorkerName);
            this.panel3.Controls.Add(this.btnWorkerList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1142, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(311, 47);
            this.panel3.TabIndex = 36;
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkerName.Location = new System.Drawing.Point(3, 13);
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Size = new System.Drawing.Size(253, 23);
            this.txtWorkerName.TabIndex = 2;
            // 
            // btnWorkerList
            // 
            this.btnWorkerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnWorkerList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkerList.ForeColor = System.Drawing.Color.White;
            this.btnWorkerList.Location = new System.Drawing.Point(259, 12);
            this.btnWorkerList.Name = "btnWorkerList";
            this.btnWorkerList.Size = new System.Drawing.Size(40, 24);
            this.btnWorkerList.TabIndex = 36;
            this.btnWorkerList.Text = "...";
            this.btnWorkerList.UseVisualStyleBackColor = false;
            this.btnWorkerList.Click += new System.EventHandler(this.btnWorkerList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1298, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "노란버튼 누르면 작업자 목록 팝업창";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "작업자/ 근무일을 컬럼으로 생성(그 안에 데이터가 생산수량)";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(374, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ex> 사용자ID/ 사용자명 / 2018-01-01 / 2018-01-02 …  으로 출력.)";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(616, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "작업지시번호/작업장코드/작업장명/품목코드/품목명/작업지삭일시/작업종료일시/작업시간/생산수량/할당작업자";
            this.label5.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "minus.png");
            this.imageList1.Images.SetKeyName(1, "plus.png");
            this.imageList1.Images.SetKeyName(2, "회색.png");
            this.imageList1.Images.SetKeyName(3, "흰색.png");
            // 
            // frmAnalysisOfAbsenteeism
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmAnalysisOfAbsenteeism";
            this.Text = "근태현황 분석";
            this.Load += new System.EventHandler(this.frmAnalysisOfAbsenteeism_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailWorkHistory)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkHistory;
        private System.Windows.Forms.DataGridView dgvDetailWorkHistory;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtWorkerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtWorkerName;
        private System.Windows.Forms.Button btnWorkerList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private UcPeriodControl ucPeriodControl1;
    }
}
