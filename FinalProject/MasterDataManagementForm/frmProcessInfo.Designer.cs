
namespace FinalProject
{
    partial class frmProcessInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessInfo));
            this.dgvPrcList = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUdtPrcRemark = new System.Windows.Forms.TextBox();
            this.txtUdtPrcName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUdtPrcCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnTextClear = new System.Windows.Forms.Button();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrcCode = new System.Windows.Forms.TextBox();
            this.cboPrcName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            this.pnlSubBottons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrcList)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(156, 40);
            this.lblTitle.Text = "공정정보";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.label11);
            this.pnlCondition.Controls.Add(this.txtUdtPrcRemark);
            this.pnlCondition.Controls.Add(this.txtUdtPrcName);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtUdtPrcCode);
            this.pnlCondition.Controls.Add(this.label12);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Text = "☷ 공정설정";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(585, 44);
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvPrcList);
            this.pnlDataGridView.Location = new System.Drawing.Point(44, 171);
            this.pnlDataGridView.Size = new System.Drawing.Size(1457, 684);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Controls.Add(this.btnTextClear);
            this.pnlSubBottons.Controls.Add(this.btnSave);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Text = "☷ 공정목록";
            // 
            // dgvPrcList
            // 
            this.dgvPrcList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrcList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrcList.Location = new System.Drawing.Point(0, 0);
            this.dgvPrcList.Name = "dgvPrcList";
            this.dgvPrcList.RowTemplate.Height = 27;
            this.dgvPrcList.Size = new System.Drawing.Size(1457, 684);
            this.dgvPrcList.TabIndex = 0;
            this.dgvPrcList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrcList_CellClick);
            this.dgvPrcList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrcList_CellDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(507, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = " ✧  비고";
            // 
            // txtUdtPrcRemark
            // 
            this.txtUdtPrcRemark.Location = new System.Drawing.Point(597, 28);
            this.txtUdtPrcRemark.Multiline = true;
            this.txtUdtPrcRemark.Name = "txtUdtPrcRemark";
            this.txtUdtPrcRemark.Size = new System.Drawing.Size(350, 69);
            this.txtUdtPrcRemark.TabIndex = 12;
            // 
            // txtUdtPrcName
            // 
            this.txtUdtPrcName.Location = new System.Drawing.Point(161, 74);
            this.txtUdtPrcName.Name = "txtUdtPrcName";
            this.txtUdtPrcName.Size = new System.Drawing.Size(272, 23);
            this.txtUdtPrcName.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = " ✧  공정명";
            // 
            // txtUdtPrcCode
            // 
            this.txtUdtPrcCode.Location = new System.Drawing.Point(161, 28);
            this.txtUdtPrcCode.Name = "txtUdtPrcCode";
            this.txtUdtPrcCode.ReadOnly = true;
            this.txtUdtPrcCode.Size = new System.Drawing.Size(272, 23);
            this.txtUdtPrcCode.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(74, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = " ✧  공정코드";
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
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plus.png");
            this.imageList1.Images.SetKeyName(1, "minus.png");
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
            this.btnTextClear.TabIndex = 68;
            this.btnTextClear.Text = "⟳";
            this.btnTextClear.UseVisualStyleBackColor = false;
            this.btnTextClear.Click += new System.EventHandler(this.btnTextClear_Click);
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 5;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.92695F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.78951F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.99107F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.78703F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.50543F));
            this.tblSearch.Controls.Add(this.label6, 2, 0);
            this.tblSearch.Controls.Add(this.label7, 0, 0);
            this.tblSearch.Controls.Add(this.txtPrcCode, 3, 0);
            this.tblSearch.Controls.Add(this.cboPrcName, 1, 0);
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
            this.label6.Location = new System.Drawing.Point(509, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 53);
            this.label6.TabIndex = 3;
            this.label6.Text = "공정코드";
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
            this.label7.Size = new System.Drawing.Size(196, 53);
            this.label7.TabIndex = 0;
            this.label7.Text = "공정명";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrcCode
            // 
            this.txtPrcCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrcCode.Location = new System.Drawing.Point(669, 16);
            this.txtPrcCode.Name = "txtPrcCode";
            this.txtPrcCode.Size = new System.Drawing.Size(295, 23);
            this.txtPrcCode.TabIndex = 1;
            // 
            // cboPrcName
            // 
            this.cboPrcName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrcName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrcName.FormattingEnabled = true;
            this.cboPrcName.Location = new System.Drawing.Point(207, 17);
            this.cboPrcName.Name = "cboPrcName";
            this.cboPrcName.Size = new System.Drawing.Size(295, 23);
            this.cboPrcName.TabIndex = 2;
            // 
            // frmProcessInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmProcessInfo";
            this.Load += new System.EventHandler(this.frmProcessInfo_Load);
            this.panel1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlDataGridView.ResumeLayout(false);
            this.pnlSubBottons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrcList)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPrcList;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox txtUdtPrcRemark;
        protected System.Windows.Forms.TextBox txtUdtPrcName;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtUdtPrcCode;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Button btnTextClear;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrcCode;
        private System.Windows.Forms.ComboBox cboPrcName;
    }
}
