
namespace FinalProject
{
    partial class frmPerformanceCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerformanceCheck));
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucPeriodControl1 = new FinalProject.UcPeriodControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnWorkPlaceList = new System.Windows.Forms.Button();
            this.txtWorkPlaceName = new System.Windows.Forms.TextBox();
            this.txtworkPlaceCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtProcessCode = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.btnProcessList = new System.Windows.Forms.Button();
            this.btnResultModify = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.SetChildIndex(this.pnlButtons, 0);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.pnlDataGridView, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnResultModify);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "minus.png");
            this.imageList1.Images.SetKeyName(1, "plus.png");
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "실적조회";
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.label2);
            this.pnlDataGridView.Controls.Add(this.label1);
            this.pnlDataGridView.Controls.Add(this.dgvResult);
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
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tblSearch.Controls.Add(this.panel2, 0, 0);
            this.tblSearch.Controls.Add(this.panel4, 7, 0);
            this.tblSearch.Controls.Add(this.txtworkPlaceCode, 6, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.label12, 5, 0);
            this.tblSearch.Controls.Add(this.label14, 0, 0);
            this.tblSearch.Controls.Add(this.txtProcessCode, 3, 0);
            this.tblSearch.Controls.Add(this.panel3, 4, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucPeriodControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(99, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 47);
            this.panel2.TabIndex = 40;
            // 
            // ucPeriodControl1
            // 
            this.ucPeriodControl1.dtFrom = "2021-07-03";
            this.ucPeriodControl1.dtTo = "2021-07-26";
            this.ucPeriodControl1.Location = new System.Drawing.Point(31, 7);
            this.ucPeriodControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPeriodControl1.Name = "ucPeriodControl1";
            this.ucPeriodControl1.Size = new System.Drawing.Size(306, 30);
            this.ucPeriodControl1.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnWorkPlaceList);
            this.panel4.Controls.Add(this.txtWorkPlaceName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1177, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(276, 47);
            this.panel4.TabIndex = 39;
            // 
            // btnWorkPlaceList
            // 
            this.btnWorkPlaceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkPlaceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnWorkPlaceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkPlaceList.ForeColor = System.Drawing.Color.White;
            this.btnWorkPlaceList.Location = new System.Drawing.Point(228, 12);
            this.btnWorkPlaceList.Name = "btnWorkPlaceList";
            this.btnWorkPlaceList.Size = new System.Drawing.Size(41, 24);
            this.btnWorkPlaceList.TabIndex = 37;
            this.btnWorkPlaceList.Text = "...";
            this.btnWorkPlaceList.UseVisualStyleBackColor = false;
            this.btnWorkPlaceList.Click += new System.EventHandler(this.btnWorkPlaceList_Click);
            // 
            // txtWorkPlaceName
            // 
            this.txtWorkPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlaceName.Location = new System.Drawing.Point(3, 13);
            this.txtWorkPlaceName.Name = "txtWorkPlaceName";
            this.txtWorkPlaceName.Size = new System.Drawing.Size(219, 23);
            this.txtWorkPlaceName.TabIndex = 2;
            // 
            // txtworkPlaceCode
            // 
            this.txtworkPlaceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtworkPlaceCode.Location = new System.Drawing.Point(1003, 16);
            this.txtworkPlaceCode.Name = "txtworkPlaceCode";
            this.txtworkPlaceCode.Size = new System.Drawing.Size(167, 23);
            this.txtworkPlaceCode.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(465, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 53);
            this.label13.TabIndex = 3;
            this.label13.Text = "공정";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(913, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 53);
            this.label12.TabIndex = 4;
            this.label12.Text = "작업장";
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
            this.label14.Text = "작업지시일자";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProcessCode
            // 
            this.txtProcessCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessCode.Location = new System.Drawing.Point(568, 16);
            this.txtProcessCode.Name = "txtProcessCode";
            this.txtProcessCode.Size = new System.Drawing.Size(152, 23);
            this.txtProcessCode.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtProcessName);
            this.panel3.Controls.Add(this.btnProcessList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(727, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 47);
            this.panel3.TabIndex = 38;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessName.Location = new System.Drawing.Point(3, 13);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(122, 23);
            this.txtProcessName.TabIndex = 2;
            // 
            // btnProcessList
            // 
            this.btnProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnProcessList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessList.ForeColor = System.Drawing.Color.White;
            this.btnProcessList.Location = new System.Drawing.Point(131, 13);
            this.btnProcessList.Name = "btnProcessList";
            this.btnProcessList.Size = new System.Drawing.Size(46, 24);
            this.btnProcessList.TabIndex = 36;
            this.btnProcessList.Text = "...";
            this.btnProcessList.UseVisualStyleBackColor = false;
            this.btnProcessList.Click += new System.EventHandler(this.btnProcessList_Click);
            // 
            // btnResultModify
            // 
            this.btnResultModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnResultModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResultModify.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnResultModify.ForeColor = System.Drawing.Color.White;
            this.btnResultModify.Location = new System.Drawing.Point(495, 1);
            this.btnResultModify.Name = "btnResultModify";
            this.btnResultModify.Size = new System.Drawing.Size(90, 31);
            this.btnResultModify.TabIndex = 27;
            this.btnResultModify.Text = "실적보정";
            this.btnResultModify.UseVisualStyleBackColor = false;
            this.btnResultModify.Click += new System.EventHandler(this.btnResultModify_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(1457, 651);
            this.dgvResult.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "작업지시상태 / 작업지시번호 / 품목코드 / 품목명 / 작업장 / 투입수량/산출수량/생산수량";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "4조는 앞에 번호";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(566, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(551, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "왼쪽 텍스트박스에 코드라고 희미하게 보이는거로 하고 오른쪽에 이름이라고 희미하게 보이는거 하기";
            this.label3.Visible = false;
            // 
            // frmPerformanceCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Name = "frmPerformanceCheck";
            this.Text = "실적조회";
            this.Load += new System.EventHandler(this.frmPerformanceCheck_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlDataGridView.ResumeLayout(false);
            this.pnlDataGridView.PerformLayout();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnResultModify;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtWorkPlaceName;
        private System.Windows.Forms.TextBox txtworkPlaceCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtProcessCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Button btnProcessList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnWorkPlaceList;
        private System.Windows.Forms.Panel panel2;
        private UcPeriodControl ucPeriodControl1;
        private System.Windows.Forms.Label label3;
    }
}
