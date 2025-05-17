
namespace FinalProject
{ 
    partial class frmCarriageInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarriageInfo));
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvCarriage = new System.Windows.Forms.DataGridView();
            this.txtUdtName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUdtCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cboUdtGroup = new System.Windows.Forms.ComboBox();
            this.btnTextClear = new System.Windows.Forms.Button();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            this.pnlSubBottons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarriage)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(157, 40);
            this.lblTitle.Text = "대차정보";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.cboUdtGroup);
            this.pnlCondition.Controls.Add(this.label3);
            this.pnlCondition.Controls.Add(this.txtUdtName);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtUdtCode);
            this.pnlCondition.Controls.Add(this.label12);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Text = "☷ 대차 설정";
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvCarriage);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Controls.Add(this.btnTextClear);
            this.pnlSubBottons.Controls.Add(this.btnSave);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Text = "☷ 대차목록";
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
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvCarriage
            // 
            this.dgvCarriage.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarriage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarriage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarriage.Location = new System.Drawing.Point(0, 0);
            this.dgvCarriage.Name = "dgvCarriage";
            this.dgvCarriage.RowTemplate.Height = 23;
            this.dgvCarriage.Size = new System.Drawing.Size(1457, 688);
            this.dgvCarriage.TabIndex = 0;
            this.dgvCarriage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarriage_CellClick);
            this.dgvCarriage.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarriage_CellDoubleClick);
            // 
            // txtUdtName
            // 
            this.txtUdtName.Location = new System.Drawing.Point(718, 54);
            this.txtUdtName.Name = "txtUdtName";
            this.txtUdtName.Size = new System.Drawing.Size(272, 23);
            this.txtUdtName.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(621, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 15);
            this.label10.TabIndex = 33;
            this.label10.Text = " ✧  대차명";
            // 
            // txtUdtCode
            // 
            this.txtUdtCode.Location = new System.Drawing.Point(244, 50);
            this.txtUdtCode.Name = "txtUdtCode";
            this.txtUdtCode.ReadOnly = true;
            this.txtUdtCode.Size = new System.Drawing.Size(272, 23);
            this.txtUdtCode.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(101, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 34;
            this.label12.Text = " ✧  대차코드";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plus.png");
            this.imageList1.Images.SetKeyName(1, "minus.png");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1039, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = " ✧  그룹";
            // 
            // cboUdtGroup
            // 
            this.cboUdtGroup.FormattingEnabled = true;
            this.cboUdtGroup.Items.AddRange(new object[] {
            "성형",
            "소성",
            "건조"});
            this.cboUdtGroup.Location = new System.Drawing.Point(1112, 54);
            this.cboUdtGroup.Name = "cboUdtGroup";
            this.cboUdtGroup.Size = new System.Drawing.Size(272, 23);
            this.cboUdtGroup.TabIndex = 37;
            // 
            // btnTextClear
            // 
            this.btnTextClear.BackColor = System.Drawing.Color.White;
            this.btnTextClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTextClear.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTextClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnTextClear.Location = new System.Drawing.Point(240, 0);
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
            this.tblSearch.ColumnCount = 5;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tblSearch.Controls.Add(this.label6, 2, 0);
            this.tblSearch.Controls.Add(this.label7, 0, 0);
            this.tblSearch.Controls.Add(this.txtCode, 3, 0);
            this.tblSearch.Controls.Add(this.cboName, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(532, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 53);
            this.label6.TabIndex = 3;
            this.label6.Text = "대차코드";
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
            this.label7.Size = new System.Drawing.Size(191, 53);
            this.label7.TabIndex = 0;
            this.label7.Text = "대차명";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(730, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(323, 23);
            this.txtCode.TabIndex = 1;
            // 
            // cboName
            // 
            this.cboName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(202, 17);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(323, 23);
            this.cboName.TabIndex = 2;
            // 
            // frmCarriageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmCarriageInfo";
            this.Load += new System.EventHandler(this.frmCarriageInfo_Load);
            this.panel1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlDataGridView.ResumeLayout(false);
            this.pnlSubBottons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarriage)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvCarriage;
        protected System.Windows.Forms.TextBox txtUdtName;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtUdtCode;
        protected System.Windows.Forms.Label label12;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cboUdtGroup;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Button btnTextClear;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ComboBox cboName;
    }
}
