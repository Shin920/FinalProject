
namespace FinalProject
{
    partial class frmUsergroupM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsergroupM));
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dgvUsergroup = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.cboUserGN = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlCondition = new System.Windows.Forms.Panel();
            this.txtUserGroupName = new System.Windows.Forms.TextBox();
            this.txtUserGroupCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle2 = new System.Windows.Forms.Label();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsergroup)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataGridView.Controls.Add(this.dgvUsergroup);
            this.pnlDataGridView.Location = new System.Drawing.Point(45, 161);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(1457, 527);
            this.pnlDataGridView.TabIndex = 40;
            // 
            // dgvUsergroup
            // 
            this.dgvUsergroup.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsergroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsergroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsergroup.Location = new System.Drawing.Point(0, 0);
            this.dgvUsergroup.Name = "dgvUsergroup";
            this.dgvUsergroup.RowTemplate.Height = 23;
            this.dgvUsergroup.Size = new System.Drawing.Size(1457, 527);
            this.dgvUsergroup.TabIndex = 0;
            this.dgvUsergroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsergroup_CellClick);
            this.dgvUsergroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsergroup_CellClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "minus.png");
            this.imageList1.Images.SetKeyName(1, "plus.png");
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.tblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(45, 68);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1457, 55);
            this.pnlSearch.TabIndex = 38;
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 2;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tblSearch.Controls.Add(this.cboUserGN, 1, 0);
            this.tblSearch.Controls.Add(this.label7, 0, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 4;
            // 
            // cboUserGN
            // 
            this.cboUserGN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboUserGN.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cboUserGN.FormattingEnabled = true;
            this.cboUserGN.Location = new System.Drawing.Point(247, 16);
            this.cboUserGN.Name = "cboUserGN";
            this.cboUserGN.Size = new System.Drawing.Size(308, 23);
            this.cboUserGN.TabIndex = 3;
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
            this.label7.Size = new System.Drawing.Size(236, 53);
            this.label7.TabIndex = 0;
            this.label7.Text = "사용자 그룹명";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCondition
            // 
            this.pnlCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCondition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCondition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCondition.Controls.Add(this.txtUserGroupName);
            this.pnlCondition.Controls.Add(this.txtUserGroupCode);
            this.pnlCondition.Controls.Add(this.label3);
            this.pnlCondition.Controls.Add(this.label4);
            this.pnlCondition.Location = new System.Drawing.Point(42, 729);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(1457, 81);
            this.pnlCondition.TabIndex = 36;
            // 
            // txtUserGroupName
            // 
            this.txtUserGroupName.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtUserGroupName.Location = new System.Drawing.Point(197, 29);
            this.txtUserGroupName.Name = "txtUserGroupName";
            this.txtUserGroupName.Size = new System.Drawing.Size(389, 23);
            this.txtUserGroupName.TabIndex = 12;
            // 
            // txtUserGroupCode
            // 
            this.txtUserGroupCode.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtUserGroupCode.Location = new System.Drawing.Point(936, 29);
            this.txtUserGroupCode.Name = "txtUserGroupCode";
            this.txtUserGroupCode.Size = new System.Drawing.Size(389, 23);
            this.txtUserGroupCode.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label3.Location = new System.Drawing.Point(757, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = " ✧  사용자 그룹명 코드";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label4.Location = new System.Drawing.Point(45, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = " ✧  사용자 그룹명";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle.Location = new System.Drawing.Point(40, 126);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(145, 29);
            this.lblSubTitle.TabIndex = 39;
            this.lblSubTitle.Text = "☷ 조회내역";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(42, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 40);
            this.lblTitle.TabIndex = 37;
            this.lblTitle.Text = "사용자 그룹관리";
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSubTitle2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle2.Location = new System.Drawing.Point(37, 691);
            this.lblSubTitle2.Name = "lblSubTitle2";
            this.lblSubTitle2.Size = new System.Drawing.Size(149, 32);
            this.lblSubTitle2.TabIndex = 35;
            this.lblSubTitle2.Text = "☷ 공정조건";
            // 
            // frmUsergroupM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Controls.Add(this.pnlDataGridView);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlCondition);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubTitle2);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUsergroupM";
            this.Text = "시스템관리";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUsergroupM_Load);
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsergroup)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlDataGridView;
        private System.Windows.Forms.DataGridView dgvUsergroup;
        private System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Panel pnlSearch;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.ComboBox cboUserGN;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Panel pnlCondition;
        private System.Windows.Forms.TextBox txtUserGroupName;
        private System.Windows.Forms.TextBox txtUserGroupCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label lblSubTitle;
        protected System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.Label lblSubTitle2;
    }
}