
namespace FinalProject
{
    partial class frmNonOperatingRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNonOperatingRegistration));
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWorkPlaceCode = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnWorkPlaceList = new System.Windows.Forms.Button();
            this.txtWorkPlaceName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucPeriodControl1 = new FinalProject.UcPeriodControl();
            this.dgvNopHistory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNopHistory)).BeginInit();
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
            this.lblTitle.Text = "비가동 등록";
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.label3);
            this.pnlDataGridView.Controls.Add(this.label1);
            this.pnlDataGridView.Controls.Add(this.dgvNopHistory);
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.53846F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.0467F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.16483F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.62912F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.40659F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tblSearch.Controls.Add(this.label6, 2, 0);
            this.tblSearch.Controls.Add(this.label7, 0, 0);
            this.tblSearch.Controls.Add(this.txtWorkPlaceCode, 3, 0);
            this.tblSearch.Controls.Add(this.panel3, 4, 0);
            this.tblSearch.Controls.Add(this.panel2, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(493, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 53);
            this.label6.TabIndex = 3;
            this.label6.Text = "작업장";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label7.Size = new System.Drawing.Size(161, 53);
            this.label7.TabIndex = 0;
            this.label7.Text = "비가동일자";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWorkPlaceCode
            // 
            this.txtWorkPlaceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlaceCode.Location = new System.Drawing.Point(641, 16);
            this.txtWorkPlaceCode.Name = "txtWorkPlaceCode";
            this.txtWorkPlaceCode.Size = new System.Drawing.Size(206, 23);
            this.txtWorkPlaceCode.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnWorkPlaceList);
            this.panel3.Controls.Add(this.txtWorkPlaceName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(854, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 47);
            this.panel3.TabIndex = 37;
            // 
            // btnWorkPlaceList
            // 
            this.btnWorkPlaceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkPlaceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnWorkPlaceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkPlaceList.ForeColor = System.Drawing.Color.White;
            this.btnWorkPlaceList.Location = new System.Drawing.Point(215, 12);
            this.btnWorkPlaceList.Name = "btnWorkPlaceList";
            this.btnWorkPlaceList.Size = new System.Drawing.Size(43, 24);
            this.btnWorkPlaceList.TabIndex = 37;
            this.btnWorkPlaceList.Text = "...";
            this.btnWorkPlaceList.UseVisualStyleBackColor = false;
            this.btnWorkPlaceList.Click += new System.EventHandler(this.btnWorkPlaceList_Click);
            // 
            // txtWorkPlaceName
            // 
            this.txtWorkPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlaceName.Location = new System.Drawing.Point(3, 12);
            this.txtWorkPlaceName.Name = "txtWorkPlaceName";
            this.txtWorkPlaceName.Size = new System.Drawing.Size(206, 23);
            this.txtWorkPlaceName.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucPeriodControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(172, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 47);
            this.panel2.TabIndex = 38;
            // 
            // ucPeriodControl1
            // 
            this.ucPeriodControl1.dtFrom = "2021-07-03";
            this.ucPeriodControl1.dtTo = "2021-07-27";
            this.ucPeriodControl1.Location = new System.Drawing.Point(5, 6);
            this.ucPeriodControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPeriodControl1.Name = "ucPeriodControl1";
            this.ucPeriodControl1.Size = new System.Drawing.Size(306, 30);
            this.ucPeriodControl1.TabIndex = 38;
            // 
            // dgvNopHistory
            // 
            this.dgvNopHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvNopHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNopHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNopHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvNopHistory.Name = "dgvNopHistory";
            this.dgvNopHistory.RowTemplate.Height = 23;
            this.dgvNopHistory.Size = new System.Drawing.Size(1457, 651);
            this.dgvNopHistory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(676, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "비가동일자/작업장코드/작업장명/비가동대분류/비가동상세분류/비가동발생시각/비가동종료시각/비가동시간/비고/발생유형";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(625, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "엑센 화면설계에는 조회쪽에 공정도 있는데 그리드뷰 내용이나 4조걸로 볼때 없는게 나을거같기도하다. 고민해보기";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "4조는 앞에 발생순번 컬럼있음";
            this.label3.Visible = false;
            // 
            // frmNonOperatingRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Name = "frmNonOperatingRegistration";
            this.Text = "비가동 등록";
            this.Load += new System.EventHandler(this.frmNonOperatingRegistration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlDataGridView.ResumeLayout(false);
            this.pnlDataGridView.PerformLayout();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNopHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWorkPlaceCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnWorkPlaceList;
        private System.Windows.Forms.TextBox txtWorkPlaceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNopHistory;
        private UcPeriodControl ucPeriodControl1;
        private System.Windows.Forms.Panel panel2;
    }
}
