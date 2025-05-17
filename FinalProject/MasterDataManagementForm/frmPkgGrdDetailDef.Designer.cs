
namespace FinalProject
{ 
    partial class frmPkgGrdDetailDef
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPkgGrdDetailDef));
            this.dgvPkgDetail = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUdtName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUdtCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cboUdtGrade = new System.Windows.Forms.ComboBox();
            this.btnTextClear = new System.Windows.Forms.Button();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            this.pnlSubBottons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPkgDetail)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(253, 40);
            this.lblTitle.Text = "포장등급상세정의";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.cboUdtGrade);
            this.pnlCondition.Controls.Add(this.label2);
            this.pnlCondition.Controls.Add(this.txtUdtName);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtUdtCode);
            this.pnlCondition.Controls.Add(this.label12);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Location = new System.Drawing.Point(43, 861);
            this.lblSubTitle2.Size = new System.Drawing.Size(172, 32);
            this.lblSubTitle2.Text = "☷ 포장등급설정";
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvPkgDetail);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Controls.Add(this.btnTextClear);
            this.pnlSubBottons.Controls.Add(this.btnSave);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Text = "☷ 포장등급상세";
            // 
            // dgvPkgDetail
            // 
            this.dgvPkgDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvPkgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPkgDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPkgDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvPkgDetail.Name = "dgvPkgDetail";
            this.dgvPkgDetail.RowTemplate.Height = 23;
            this.dgvPkgDetail.Size = new System.Drawing.Size(1457, 688);
            this.dgvPkgDetail.TabIndex = 0;
            this.dgvPkgDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPkgDetail_CellClick);
            this.dgvPkgDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPkgDetail_CellDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(273, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 32);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUdtName
            // 
            this.txtUdtName.Location = new System.Drawing.Point(648, 54);
            this.txtUdtName.Name = "txtUdtName";
            this.txtUdtName.Size = new System.Drawing.Size(272, 23);
            this.txtUdtName.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(509, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = " ✧  포장등급상세명";
            // 
            // txtUdtCode
            // 
            this.txtUdtCode.Location = new System.Drawing.Point(174, 50);
            this.txtUdtCode.Name = "txtUdtCode";
            this.txtUdtCode.ReadOnly = true;
            this.txtUdtCode.Size = new System.Drawing.Size(272, 23);
            this.txtUdtCode.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = " ✧  포장등급상세코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(962, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = " ✧  포장등급";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plus.png");
            this.imageList1.Images.SetKeyName(1, "minus.png");
            // 
            // cboUdtGrade
            // 
            this.cboUdtGrade.FormattingEnabled = true;
            this.cboUdtGrade.Location = new System.Drawing.Point(1087, 54);
            this.cboUdtGrade.Name = "cboUdtGrade";
            this.cboUdtGrade.Size = new System.Drawing.Size(234, 23);
            this.cboUdtGrade.TabIndex = 26;
            // 
            // btnTextClear
            // 
            this.btnTextClear.BackColor = System.Drawing.Color.White;
            this.btnTextClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTextClear.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTextClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnTextClear.Location = new System.Drawing.Point(235, 0);
            this.btnTextClear.Name = "btnTextClear";
            this.btnTextClear.Size = new System.Drawing.Size(32, 30);
            this.btnTextClear.TabIndex = 69;
            this.btnTextClear.Text = "⟳";
            this.btnTextClear.UseVisualStyleBackColor = false;
            this.btnTextClear.Click += new System.EventHandler(this.btnTextClear_Click);
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5494506F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.82967F));
            this.tblSearch.Controls.Add(this.label1, 2, 0);
            this.tblSearch.Controls.Add(this.label7, 0, 0);
            this.tblSearch.Controls.Add(this.txtCode, 3, 0);
            this.tblSearch.Controls.Add(this.cboName, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(489, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 53);
            this.label1.TabIndex = 3;
            this.label1.Text = "등급상세코드";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label7.Text = "등급상세명";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(659, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(308, 23);
            this.txtCode.TabIndex = 1;
            // 
            // cboName
            // 
            this.cboName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(174, 17);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(308, 23);
            this.cboName.TabIndex = 2;
            // 
            // frmPkgGrdDetailDef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmPkgGrdDetailDef";
            this.Load += new System.EventHandler(this.frmPkgGrdDetailDef_Load);
            this.panel1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlDataGridView.ResumeLayout(false);
            this.pnlSubBottons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPkgDetail)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPkgDetail;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txtUdtName;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtUdtCode;
        protected System.Windows.Forms.Label label12;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cboUdtGrade;
        protected System.Windows.Forms.Button btnTextClear;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ComboBox cboName;
    }
}
