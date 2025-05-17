
namespace FinalProject
{ 
    partial class frmMoldUse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dgvMoldList = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dateTimePickerSearch1 = new FinalProject.DateTimePickerSearch();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoldList)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataGridView.Controls.Add(this.dgvMoldList);
            this.pnlDataGridView.Location = new System.Drawing.Point(43, 160);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(1457, 651);
            this.pnlDataGridView.TabIndex = 50;
            // 
            // dgvMoldList
            // 
            this.dgvMoldList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMoldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMoldList.Location = new System.Drawing.Point(0, 0);
            this.dgvMoldList.Name = "dgvMoldList";
            this.dgvMoldList.RowTemplate.Height = 23;
            this.dgvMoldList.Size = new System.Drawing.Size(1457, 651);
            this.dgvMoldList.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.tblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(43, 67);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1457, 55);
            this.pnlSearch.TabIndex = 48;
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 2;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.23901F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.76099F));
            this.tblSearch.Controls.Add(this.label7, 0, 0);
            this.tblSearch.Controls.Add(this.panel1, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 8;
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
            this.label7.Size = new System.Drawing.Size(244, 53);
            this.label7.TabIndex = 0;
            this.label7.Text = "생산일자";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerSearch1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(255, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 47);
            this.panel1.TabIndex = 1;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle.Location = new System.Drawing.Point(38, 125);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(145, 29);
            this.lblSubTitle.TabIndex = 49;
            this.lblSubTitle.Text = "☷ 조회내역";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(40, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 40);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Text = "금형 사용현황";
            // 
            // dateTimePickerSearch1
            // 
            this.dateTimePickerSearch1.BackColor = System.Drawing.Color.White;
            this.dateTimePickerSearch1.ButtonText = "🔍";
            this.dateTimePickerSearch1.dateTimePickerValue1 = new System.DateTime(2021, 7, 19, 0, 0, 0, 0);
            this.dateTimePickerSearch1.dateTimePickerValue2 = new System.DateTime(2021, 7, 26, 0, 0, 0, 0);
            this.dateTimePickerSearch1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePickerSearch1.Location = new System.Drawing.Point(9, 7);
            this.dateTimePickerSearch1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerSearch1.Name = "dateTimePickerSearch1";
            this.dateTimePickerSearch1.Size = new System.Drawing.Size(259, 31);
            this.dateTimePickerSearch1.TabIndex = 2;
            // 
            // frmMoldUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Controls.Add(this.pnlDataGridView);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMoldUse";
            this.Text = "금형 사용현황";
            this.Load += new System.EventHandler(this.frmMoldUse_Load);
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoldList)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlDataGridView;
        private System.Windows.Forms.DataGridView dgvMoldList;
        protected System.Windows.Forms.Panel pnlSearch;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label lblSubTitle;
        protected System.Windows.Forms.Label lblTitle;
        private DateTimePickerSearch dateTimePickerSearch1;
    }
}