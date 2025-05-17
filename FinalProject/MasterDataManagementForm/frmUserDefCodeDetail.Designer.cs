
namespace FinalProject
{
    partial class frmUserDefCodeDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserDefCodeDetail));
            this.dgvBig = new System.Windows.Forms.DataGridView();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUdtDetailCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUdtCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUdtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClearText = new System.Windows.Forms.Button();
            this.txtUdtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlSubBottons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvBig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetail);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(359, 40);
            this.lblTitle.Text = "사용자정의코드 상세분류";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.txtUdtName);
            this.pnlCondition.Controls.Add(this.label3);
            this.pnlCondition.Controls.Add(this.txtUdtRemark);
            this.pnlCondition.Controls.Add(this.label4);
            this.pnlCondition.Controls.Add(this.txtUdtDetailCode);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtUdtCode);
            this.pnlCondition.Controls.Add(this.label12);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Controls.Add(this.btnClearText);
            this.pnlSubBottons.Controls.Add(this.btnSave);
            this.pnlSubBottons.Location = new System.Drawing.Point(632, 723);
            this.pnlSubBottons.Size = new System.Drawing.Size(335, 32);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 726);
            this.label2.Text = "☷ 입력정보";
            // 
            // lblSubTitle1
            // 
            this.lblSubTitle1.Text = "☷ 대분류";
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Size = new System.Drawing.Size(134, 31);
            this.lblSubTitle2.Text = "☷ 상세분류";
            // 
            // dgvBig
            // 
            this.dgvBig.BackgroundColor = System.Drawing.Color.White;
            this.dgvBig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBig.Location = new System.Drawing.Point(0, 35);
            this.dgvBig.Name = "dgvBig";
            this.dgvBig.RowTemplate.Height = 23;
            this.dgvBig.Size = new System.Drawing.Size(486, 856);
            this.dgvBig.TabIndex = 24;
            this.dgvBig.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBig_CellDoubleClick);
            // 
            // dgvDetail
            // 
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(8, 35);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(959, 681);
            this.dgvDetail.TabIndex = 41;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(264, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 32);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUdtDetailCode
            // 
            this.txtUdtDetailCode.Location = new System.Drawing.Point(619, 24);
            this.txtUdtDetailCode.Name = "txtUdtDetailCode";
            this.txtUdtDetailCode.ReadOnly = true;
            this.txtUdtDetailCode.Size = new System.Drawing.Size(272, 23);
            this.txtUdtDetailCode.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(497, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = " ✧  상세분류코드";
            // 
            // txtUdtCode
            // 
            this.txtUdtCode.Location = new System.Drawing.Point(199, 24);
            this.txtUdtCode.Name = "txtUdtCode";
            this.txtUdtCode.ReadOnly = true;
            this.txtUdtCode.Size = new System.Drawing.Size(272, 23);
            this.txtUdtCode.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(89, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = " ✧  대분류코드";
            // 
            // txtUdtRemark
            // 
            this.txtUdtRemark.Location = new System.Drawing.Point(619, 74);
            this.txtUdtRemark.Name = "txtUdtRemark";
            this.txtUdtRemark.Size = new System.Drawing.Size(272, 23);
            this.txtUdtRemark.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = " ✧  비고";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plus.png");
            this.imageList1.Images.SetKeyName(1, "minus.png");
            // 
            // btnClearText
            // 
            this.btnClearText.BackColor = System.Drawing.Color.White;
            this.btnClearText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearText.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClearText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClearText.Location = new System.Drawing.Point(231, 2);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(32, 30);
            this.btnClearText.TabIndex = 67;
            this.btnClearText.Text = "⟳";
            this.btnClearText.UseVisualStyleBackColor = false;
            this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
            // 
            // txtUdtName
            // 
            this.txtUdtName.Location = new System.Drawing.Point(199, 77);
            this.txtUdtName.Name = "txtUdtName";
            this.txtUdtName.Size = new System.Drawing.Size(272, 23);
            this.txtUdtName.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = " ✧  상세분류명";
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
            this.tblSearch.Controls.Add(this.txtName, 5, 0);
            this.tblSearch.Controls.Add(this.label1, 4, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.label14, 0, 0);
            this.tblSearch.Controls.Add(this.cboSearchType, 1, 0);
            this.tblSearch.Controls.Add(this.txtCode, 3, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1460, 55);
            this.tblSearch.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(1144, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(312, 23);
            this.txtName.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(974, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "분류명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label13.Text = "코드번호";
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
            this.label14.Text = "조회조건";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSearchType
            // 
            this.cboSearchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Location = new System.Drawing.Point(174, 17);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(308, 23);
            this.cboSearchType.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(659, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(308, 23);
            this.txtCode.TabIndex = 1;
            // 
            // frmUserDefCodeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmUserDefCodeDetail";
            this.Load += new System.EventHandler(this.frmUserDefCodeDetail_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlSubBottons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvBig;
        private System.Windows.Forms.DataGridView dgvDetail;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.TextBox txtUdtRemark;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtUdtDetailCode;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtUdtCode;
        protected System.Windows.Forms.Label label12;
        private System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Button btnClearText;
        protected System.Windows.Forms.TextBox txtUdtName;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.TextBox txtCode;
    }
}
