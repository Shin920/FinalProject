
namespace FinalProject
{ 
    partial class frmWorkCenterInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkCenterInfo));
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dgvWCList = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.rdoProcess = new System.Windows.Forms.RadioButton();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboWCName = new System.Windows.Forms.ComboBox();
            this.txtWCCode = new System.Windows.Forms.TextBox();
            this.rdoName = new System.Windows.Forms.RadioButton();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWCList)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataGridView.Controls.Add(this.dgvWCList);
            this.pnlDataGridView.Location = new System.Drawing.Point(43, 160);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(1457, 651);
            this.pnlDataGridView.TabIndex = 31;
            // 
            // dgvWCList
            // 
            this.dgvWCList.BackgroundColor = System.Drawing.Color.White;
            this.dgvWCList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWCList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWCList.Location = new System.Drawing.Point(0, 0);
            this.dgvWCList.Name = "dgvWCList";
            this.dgvWCList.RowTemplate.Height = 23;
            this.dgvWCList.Size = new System.Drawing.Size(1457, 651);
            this.dgvWCList.TabIndex = 0;
            this.dgvWCList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWCList_CellClick);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.tblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(43, 67);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1457, 55);
            this.pnlSearch.TabIndex = 28;
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
            this.tblSearch.Controls.Add(this.rdoProcess, 4, 0);
            this.tblSearch.Controls.Add(this.txtProcess, 5, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.cboWCName, 1, 0);
            this.tblSearch.Controls.Add(this.txtWCCode, 3, 0);
            this.tblSearch.Controls.Add(this.rdoName, 0, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 5;
            // 
            // rdoProcess
            // 
            this.rdoProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoProcess.AutoSize = true;
            this.rdoProcess.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rdoProcess.Location = new System.Drawing.Point(974, 4);
            this.rdoProcess.Name = "rdoProcess";
            this.rdoProcess.Size = new System.Drawing.Size(163, 47);
            this.rdoProcess.TabIndex = 36;
            this.rdoProcess.TabStop = true;
            this.rdoProcess.Text = "공정";
            this.rdoProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoProcess.UseVisualStyleBackColor = false;
            // 
            // txtProcess
            // 
            this.txtProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcess.Location = new System.Drawing.Point(1144, 17);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(309, 21);
            this.txtProcess.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(489, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 53);
            this.label13.TabIndex = 3;
            this.label13.Text = "작업장코드";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboWCName
            // 
            this.cboWCName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWCName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWCName.FormattingEnabled = true;
            this.cboWCName.Location = new System.Drawing.Point(174, 17);
            this.cboWCName.Name = "cboWCName";
            this.cboWCName.Size = new System.Drawing.Size(308, 20);
            this.cboWCName.TabIndex = 2;
            // 
            // txtWCCode
            // 
            this.txtWCCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWCCode.Location = new System.Drawing.Point(659, 17);
            this.txtWCCode.Name = "txtWCCode";
            this.txtWCCode.Size = new System.Drawing.Size(308, 21);
            this.txtWCCode.TabIndex = 1;
            // 
            // rdoName
            // 
            this.rdoName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoName.AutoSize = true;
            this.rdoName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rdoName.Location = new System.Drawing.Point(4, 4);
            this.rdoName.Name = "rdoName";
            this.rdoName.Size = new System.Drawing.Size(163, 47);
            this.rdoName.TabIndex = 35;
            this.rdoName.TabStop = true;
            this.rdoName.Text = "작업장명";
            this.rdoName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoName.UseVisualStyleBackColor = false;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle.Location = new System.Drawing.Point(38, 125);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(145, 29);
            this.lblSubTitle.TabIndex = 29;
            this.lblSubTitle.Text = "☷ 작업장목록";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(40, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 40);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "작업장정보";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Location = new System.Drawing.Point(915, 125);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(585, 32);
            this.pnlButtons.TabIndex = 30;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plus.png");
            this.imageList1.Images.SetKeyName(1, "minus.png");
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(329, 28);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(0, 12);
            this.lblCode.TabIndex = 32;
            this.lblCode.Visible = false;
            // 
            // frmWorkCenterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.pnlDataGridView);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlButtons);
            this.Name = "frmWorkCenterInfo";
            this.Text = "frmWorkplaceInfo";
            this.Load += new System.EventHandler(this.frmWorkCenterInfo_Load);
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWCList)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel pnlDataGridView;
        protected System.Windows.Forms.Panel pnlSearch;
        protected System.Windows.Forms.Label lblSubTitle;
        protected System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.DataGridView dgvWCList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblCode;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.RadioButton rdoProcess;
        private System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboWCName;
        private System.Windows.Forms.TextBox txtWCCode;
        private System.Windows.Forms.RadioButton rdoName;
    }
}